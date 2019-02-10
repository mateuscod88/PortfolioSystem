using Portfolio.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service
{
    public interface IPortfolioService
    {
        void Create(PortfolioModel portfolio);
        void Update(string ISIN, PortfolioModel portfolioModel);
        void Delete(PortfolioModel portfolio);
        IEnumerable<PortfolioModel> GetByISINAndDate(string ISIN, DateTime date);
        PortfolioModel GetLatestByISIN(string ISIN);
        PortfolioModel GetByISIN(string ISIN);
    }
}
