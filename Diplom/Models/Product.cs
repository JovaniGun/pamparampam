using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Diplom.Contexts;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Diplom.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public byte CategoryId { get; set; }
        public string Articul { get; set; }
        public byte UnitId { get; set; }
        public int ManufacturerId { get; set; }

        public ProductCategory getCategory()
        {
            var context = new DiplomContext();
            return context.ProductCategories.Where(p => p.CategoryId == CategoryId).ToList().First();
        }
        public Manufacturer getManufacturer()
        {
            var context = new DiplomContext();
            return context.Manufacturers.Where(m => m.ManufacturerId == ManufacturerId).ToList().First();
        }
    }
}
