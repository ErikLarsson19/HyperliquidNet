﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.Responses.MarketInfo
{
    public class MarketUserRole
    {
        [JsonPropertyName("role")]
        public string Role { get; set; }
    }
}
