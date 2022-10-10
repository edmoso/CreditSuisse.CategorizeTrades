using CreditSuisse.CategorizeTrades.Business.Interface;
using CreditSuisse.CategorizeTrades.Entity;
using System;

namespace CreditSuisse.CategorizeTrades.Business.Rules
{
    public class TradeRiskExpired : ITradeRisk
    {
        private readonly DateTime _referenceDate;
        public TradeRiskExpired(DateTime referenceDate)
        {
            _referenceDate = referenceDate;
        }

        public string CheckRisk(Trade trade)
        {
            if (_referenceDate.Subtract(trade.NextPaymentDate).TotalDays > 30)
            {
                return "Expired";
            }

            return string.Empty;
        }
    }
}
