using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forex.Analytics
{
    static class Common
    {

        public static decimal EMA(decimal[] items, decimal factor)
        {
            decimal outVal = items.Average();
            foreach(var item in items)
            {
                outVal = (item - outVal) * factor + outVal;
            }
            return outVal;
        }

    }
}
