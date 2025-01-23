using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace HyperliquidNet.src
{
    public class HyperliquidWebsocketClient : IDisposable
    {
        private ClientWebSocket _websocket;
        private readonly Uri _baseUri;
        private CancellationTokenSource _cancellationTokenSource;

        public HyperliquidWebsocketClient(bool isTesnet = false)
        {
            _baseUri = isTesnet
                 ? new Uri("wss://api.hyperliquid-testnet.xyz/ws")
                : new Uri("wss://api.hyperliquid.xyz/ws");

            _websocket = new ClientWebSocket();

            _cancellationTokenSource = new CancellationTokenSource();
        }


        public async Task ConnectAsync()
        {
            try
            {
                await _websocket.ConnectAsync(_baseUri, _cancellationTokenSource.Token);
                Console.WriteLine("WS Connection Established.");

                //Fire n forget
                _ = ReceiveMessageAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine($"Websocket connection error: {e.Message}");
                throw;
            }
        }

        public async Task SubscribeAsync(string subscriptionJson)
        {
            if(_websocket.State != WebSocketState.Open)
            {
                throw new InvalidOperationException("Websocket is not open");
            }

            var buffer = Encoding.UTF8.GetBytes(subscriptionJson);

            await _websocket.SendAsync(
                new ArraySegment<byte>(buffer),
                WebSocketMessageType.Text,
                true,
                _cancellationTokenSource.Token
                );
        }

        private async Task ReceiveMessageAsync()
        {
            var buffer = new byte[1024 * 4];

            try
            {
                while (_websocket.State == WebSocketState.Open)
                {
                    var result = await _websocket.ReceiveAsync(
                        new ArraySegment<byte>(buffer),
                        _cancellationTokenSource.Token
                );

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await _websocket.CloseAsync(
                            WebSocketCloseStatus.NormalClosure,
                            string.Empty,
                            _cancellationTokenSource.Token
                            );
                        break;
                    }
                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);

                    HandleReceivedMessage(message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error receiveing Websocket message: {e.Message}");
            }
        }


        private void HandleReceivedMessage(string message)
        {
            Console.WriteLine($"Received message : {message}");
        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();

            _websocket?.Dispose();
            _cancellationTokenSource?.Dispose();
        }
    }
}
