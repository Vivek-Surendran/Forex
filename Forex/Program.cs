using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Forex
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str;
            for (int i = 2; i <= 5; i++)
            {
                using (StreamReader stream = File.OpenText(@"EUR_USD_Week"+i+".csv"))
                {
                    try
                    {
                        Analytics.ExponentialMovingAverage ema = new Analytics.ExponentialMovingAverage(new Analytics.Period() { Unit = 30, UnitType = Analytics.UnitType.Count });
                        Analytics.SimpleMovingAverage sma = new Analytics.SimpleMovingAverage(new Analytics.Period() { Unit = 30, UnitType = Analytics.UnitType.Count });
                        Analytics.MovingAverageConvergenceDivergence macd = new Analytics.MovingAverageConvergenceDivergence(new Analytics.Period() { Unit = 120, UnitType = Analytics.UnitType.Count }
                                                                                                                            , new Analytics.Period() { Unit = 260, UnitType = Analytics.UnitType.Count }
                                                                                                                            , new Analytics.Period() { Unit = 90, UnitType = Analytics.UnitType.Count });
                        stream.ReadLine();
                        do
                        {
                            str = stream.ReadLine().Split(",".ToCharArray());
                            Model.Rate rate = new Model.Rate();
                            rate.CurrencyPair = str[2];
                            rate.RateDateTime = DateTime.Parse(str[3]);
                            rate.Bid = decimal.Parse(str[4]);
                            rate.Ask = decimal.Parse(str[5]);
                            //Console.WriteLine(stream.ReadLine());
                            //Repository.Rate.SaveRate(rate);
                            ema.Add(rate);
                            sma.Add(rate);
                            macd.Add(rate);
                            Console.Write("Bid: {0:0.0000} \tMACD: {1:0.0000} \n", rate.Bid, macd.Bid);
                        } while (!stream.EndOfStream);
                    }
                    catch (Exception ex)
                    { Console.WriteLine(ex.ToString()); }
                    stream.Close();
                }
            }
            Console.WriteLine("Done!");
            Console.ReadKey();
        }

    }
}
