using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Models
{
    [Table("ProductCategories")]
    public class ProductCategory
    {
        [Key]
        public byte CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
