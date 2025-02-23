﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.PerpModel
{
    public class AssetPosition
    {
        [JsonPropertyName("position")]
        public PerpPosition Position { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
