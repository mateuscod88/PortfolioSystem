using Entity.Context;
using Portfolio.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service
{
    public class PortfolioAnaliticsService
    {
        private readonly PortfolioContext _context;
        public PortfolioAnaliticsService(PortfolioContext context)
        {
            _context = context;
        }
        public IEnumerable<PortfolioAnaliticsModel> GetByISINAndDate(string ISIN, DateTime date)
        {
            return new List<PortfolioAnaliticsModel>();
            
        }
    }
}
