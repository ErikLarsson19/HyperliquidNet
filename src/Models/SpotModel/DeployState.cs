using HyperliquidNet.src.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.SpotModel
{
    public class DeployState
    {
        [JsonPropertyName("token")]
        public int Token { get; set; }

        [JsonPropertyName("spec")]
        public StateSpec Spec { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("spots")]
        public List<int> Spots { get; set; }

        [JsonPropertyName("maxSupply")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal MaxSupply { get; set; }

        [JsonPropertyName("hyperliquidityGenesisBalance")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal HyperliquidityGenesisBalance { get; set; }

        [JsonPropertyName("totalGenesisBalanceWei")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal TotalGenesisBalanceWei { get; set; }

        [JsonPropertyName("userGenesisBalances")]
        public List<(string Address, string Balance)> UserGenesisBalances { get; set; }

        [JsonPropertyName("existingTokenGenesisBalances")]
        public List<(int Token, string Balance)> ExistingTokenGenesisBalances { get; set; }

    }
}
