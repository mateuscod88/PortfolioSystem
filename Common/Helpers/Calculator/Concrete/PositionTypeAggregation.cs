using Common.Helpers.Calculator.Interfaces;
using Entity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Helpers.Calculator.Concrete
{
    public class PositionTypeAggregation : IAgregationCalculation
    {
        private PortfolioContext _context;
        public PositionTypeAggregation(PortfolioContext context)
        {
            this._context = context;
        }
        public Dictionary<string, float> DoCalculation(string ISIN, DateTime date)
        {
            var positionTypesGrouped = _context.Positions.Where(x => x.Portfolio.ISIN == ISIN && x.Portfolio.Date.Day == date.Day && x.Portfolio.Date.Month == date.Month && x.Portfolio.Date.Year == date.Year)
                                                         .GroupBy(y => y.Type)
                                                         .Select(x => new { Metric = x.Key, Count = x.Count() })
                                                         .ToList();

            var sumOfAllPositionType = positionTypesGrouped.Sum(x => x.Count);

            var typesAggregation = new Dictionary<string, float>();
            foreach (var positionType in positionTypesGrouped)
            {
                var percentage = (positionType.Count * 100) / sumOfAllPositionType;
                typesAggregation.Add(positionType.Metric.Name, percentage);
            }
            return typesAggregation;
        }
    }
}
