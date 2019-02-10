
using Entity.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Model;

namespace Portfolio.Service
{
    class PortfolioService
    {
        private readonly PortfolioContext _context;
        public PortfolioService(PortfolioContext context)
        {
            _context = context;
        }
        void Create(PortfolioModel portfolioModel)
        {
            var portfolio = _context.Portfolios.FirstOrDefault(x => x.ISIN == portfolioModel.ISIN);
            if (portfolio == null)
            {
                var currency = _context.Currencys.FirstOrDefault(x => x.Name == portfolioModel.Currency);

                var portfolioToAdd = new Entity.Entity.Portfolio { ISIN = portfolioModel.ISIN, MarketValue = portfolioModel.MarketValue, Date = portfolioModel.Date, Currency = currency };
                _context.Portfolios.Add(portfolioToAdd);

                if (portfolioModel.Positions.Count > 0)
                {
                    var countrys = _context.Countrys.ToList();
                    var currencys = _context.Currencys.ToList();
                    var positionTypes = _context.PositionTypes.ToList();
                    List<Entity.Entity.Position> positions = new List<Entity.Entity.Position>();
                    foreach (var position in portfolioModel.Positions)
                    {
                        positions.Add(new Entity.Entity.Position { ISIN = position.ISIN, Country = countrys.FirstOrDefault(x => x.Name == position.CountryName), Name = position.Name, MarketValue = position.MarketValue, Currency = currencys.FirstOrDefault(x => x.Name == position.CurrencyName), Type = positionTypes.FirstOrDefault(x => x.Name == position.TypeName), PortfolioId = portfolioToAdd.Id });
                    }
                }
                _context.SaveChangesAsync();
            }
        }
        void Update(string ISIN , PortfolioModel portfolioModel)
        {
            var portfolio = _context.Portfolios.FirstOrDefault(x => x.ISIN == ISIN);
            if(portfolio != null)
            {
                portfolio.ISIN = portfolioModel.ISIN;
                portfolio.MarketValue = portfolioModel.MarketValue;
                portfolio.Date = portfolioModel.Date != portfolio.Date ? portfolioModel.Date : portfolio.Date;
                portfolio.Currency = portfolioModel.CurrencyId != portfolio.Currency.Id ? _context.Currencys.FirstOrDefault(x => x.Id == portfolioModel.CurrencyId) : portfolio.Currency;
                _context.SaveChangesAsync();
            }
        }
        void Delete(PortfolioModel portfolioModel)
        {
            var portfolio = _context.Portfolios.FirstOrDefault(x => x.ISIN == portfolioModel.ISIN);
            if(portfolio != null)
            {
                _context.Portfolios.Remove(portfolio);
                _context.SaveChangesAsync();
            }
            
        }
        IEnumerable<PortfolioModel> GetByISINAndDate(string ISIN, DateTime date)
        {
            return _context.Portfolios.Select(x => new PortfolioModel { Id = x.Id, ISIN = x.ISIN, MarketValue = x.MarketValue, Currency = x.Currency.Name})
                                      .Where(y => y.ISIN == ISIN && y.Date.Day == date.Day &&  y.Date.Month == date.Month && y.Date.Year == date.Year)
                                      .ToList();
        }
        PortfolioModel GetLatestByISIN(string ISIN)
        {
            return _context.Portfolios.Select(x => new PortfolioModel { Id = x.Id, ISIN = x.ISIN, MarketValue = x.MarketValue, Currency = x.Currency.Name })
                                      .OrderByDescending( y => y.Date)
                                      .FirstOrDefault();
        }
    }
}
