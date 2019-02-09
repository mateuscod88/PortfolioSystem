using System;

namespace Entity.Entity
{
    public class Position
    {
        public int Id { get; set; }
        public string ISIN { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public PositionType Type { get; set; }
        public int CountyId { get; set; }
        public Country Country { get; set; }
        public decimal SharePercentage { get; set; }
        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
    }
}
