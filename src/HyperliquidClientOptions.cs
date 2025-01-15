using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperliquidNet.src
{   
    /// <summary>
    /// Provides config options for the HyperliquidClient
    /// </summary>
    public class HyperliquidClientOptions
    {
        /// <summary>
        /// Get or sets whether to use the testnet API endpoints
        /// When true, uses testnet. When false, uses mainnet.
        /// </summary>
        public bool UseTestnet { get; set; }

        /// <summary>
        /// Gets or sets the base API URL. If not provided, defaults based on UseTestnet value.
        /// </summary>
        public string BaseUrl
        {
            get => _baseUrl ?? (UseTestnet ? DefaultTestnetUrl : DefaultMainnetUrl);
            set => _baseUrl = value;
        }
        private string _baseUrl;

        
        /// <summary>
        /// Gets or sets the timeout for HTTP requests in seconds.
        /// Defaults to 30 seconds.
        /// </summary>
        public int TimeoutSeconds { get; set; } = 30;

        /// <summary>
        /// Gets or sets whether automatically retry failed requests.
        /// Defaults to true.
        /// </summary>
        public bool AutoRetry { get; set; } = true;

        /// <summary>
        /// Gets or sets the maximum number of retry attempts for failed requests.
        /// Only used when AutoRetry is true. Defaults to 3.
        /// </summary>
        public int MaxRetries { get; set; } = 3;

        //Constants for API URLs
        private const string DefaultMainnetUrl = "https://api.hyperliquid.xyz";
        private const string DefaultTestnetUrl = "https://api.hyperliquid-testnet.xyz";

        /// <summary>
        /// Default constructor, creates new instance with default settings.
        /// </summary>
        public HyperliquidClientOptions()
        {

        }

        /// <summary>
        /// Validates the current options config.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        internal void Validate()
        {
            if(TimeoutSeconds <= 0)
            {
                throw new ArgumentException("Timeout must be greater than 0 seconds", nameof(TimeoutSeconds));
            }

            if(MaxRetries < 0)
            {
                throw new ArgumentException("Retries must be larger than 0", nameof(MaxRetries));
            }

            if(_baseUrl != null && !Uri.IsWellFormedUriString(_baseUrl, UriKind.Absolute))
            {
                throw new ArgumentException("BaseUrl must be a valid URL", nameof(BaseUrl));
            }
        }

        /// <summary>
        /// Creates a copy of the current config.
        /// </summary>
        /// <returns></returns>
        internal HyperliquidClientOptions Clone()
        {
            return new HyperliquidClientOptions
            {
                UseTestnet = this.UseTestnet,
                _baseUrl = this._baseUrl,
                TimeoutSeconds = this.TimeoutSeconds,
                AutoRetry = this.AutoRetry,
                MaxRetries = this.MaxRetries
            };
        }
    }
}
