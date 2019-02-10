using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Model
{
    class PortfolioModel
    {
        public int Id { get; set; }
        public string ISIN { get; set; }
        public DateTime Date { get; set; }
        public int CurrencyId { get; set; }
        public string Currency { get; set; }
        public float MarketValue { get; set; }
        public List<PositionModel> Positions { get; set; }
    }
}
