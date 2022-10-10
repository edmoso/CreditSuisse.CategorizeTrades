using System;

namespace CreditSuisse.CategorizeTrades.Entity.Interface
{
    interface ITrade
    {
        double Value { get; }
        string ClientSector { get; }
        DateTime NextPaymentDate { get; }
        //bool IsPoliticallyExposed { get; }
    }
}
