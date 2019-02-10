using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Model
{
    class PositionModel
    {
        public int Id { get; set; }
        public string ISIN { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public float MarketValue { get; set; }

        public string Name { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public float SharePercentage { get; set; }
        public int PortfolioId { get; set; }
    }
}
