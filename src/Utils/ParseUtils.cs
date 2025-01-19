using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Utils
{
    public static class ParseUtils
    {

        public static decimal ParseDecimal(string value)
        {
            if (string.IsNullOrEmpty(value)) return 0m;
            return decimal.Parse(value, NumberStyles.Float, CultureInfo.InvariantCulture);
        }

        public static decimal? ParseNullableDecimal(string value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            return decimal.Parse(value, NumberStyles.Float, CultureInfo.InvariantCulture);
        }

        public static DateTime ParseUnixTimeStamp(long timestamp)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(timestamp).DateTime;
        }

        public static string ToStringInvariant(this decimal value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
