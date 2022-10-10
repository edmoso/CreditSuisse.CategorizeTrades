using CreditSuisse.CategorizeTrades.Business.Interface;
using CreditSuisse.CategorizeTrades.Entity;

namespace CreditSuisse.CategorizeTrades.Business.Rules
{
    public class TradeRiskHigh : ITradeRisk
    {
        public string CheckRisk(Trade trade)
        {
            if (trade.Value > 1000000 && trade.ClientSector == "Private")
            {
                return "HighRisk";
            }

            return string.Empty;
        }
    }
}
