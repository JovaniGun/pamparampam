using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Models
{
    [Table("ClientPreferencesByCategory")]
    public class ClientPreferenceByCategory
    {
        [Key]
        public int PreferencesByCategoryId { get; set; }
        public int ClientId { get; set; }
        public int CategoryId { get; set; }
        public DateTime DateLastBuy { get; set; }
    }
}
