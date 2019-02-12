using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Model
{
    public class PortfolioAnaliticsModel
    {
        public Dictionary<string,float> Currencys { get; set; }
        public Dictionary<string,float> Countrys { get; set; }
        public Dictionary<string, float> PositionTypes{ get; set; }

    }
}
