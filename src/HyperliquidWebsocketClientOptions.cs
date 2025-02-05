using HyperliquidNet.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperliquidNet.src
{
    public class HyperliquidWebsocketClientOptions
    {
        public bool UseTestnet { get; set; }
        public int KeepAliveInterval { get; set; } = 30; //seconds
        public int ReceiveBufferSize { get; set; } = 1024 * 4;
        public int TimeoutSeconds { get; set; } = 30;

        private string _baseUrl;
        public string BaseUrl
        {
            get => _baseUrl ?? (UseTestnet ? DefaultTestnetUrl : DefaultMainnetUrl);
            set => _baseUrl = value;
        }

        private const string DefaultMainnetUrl = "wss://api.hyperliquid.xyz/ws";
        private const string DefaultTestnetUrl = "wss://api.hyperliquid-testnet.xyz/ws";


        internal void Validate()
        {
            if (TimeoutSeconds <= 0)
                throw new ArgumentException("Timeout must be greater than 0 seconds");
            if (KeepAliveInterval <= 0)
                throw new ArgumentException("KeepAliveInterval must be greater than 0 seconds");
            if (ReceiveBufferSize <= 0)
                throw new ArgumentException("ReceiveBufferSize must be greater than 0 bytes");
            if (_baseUrl != null && !Uri.IsWellFormedUriString(_baseUrl, UriKind.Absolute))
                throw new ArgumentException("BaseUrl must be a valid URL");
        }

        internal HyperliquidWebsocketClientOptions Clone()
        {
            return new HyperliquidWebsocketClientOptions
            {
                UseTestnet = this.UseTestnet,
                _baseUrl = this._baseUrl,
                KeepAliveInterval = this.KeepAliveInterval,
                ReceiveBufferSize = this.ReceiveBufferSize,
                TimeoutSeconds = this.TimeoutSeconds
            };
        }
    }
}


