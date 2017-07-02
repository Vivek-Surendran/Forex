using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forex.Analytics
{
    public class Period
    {

        public int Unit { get; set; }

        public UnitType UnitType { get; set; }

        public TimeSpan Span
        {
            get
            {
                switch(UnitType)
                {
                    case UnitType.Seconds:
                        return new TimeSpan(0, 0, Unit);
                    case UnitType.Minutes:
                        return new TimeSpan(0, Unit, 0);
                    case UnitType.Hours:
                        return new TimeSpan(Unit, 0, 0);
                    default:
                        throw new InvalidOperationException("Error!  Invalid Span.");
                }
            }
        }

    }
}
