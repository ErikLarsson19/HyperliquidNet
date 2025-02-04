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
    public class HyperliquidWebsocketClient : IDisposable
    {
        private readonly HyperliquidWebsocketClientOptions _options;
        private ClientWebSocket _websocket;
        private readonly Uri _baseUri;
        private CancellationTokenSource _cancellationTokenSource;
        private bool _disposed;

        public event Action<string> OnMessage;

        public HyperliquidWebsocketClient()
            : this(new HyperliquidWebsocketClientOptions())
        {

        }

        public HyperliquidWebsocketClient(HyperliquidWebsocketClientOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            options.Validate();
            _options = options.Clone();
            _baseUri = new Uri(_options.BaseUrl);
            _websocket = CreateWebSocket(_options);
            _cancellationTokenSource = new CancellationTokenSource();
        }

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


        public async Task ConnectAsync()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(HyperliquidWebsocketClient));

            try
            {
                await _websocket.ConnectAsync(_baseUri, _cancellationTokenSource.Token);
                _ = StartReceiving();
            } catch (Exception e)
            {
                throw new InvalidOperationException("Failed to connect to webSocket server" + e.Message);
            }
        }

        public async Task SubscribeAsync(string subscriptionJson)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(HyperliquidWebsocketClient));

            if (_websocket.State != WebSocketState.Open)
                throw new InvalidOperationException("Websocket is not connected");

            await SendAsync(subscriptionJson);
        }

        public async Task UnsubscribeAsync(string subscriptionJson)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(HyperliquidWebsocketClient));

            if (_websocket.State != WebSocketState.Open)
                throw new InvalidOperationException("Websocket is not connected");

            await SendAsync(subscriptionJson);
        }

        private async Task SendAsync(string message)
        {
            var buffer = Encoding.UTF8.GetBytes(message);
            await _websocket.SendAsync(
                new ArraySegment<byte>(buffer),
                WebSocketMessageType.Text,
                true,
                _cancellationTokenSource.Token);
        }

        private async Task StartReceiving()
        {
            var buffer = new byte[_options.ReceiveBufferSize];

            try
            {
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

       //Continue here.
        public void Dispose()
        {
            _cancellationTokenSource.Cancel();

            _websocket?.Dispose();
            _cancellationTokenSource?.Dispose();
        }
    }
}
