using CreditSuisse.CategorizeTrades.Business.Interface;
using CreditSuisse.CategorizeTrades.Entity;

namespace CreditSuisse.CategorizeTrades.Business.Rules
{
    public class TradeRiskMedium : ITradeRisk
    {
        public string CheckRisk(Trade trade)
        {
            if (trade.Value > 1000000 && trade.ClientSector == "Public")
            {
                return "MediumRisk";
            }

            return string.Empty;
        }
    }
}
