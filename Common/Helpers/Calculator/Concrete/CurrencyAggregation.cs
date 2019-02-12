using Common.Helpers.Calculator.Interfaces;
using Entity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Helpers.Calculator.Concrete
{
    public class CurrencyAggregation : IAgregationCalculation
    {
        private PortfolioContext _context;
        public CurrencyAggregation( PortfolioContext context)
        {
            this._context = context;
        }
        public Dictionary<string, float> DoCalculation(string ISIN, DateTime date)
        {
            var positionCurrencysGrouped = _context.Positions.Where(x => x.Portfolio.ISIN == ISIN && x.Portfolio.Date.Day == date.Day && x.Portfolio.Date.Month == date.Month && x.Portfolio.Date.Year == date.Year)
                                                             .GroupBy(y => y.Currency)
                                                             .Select(x => new { Metric = x.Key, Count = x.Count() })
                                                             .ToList();
            var sumOfAllCurrencys = positionCurrencysGrouped.Sum(x => x.Count);

            var currencysAggregation = new Dictionary<string, float>();
            foreach (var currency in positionCurrencysGrouped)
            {
                var percentage = (currency.Count * 100) / sumOfAllCurrencys;
                currencysAggregation.Add(currency.Metric.Name, percentage);
            }

            return currencysAggregation;
        }
    }
}
