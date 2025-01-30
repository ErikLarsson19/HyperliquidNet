using HyperliquidNet.src.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.MarketModels
{
    public class MarketUserVaultDepositEntry
    {

        [JsonPropertyName("vaultAddress")]
        public string VaultAddress { get; set; }

        [JsonPropertyName("equity")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal Equity { get; set; }
    }
}
