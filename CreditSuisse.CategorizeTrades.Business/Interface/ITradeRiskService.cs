using CreditSuisse.CategorizeTrades.Entity;
using System.Collections.Generic;

namespace CreditSuisse.CategorizeTrades.Business.Interface
{
    public interface ITradeRiskService
    {
        IEnumerable<string> GetRisksByTrades(IEnumerable<Trade> trades);
    }
}
