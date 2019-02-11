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
            modelBuilder.Entity<Portfolio>().HasOne(x => x.Currency)
                                            .WithMany(b => b.Portfolio)
                                            .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Currency>().HasData(
                new Currency { Id = 1, Name = "PLN" },
                new Currency { Id = 2, Name = "DKK" },
                new Currency { Id = 3, Name = "AUD" },
                new Currency { Id = 4, Name = "USD" },
                new Currency { Id = 5, Name = "XCD" },
                new Currency { Id = 6, Name = "MXV" }

                );
            modelBuilder.Entity<PositionType>().HasData(
                new PositionType{ Id = 1, Name = "Fund"  },
                new PositionType{ Id = 2, Name = "Share" },
                new PositionType{ Id = 3, Name = "Bond"  },
                new PositionType{ Id = 4, Name = "Cash"  },
                new PositionType{ Id = 5, Name = "Other" }
                );              
            modelBuilder.Entity<Country>().HasData(
                new Country{ Id = 1, Name = "PL" },
                new Country{ Id = 2, Name = "DK" },
                new Country{ Id = 3, Name = "IR" },
                new Country{ Id = 4, Name = "KZ" },
                new Country{ Id = 5, Name = "ES" }
                );           


        }

    }
}
