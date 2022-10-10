using CreditSuisse.CategorizeTrades.Entity.Interface;
using System;

namespace CreditSuisse.CategorizeTrades.Entity
{
    public class Trade : ITrade
    {
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public DateTime NextPaymentDate { get; set; }
        //public bool IsPoliticallyExposed { get; set; }
    }
}
