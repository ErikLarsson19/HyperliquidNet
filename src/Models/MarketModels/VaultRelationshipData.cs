using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.MarketModels
{
    public class VaultRelationshipData
    {
        [JsonPropertyName("childAddresses")]
        public List<string> ChildAddresses { get; set; }
    }
}
