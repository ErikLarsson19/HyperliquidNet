using HyperliquidNet.src.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace HyperliquidNet.src
{
    /// <summary>
    /// Client for handling Websocket connections to the Hyperliquid API.
    /// Manages connection lifestyle, message handling and resource cleanup.
    /// </summary>
    public class HyperliquidWebsocketClient : IDisposable
    {
        private readonly HyperliquidWebsocketClientOptions _options;
        private ClientWebSocket _websocket;
        private readonly Uri _baseUri;
        private CancellationTokenSource _cancellationTokenSource;
        private bool _disposed;
        public WebSocketMarketDataService Market { get; }

        //Event that fires when message is received from WebSocket
        public event Action<string> OnMessage;

        /// <summary>
        /// Default constructor, initializes with default options.
        /// </summary>
        public HyperliquidWebsocketClient()
            : this(new HyperliquidWebsocketClientOptions())
        {
            Market = new WebSocketMarketDataService(this);
        }

        /// <summary>
        /// Initializes the client with custom options
        /// </summary>
        /// <param name="options">Config options for the WS client</param>
        /// <exception cref="ArgumentNullException">Throws when options are null</exception>
        public HyperliquidWebsocketClient(HyperliquidWebsocketClientOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            //Validates and clones options to prevent external modification
            options.Validate();
            _options = options.Clone();
            _baseUri = new Uri(_options.BaseUrl);
            _websocket = CreateWebSocket(_options);
            _cancellationTokenSource = new CancellationTokenSource();
        }

        /// <summary>
        /// Creates the WebSocket instance with the specified options.
        /// </summary>
        /// <param name="options">Options to config the WS</param>
        /// <returns>Configured ClientWebSocket instance</returns>
        public static ClientWebSocket CreateWebSocket(HyperliquidWebsocketClientOptions options)
        {
            var ws = new ClientWebSocket
            {
                Options =
                {
                    KeepAliveInterval = TimeSpan.FromSeconds(options.KeepAliveInterval)
                }
            };

            return ws;
        }

        /// <summary>
        /// Establishes connection to the Websocket server and starts message receiving
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ObjectDisposedException">Thrown if client is disposed</exception>
        /// <exception cref="InvalidOperationException">Thrown if connection fails</exception>
        public async Task ConnectAsync()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(HyperliquidWebsocketClient));

            try
            {
                await _websocket.ConnectAsync(_baseUri, _cancellationTokenSource.Token);

                //(fire-and-forget)
                _ = StartReceiving();
            } catch (Exception e)
            {
                throw new InvalidOperationException("Failed to connect to webSocket server" + e.Message);
            }
        }

        /// <summary>
        /// Subscribes to a specific WebSocket feed using the provided JSON subscription message
        /// </summary>
        /// <param name="subscriptionJson">JSON string containing subscription details</param>
        /// <returns></returns>
        /// <exception cref="ObjectDisposedException">Thrown if client is disposed</exception>
        /// <exception cref="InvalidOperationException">Thrown if WebSocket is not connected</exception>
        public async Task SubscribeAsync(string subscriptionJson)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(HyperliquidWebsocketClient));

            if (_websocket.State != WebSocketState.Open)
                throw new InvalidOperationException("Websocket is not connected");

            await SendAsync(subscriptionJson);
        }

        /// <summary>
        /// Unsubscribes to a specific WebSocket feed using the provided JSON subscription message
        /// </summary>
        /// <param name="subscriptionJson">JSON string containing subscription detials</param>
        /// <returns></returns>
        /// <exception cref="ObjectDisposedException">Thrown if client is disposed</exception>
        /// <exception cref="InvalidOperationException">Thrown if WebSocket is not connected</exception>
        public async Task UnsubscribeAsync(string subscriptionJson)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(HyperliquidWebsocketClient));

            if (_websocket.State != WebSocketState.Open)
                throw new InvalidOperationException("Websocket is not connected");

            await SendAsync(subscriptionJson);
        }

        /// <summary>
        /// Sends a message through the WebSocket connection
        /// </summary>
        /// <param name="message">Message to send</param>
        /// <returns></returns>
        private async Task SendAsync(string message)
        {
            //Converts strings message to byte array
            var buffer = Encoding.UTF8.GetBytes(message);
            await _websocket.SendAsync(
                new ArraySegment<byte>(buffer),
                WebSocketMessageType.Text,
                true,
                _cancellationTokenSource.Token);
        }

        /// <summary>
        /// Continuously receive messages from the WebSocket connection
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private async Task StartReceiving()
        {
            //buffer with size from options.
            var buffer = new byte[_options.ReceiveBufferSize];

            try
            {
                //Recieve while connection is open
                while (_websocket.State == WebSocketState.Open)
                {
                    var result = await _websocket.ReceiveAsync(
                        new ArraySegment<byte>(buffer),
                        _cancellationTokenSource.Token);

                    if(result.MessageType == WebSocketMessageType.Close)
                    {
                        await _websocket.CloseAsync(
                            WebSocketCloseStatus.NormalClosure,
                            string.Empty,
                            _cancellationTokenSource.Token);
                        break;
                    }
                    //Convert recieved bytes to string and trigger the event
                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    OnMessage?.Invoke(message);
                }
            } catch(Exception e) when (_disposed)
            {

            }
            catch (Exception ex)
            {
                if (!_cancellationTokenSource.IsCancellationRequested)
                {
                    throw new InvalidOperationException("Websocket recieved error ", ex);
                }
            }
        }

        /// <summary>
        /// Gracefully closes the WebSocket connection.
        /// </summary>
        /// <returns></returns>
        public async Task DisconnectAsync()
        {
            if(_websocket.State == WebSocketState.Open)
            {
                await _websocket.CloseAsync(
                    WebSocketCloseStatus.NormalClosure,
                    string.Empty,
                    CancellationToken.None);
            }
        }



       /// <summary>
       /// Implements IDisposable pattern to clean up resources.
       /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Protected implementation of Dispose pattern.
        /// </summary>
        /// <param name="disposing">True if called from Dispose()</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _cancellationTokenSource.Cancel();
                if(_websocket.State == WebSocketState.Open)
                {
                    _websocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None)
                        .GetAwaiter()
                        .GetResult();
                }
                _websocket.Dispose();
                _cancellationTokenSource.Dispose();
            }
            _disposed = true;
        }
    }
}
