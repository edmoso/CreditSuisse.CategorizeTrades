using CreditSuisse.CategorizeTrades.Business.Interface;
using CreditSuisse.CategorizeTrades.Business.Rules;
using CreditSuisse.CategorizeTrades.Entity;
using System;
using System.Collections.Generic;

namespace CreditSuisse.CategorizeTrades.Business
{
    public class TradeRiskService : ITradeRiskService
    {
        private IEnumerable<ITradeRisk> _risks;
        private readonly DateTime _referenceDate;
        public TradeRiskService(DateTime referenceDate)
        {
            _referenceDate = referenceDate;
            _risks = new List<ITradeRisk>
            {
                //new TradeRiskPEP(),
                new TradeRiskExpired(_referenceDate),
                new TradeRiskMedium(),
                new TradeRiskHigh(),
            };
        }

        private string GetRisk(Trade trade)
        {
            foreach (var risk in _risks)
            {
                var riskDescription = risk.CheckRisk(trade);

                if (riskDescription != string.Empty)
                {
                    return riskDescription;
                }
            }

            return "NoRisk";
        }

        public IEnumerable<string> GetRisksByTrades(IEnumerable<Trade> trades)
        {
            var results = new List<string>();

            foreach (var trade in trades)
            {
                results.Add(GetRisk(trade));
            }

            return results;
        }
    }
}
