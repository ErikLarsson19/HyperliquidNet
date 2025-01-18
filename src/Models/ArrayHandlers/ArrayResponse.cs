using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperliquidNet.src.Models.ArrayHandlers
{
    public class ArrayResponse<T1, T2>
    {
        public T1 First { get; set; }
        public T2 Second { get; set; }
    }
}
