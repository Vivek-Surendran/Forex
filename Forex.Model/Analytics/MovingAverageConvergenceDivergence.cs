using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forex.Analytics
{

    public class MovingAverageConvergenceDivergence
    {

        ExponentialMovingAverage _ema1, _ema2, _signal;

        #region Properties

        public decimal Bid
        {
            get
            {
                return (MACDLineBid - _signal.Bid)*1000;
            }
        }

        public decimal Ask
        {
            get
            {
                return (MACDLineAsk - _signal.Ask)*1000;
            }
        }

        #endregion  

        decimal MACDLineBid
        {
            get { return _ema1.Bid - _ema2.Bid; }
        }

        decimal MACDLineAsk
        {
            get { return _ema1.Ask - _ema2.Ask; }
        }

        public MovingAverageConvergenceDivergence(Period macdLinePeriod1, Period macdLinePeriod2, Period signalLinePeriod)
        {
            _ema1 = new ExponentialMovingAverage(macdLinePeriod1);
            _ema2 = new ExponentialMovingAverage(macdLinePeriod2);
            _signal = new ExponentialMovingAverage(signalLinePeriod);
        }

        public void Add(Model.Rate rate)
        {
            _ema1.Add(rate);
            _ema2.Add(rate);
            _signal.Add(new Model.Rate() { Bid = MACDLineBid, Ask = MACDLineAsk, CurrencyPair = rate.CurrencyPair, RateDateTime = rate.RateDateTime } );
        }

    }

}
