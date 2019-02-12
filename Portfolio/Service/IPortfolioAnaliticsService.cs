using Portfolio.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service
{
    public interface IPortfolioAnaliticsService
    {
        PortfolioAnaliticsModel GetByISINAndDate(string ISIN, DateTime date);

    }
}
