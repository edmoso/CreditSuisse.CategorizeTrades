using CreditSuisse.CategorizeTrades.Entity;

namespace CreditSuisse.CategorizeTrades.Business.Interface
{
    public interface ITradeRisk
    {
        string CheckRisk(Trade trade);
    }
}
