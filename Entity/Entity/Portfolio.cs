using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entity
{
    public class Portfolio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ISIN { get; set; }
        public DateTime Date { get; set; }
        //public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public float  MarketValue { get; set; }
                
    }
}
