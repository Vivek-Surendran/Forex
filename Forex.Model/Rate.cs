using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forex.Model
{
    public class Rate
    {

        public string CurrencyPair { get; set; }

        public DateTime RateDateTime { get; set; }

        public decimal Bid { get; set; }

        public decimal Ask { get; set; }

    }
}
