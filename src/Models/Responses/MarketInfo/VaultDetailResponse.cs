using HyperliquidNet.src.Models.MarketModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.Responses.MarketInfo
{
    public class VaultDetailResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("vaultAddress")]
        public string VaultAddress { get; set; }

        [JsonPropertyName("leader")]
        public string Leader { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("portfolio")]
        public List<List<object>> Portfolio { get; set; } 

        [JsonPropertyName("apr")]
        public decimal Apr { get; set; }

        [JsonPropertyName("followerState")]
        public object FollowerState { get; set; }

        [JsonPropertyName("leaderFraction")]
        public decimal LeaderFraction { get; set; }

        [JsonPropertyName("leaderCommission")]
        public decimal LeaderCommission { get; set; }

        [JsonPropertyName("followers")]
        public List<VaultFollower> Followers { get; set; }

        [JsonPropertyName("maxDistributable")]
        public decimal MaxDistributable { get; set; }

        [JsonPropertyName("maxWithdrawable")]
        public decimal MaxWithdrawable { get; set; }

        [JsonPropertyName("isClosed")]
        public bool IsClosed { get; set; }

        [JsonPropertyName("relationship")]
        public VaultRelationship Relationship { get; set; }

        [JsonPropertyName("allowDeposits")]
        public bool AllowDeposits { get; set; }

        [JsonPropertyName("alwaysCloseOnWithdraw")]
        public bool AlwaysCloseOnWithdraw { get; set; }
    }
}
