using CreditSuisse.CategorizeTrades.Business;
using CreditSuisse.CategorizeTrades.Entity;
using System;
using System.Collections.Generic;

namespace CreditSuisse.CategorizeTrades.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadParameters();

            var tradeRiskService = new TradeRiskService(Parameter.ReferenceDate);
            var risks = tradeRiskService.GetRisksByTrades(Parameter.Trades);

            foreach (var risk in risks)
            {
                Console.WriteLine(risk.ToUpper());
            }

            Console.ReadKey();
        }

        private static void ReadParameters()
        {
            try
            {
                //read the input parameters line by line
                string bufferReferenceDate = Console.ReadLine().TrimEnd();

                DateTime referenceDate;
                if (!DateTime.TryParse(bufferReferenceDate, out referenceDate))
                {
                    throw new Exception("Invalid DateTime was entered");
                }

                string bufferTradesCount = Console.ReadLine().TrimEnd();

                int tradesCount;
                if (!int.TryParse(bufferTradesCount, out tradesCount))
                {
                    throw new Exception("Invalid Trades Count was entered");
                }

                var trades = new List<Trade>();

                for (int i = 1; i <= tradesCount; i++)
                {
                    string bufferTrade = Console.ReadLine().TrimEnd();

                    if (bufferTrade.Length > 0)
                    {
                        string[] arrayTrade = bufferTrade.Split(' ');

                        if (arrayTrade.Length == 3)
                        {
                            trades.Add(new Trade
                            {
                                Value = Convert.ToDouble(arrayTrade[0]),
                                ClientSector = arrayTrade[1],
                                NextPaymentDate = DateTime.ParseExact(arrayTrade[2], "MM/dd/yyyy", null)
                            });
                        }
                    }
                }

                Parameter.ReferenceDate = referenceDate;
                Parameter.Trades = trades;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }

        private static class Parameter
        {
            public static DateTime ReferenceDate { get; set; } 
            public static IEnumerable<Trade> Trades { get; set; }
        }
    }
}
