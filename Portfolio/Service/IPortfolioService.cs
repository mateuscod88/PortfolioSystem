using Portfolio.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service
{
    interface IPortfolioService
    {
        void Create(PortfolioModel portfolio);
        void Update(PortfolioModel portfolio);
        void Delete(PortfolioModel portfolio);
        IEnumerable<PortfolioModel> GetByISINAndDate(string ISIN, DateTime date);
        PortfolioModel GetLatestByISIN(string ISIN);

    }
}
