using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entity
{
    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ISIN { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public float MarketValue { get; set; }

        public string Name { get; set; }
        public int TypeId { get; set; }
        public PositionType Type { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public float SharePercentage { get; set; }
        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
    }
}
