using System;

namespace Entity.Entity
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string ISIN { get; set; }
        public DateTime Date { get; set; }
        //public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public float  MarketValue { get; set; }
                
    }
}
