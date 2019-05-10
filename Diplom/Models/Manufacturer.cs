using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Models
{
    [Table("Manufacturers")]
    public class Manufacturer
    {
            [Key]
            public int          ManufacturerId      { get; set; }
            public string       ManufacturerName    { get; set; }
    }
}
