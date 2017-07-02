using System;
using System.Collections.Generic;
using System.Linq;
using Forex.Model;

namespace Forex.Analytics
{

    public class ExponentialMovingAverage : IMovingAverage
    {

        Queue<Model.Rate> _rates = new Queue<Rate>();

        #region Properties

        public decimal Bid
        {
            get
            {
                if (_rates.Count == 0) return 0;
                return Common.EMA(_rates.Select(X => X.Bid).ToArray(), SmootingFactor);
            }
        }

        public decimal Ask
        {
            get
            {
                if (_rates.Count == 0) return 0;
                return Common.EMA(_rates.Select(X => X.Ask).ToArray(), SmootingFactor);
            }
        }

        public ICollection<Model.Rate> Rates
        {
            get
            {
                return _rates.ToArray();
            }
        }

        int Count { get { return _rates.Count; } }

        decimal SmootingFactor
        {
            get
            {
                return 2m / (1 + Count);
            }
        }

        public Period AveragePeriod { get; set; }

        #endregion  

        public ExponentialMovingAverage(Period averagePeriod)
        {
            AveragePeriod = averagePeriod;
        }

        public void Add(Rate rate)
        {
            if(AveragePeriod.UnitType == UnitType.Count)
            {
                if(_rates.Count >= AveragePeriod.Unit)
                {
                    _rates.Dequeue();
                }
                _rates.Enqueue(rate);
            }
            else
            {
                if(_rates.Count >= 1)
                {
                    DateTime thisTime = rate.RateDateTime;
                    DateTime cutOffTime = thisTime.Subtract(AveragePeriod.Span);
                    while(_rates.Count()>=1 && _rates.Peek().RateDateTime <= cutOffTime )
                    {
                        _rates.Dequeue();
                    }
                }
                _rates.Enqueue(rate);
            }
        }

    }

}
