using Entity.Context;
using Entity.Entity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Seed
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<PortfolioContext>();
            context.Database.EnsureCreated();
            if (!context.Portfolios.Any())
            {
                var currencys = context.Currencys.ToList();
                var portfolios = new List<Portfolio>
                {
                    new Portfolio { Currency = currencys.FirstOrDefault(x => x.Name == "PLN"),Date = DateTime.Now, ISIN = "GBB123123123", MarketValue = 0.00f },
                    new Portfolio { Currency = currencys.FirstOrDefault(x => x.Name == "PLN"), Date = DateTime.Now, ISIN = "GBC123123123", MarketValue = 0.00f },
                    new Portfolio { Currency = currencys.FirstOrDefault(x => x.Name == "PLN"), Date = DateTime.Now, ISIN = "GBD123123123", MarketValue = 0.00f }
                };
                context.AddRange(portfolios);
                context.SaveChanges();
                var savedPortfolios = context.Portfolios.ToList();
                var countrys = context.Countrys.ToList();
                var positions = new List<Position>
                {
                    new Position { ISIN = "GBA123123123", Name = "A", SharePercentage = 0, MarketValue = 10 ,TypeId = 1,CurrencyId = 1,Portfolio=savedPortfolios.FirstOrDefault(x => x.ISIN == "GBB123123123"),Country = countrys.FirstOrDefault(x => x.Name == "PL")},
                    new Position { ISIN = "GBC123123123", Name = "B", SharePercentage = 0, MarketValue = 20 ,TypeId = 1,CurrencyId = 1,Portfolio=savedPortfolios.FirstOrDefault(x => x.ISIN == "GBB123123123"),Country = countrys.FirstOrDefault(x => x.Name == "PL")},
                    new Position { ISIN = "GBD123123123", Name = "C", SharePercentage = 0, MarketValue = 40 ,TypeId = 1,CurrencyId = 1,Portfolio=savedPortfolios.FirstOrDefault(x => x.ISIN == "GBB123123123"),Country = countrys.FirstOrDefault(x => x.Name == "PL")},
                    new Position { ISIN = "GBB123123123", Name = "D", SharePercentage = 0, MarketValue = 80 ,TypeId = 1,CurrencyId = 1,Portfolio=savedPortfolios.FirstOrDefault(x => x.ISIN == "GBB123123123"),Country = countrys.FirstOrDefault(x => x.Name == "PL")},

                    new Position { ISIN = "GBG123123123", Name = "A", SharePercentage = 0, MarketValue = 10 ,TypeId = 1,CurrencyId = 1,Portfolio=savedPortfolios.FirstOrDefault(x => x.ISIN == "GBC123123123"),Country = countrys.FirstOrDefault(x => x.Name == "PL") },
                    new Position { ISIN = "GBH123123123", Name = "B", SharePercentage = 0, MarketValue = 20 ,TypeId = 1,CurrencyId = 1,Portfolio=savedPortfolios.FirstOrDefault(x => x.ISIN == "GBC123123123"),Country = countrys.FirstOrDefault(x => x.Name == "PL") },
                    new Position { ISIN = "GBI123123123", Name = "C", SharePercentage = 0, MarketValue = 40 ,TypeId = 1,CurrencyId = 1,Portfolio=savedPortfolios.FirstOrDefault(x => x.ISIN == "GBC123123123"),Country = countrys.FirstOrDefault(x => x.Name == "PL") },
                    new Position { ISIN = "GBJ123123123", Name = "D", SharePercentage = 0, MarketValue = 80 ,TypeId = 1,CurrencyId = 1,Portfolio=savedPortfolios.FirstOrDefault(x => x.ISIN == "GBC123123123"),Country = countrys.FirstOrDefault(x => x.Name == "PL") },

                    new Position { ISIN = "GBK123123123", Name = "A", SharePercentage = 0, MarketValue = 10 ,TypeId = 1,CurrencyId = 1,Portfolio=savedPortfolios.FirstOrDefault(x => x.ISIN == "GBD123123123"),Country = countrys.FirstOrDefault(x => x.Name == "PL") },
                    new Position { ISIN = "GBL123123123", Name = "B", SharePercentage = 0, MarketValue = 20 ,TypeId = 1,CurrencyId = 1,Portfolio=savedPortfolios.FirstOrDefault(x => x.ISIN == "GBD123123123"),Country = countrys.FirstOrDefault(x => x.Name == "PL") },
                    new Position { ISIN = "GBM123123123", Name = "C", SharePercentage = 0, MarketValue = 40 ,TypeId = 1,CurrencyId = 1,Portfolio=savedPortfolios.FirstOrDefault(x => x.ISIN == "GBD123123123"),Country = countrys.FirstOrDefault(x => x.Name == "PL") },
                    new Position { ISIN = "GBN123123123", Name = "D", SharePercentage = 0, MarketValue = 80 ,TypeId = 1,CurrencyId = 1,Portfolio=savedPortfolios.FirstOrDefault(x => x.ISIN == "GBD123123123"),Country = countrys.FirstOrDefault(x => x.Name == "PL") }
                };
                context.Positions.AddRange(positions);
                context.SaveChanges();
                var savedPositions = context.Positions.ToList();
                foreach (var portfolio in savedPortfolios)
                {
                    var positionsMarketValueSum = context.Positions.Where(y => y.Portfolio.ISIN == portfolio.ISIN).Sum(x => x.MarketValue);
                    foreach(var savedPosition in savedPositions)
                    {
                        savedPosition.SharePercentage = (savedPosition.MarketValue * 100.00f)/positionsMarketValueSum;
                    }
                    portfolio.MarketValue = positionsMarketValueSum;
                }
                context.SaveChanges();

            }
        }
    }
}
