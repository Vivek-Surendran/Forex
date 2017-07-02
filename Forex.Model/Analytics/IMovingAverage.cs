using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forex.Analytics
{

    public interface IMovingAverage
    {

        void Add(Model.Rate rate);
        
        ICollection<Model.Rate> Rates { get; }

        decimal Bid { get; }

        decimal Ask { get; }

    }

}
