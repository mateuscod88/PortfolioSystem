using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portfolio.Model
{
    public class PortfolioModel
    {
        public int Id { get; set; }
        [MaxLength(12)]
        public string ISIN { get; set; }
        public DateTime Date { get; set; }
        public int CurrencyId { get; set; }
        [Required]
        public string Currency { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "Please enter valid float Number")]
        public float MarketValue { get; set; }
        public List<PositionModel> Positions { get; set; }
    }
    
}
