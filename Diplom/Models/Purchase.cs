using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom.Models
{
    [Table("Purchases")]
    public class Purchase
    {
        [Key]
        public int          PurchaseId      { get; set; }
        public int          ClientId        { get; set; }
        public int          ProductId       { get; set; }
        public double Count_product { get; set; }
        public DateTime     Date_purchase   { get; set; }
    }
}
