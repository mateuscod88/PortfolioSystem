using Common.Helpers;
using Common.Helpers.Calculator.Concrete;
using Entity.Context;
using Portfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Service
{
    public class PortfolioAnaliticsService : IPortfolioAnaliticsService
    {
        private readonly PortfolioContext _context;
        public PortfolioAnaliticsService(PortfolioContext context)
        {
            _context = context;
        }
        public PortfolioAnaliticsModel GetByISINAndDate(string ISIN, DateTime date)
        {

            var portfolioAnaliticsModel = new PortfolioAnaliticsModel();
            
            var aggregationCalculator = new AgregationCalculator(new CurrencyAggregation(this._context));
            portfolioAnaliticsModel.Currencys =  aggregationCalculator.Calculate(ISIN, date);

            aggregationCalculator.SetCalculation(new CountryAggregation(this._context));
            portfolioAnaliticsModel.Countrys = aggregationCalculator.Calculate(ISIN, date);

            aggregationCalculator.SetCalculation(new PositionTypeAggregation(this._context));
            portfolioAnaliticsModel.PositionTypes = aggregationCalculator.Calculate(ISIN, date);

            return portfolioAnaliticsModel;
            
        }
    }
}
