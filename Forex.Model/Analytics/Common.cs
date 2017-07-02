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
            decimal outVal = 0;
            foreach(var item in items)
            {
                outVal = (item * factor) + outVal * (1 - factor);
            }
            return outVal;
        }

    }
}
