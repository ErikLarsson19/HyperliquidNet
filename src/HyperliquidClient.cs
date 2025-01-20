using HyperliquidNet.src.Services;
using HyperliquidNet.src.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperliquidNet.src
{
    public class HyperliquidClient : IDisposable
    {
        private readonly HyperliquidClientOptions _hyperliquidClientOptions;
        private readonly HttpClient _httpClient;
        private bool _disposed;
        public ISpotService Spot { get; }
        public IPerpService Perp { get; }
        public IMarketInfoService Market { get; }


        /// <summary>
        /// Default constructor with default settings
        /// </summary>
        public HyperliquidClient()
            : this(new HyperliquidClientOptions())
        {
            Spot = new SpotService(_httpClient);
            Perp = new PerpService(_httpClient);
            Market = new MarketInfoService(_httpClient);
        }

        /// <summary>
        /// Constructor with specified hyperliquidClientOptions.
        /// Validates if the options meet the validation criterias.
        /// Then clones to options so each client gets its independant version of the options.
        /// </summary>
        /// <param name="hyperliquidClientOptions">Modified options</param>
        public HyperliquidClient(HyperliquidClientOptions hyperliquidClientOptions)
        {
            if (hyperliquidClientOptions == null)
                throw new ArgumentNullException(nameof(hyperliquidClientOptions));

            hyperliquidClientOptions.Validate();

            _hyperliquidClientOptions = hyperliquidClientOptions.Clone();

            _httpClient = CreateHttpClient(_hyperliquidClientOptions);
        }

        /// <summary>
        /// Creates the http client using the options properties.
        /// </summary>
        /// <param name="options">Uses the Timeout and Url set in options</param>
        /// <returns></returns>
        private static HttpClient CreateHttpClient(HyperliquidClientOptions options)
        {
            var client = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds)
            };

            client.BaseAddress = new Uri(options.BaseUrl);

            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        /// <summary>
        /// Disposes of the client.
        /// Tells gc not to finalize.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _httpClient?.Dispose();
            }

            _disposed = true;
        }
    }
}
