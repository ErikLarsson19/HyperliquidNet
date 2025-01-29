using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.MarketModels
{
    public class VaultFollower
    {
        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("vaultEquity")]
        public string VaultEquity { get; set; }

        [JsonPropertyName("pnl")]
        public string Pnl { get; set; }

        [JsonPropertyName("allTimePnl")]
        public string AllTimePnl { get; set; }

        [JsonPropertyName("daysFollowing")]
        public int DaysFollowing { get; set; }

        [JsonPropertyName("vaultEntryTime")]
        public long VaultEntryTime { get; set; }

        [JsonPropertyName("lockupUntil")]
        public long LockupUntil { get; set; }
    }
}
