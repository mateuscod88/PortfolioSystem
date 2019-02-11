using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Model
{
    public class PortfolioAnaliticsModel
    {
        public IEnumerable<CurrencyModel> Currencys { get; set; }
        public IEnumerable<CountryModel> Countrys { get; set; }
        public IEnumerable<PositionTypeModel> PositionTypes{ get; set; }

    }
}
