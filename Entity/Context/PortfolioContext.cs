using System;
using Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Infrastructure;
namespace Entity.Context
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options)
        {
            
        }
        public PortfolioContext()
        {
            
        }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Currency> Currencys{ get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<PositionType> PositionTypes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Database=PortfolioDb;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Portfolio>().HasData(
            //        new Portfolio { ISIN = "GBB123123123", MarketValue = 0.00f },
            //        new Portfolio { ISIN = "GBB223123123", MarketValue = 0.00f },
            //        new Portfolio { ISIN = "GBB323123123", MarketValue = 0.00f },
            //        new Portfolio { ISIN = "GBB423123123", MarketValue = 0.00f },
            //        new Portfolio { ISIN = "GBB523123123", MarketValue = 0.00f }
            //    );
            //modelBuilder.Entity<Position>().HasData(
            //        new Position { ISIN = "GBA123123123", Name = "A", SharePercentage = 0 },
            //        new Position { ISIN = "GBA123123123", Name = "A", SharePercentage = 0 },
            //        new Position { ISIN = "GBA123123123", Name = "A", SharePercentage = 0 },
            //        new Position { ISIN = "GBA123123123", Name = "A", SharePercentage = 0 }
            //);
            modelBuilder.Entity<Portfolio>().HasOne(x => x.Currency).WithMany(b => b.Portfolio).OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<Currency>().HasData(
            //    new Currency { Name = "PLN" },
            //    new Currency { Name = "DKK" },
            //    new Currency { Name = "AUD" },
            //    new Currency { Name = "USD" },
            //    new Currency { Name = "XCD" },
            //    new Currency { Name = "MXV" }

            //    );

        }

    }
}
