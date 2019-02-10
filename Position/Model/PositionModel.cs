using System;
using System.Collections.Generic;
using System.Text;

namespace Position.Model
{
    class PositionModel
    {
        public int Id { get; set; }
        public string ISIN { get; set; }
        public int CurrencyId { get; set; }
        public string Currency { get; set; }
        public float MarketValue { get; set; }

        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public int CountyId { get; set; }
        public string Country { get; set; }
        public float SharePercentage { get; set; }
        public int PortfolioId { get; set; }
    }
}
