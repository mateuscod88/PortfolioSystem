using Portfolio.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service
{
    public interface IPortfolioAnaliticsService
    {
        IEnumerable<PortfolioAnaliticsModel> GetByISINAndDate(string ISIN, DateTime date);

    }
}
