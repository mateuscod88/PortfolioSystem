using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portfolio.Model
{
    public class PositionModel
    {
        public int Id { get; set; }
        [MaxLength(12)]
        public string ISIN { get; set; }
        public int CurrencyId { get; set; }
        [Required]
        public string CurrencyName { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "Please enter valid float Number")]
        [Required]
        public float MarketValue { get; set; }

        public string Name { get; set; }
        public int TypeId { get; set; }
        [Required]
        public string TypeName { get; set; }
        public int CountryId { get; set; }
        [Required]
        public string CountryName { get; set; }
        public float SharePercentage { get; set; }
        public int PortfolioId { get; set; }
    }
}
