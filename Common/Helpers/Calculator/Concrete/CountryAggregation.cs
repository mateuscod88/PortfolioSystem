using Common.Helpers.Calculator.Interfaces;
using Entity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Helpers.Calculator.Concrete
{
    public class CountryAggregation : IAgregationCalculation
    {
        private PortfolioContext _context;
        public CountryAggregation(PortfolioContext context)
        {
            this._context = context;
        }
        public Dictionary<string, float> DoCalculation(string ISIN, DateTime date)
        {
            var positionCountrysGrouped = _context.Positions.Where(x => x.Portfolio.ISIN == ISIN && x.Portfolio.Date.Day == date.Day && x.Portfolio.Date.Month == date.Month && x.Portfolio.Date.Year == date.Year)
                                                            .GroupBy(y => y.Country)
                                                            .Select(x => new { Metric = x.Key, Count = x.Count() })
                                                            .ToList();

            var sumOfAllCountrys = positionCountrysGrouped.Sum(x => x.Count);

            var countrysAggregation = new Dictionary<string, float>();
            foreach (var country in positionCountrysGrouped)
            {
                var percentage = (country.Count * 100) / sumOfAllCountrys;
                countrysAggregation.Add(country.Metric.Name, percentage);
            }
            return countrysAggregation;
        }
    }
}
