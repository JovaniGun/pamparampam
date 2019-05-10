using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Models
{
    [Table("ClientPreferencesByManufacturer")]
    public class ClientPreferenceByManufacturer
    {
        [Key]
        public int PreferencesByManufacturerId { get; set; }
        public int ClientId { get; set; }
        public int ManufacturerId { get; set; }
        public DateTime DateLastBuy { get; set; }
    }
}
