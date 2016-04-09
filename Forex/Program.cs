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
                            Repository.Rate.SaveRate(rate);
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
