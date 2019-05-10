using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Models
{
    [Table("ClientPreferencesByProduct")]
    public class ClientPreferenceByProduct
    {
        [Key]
        public int      PreferencesByProductId   { get; set; }
        public int      ClientId                 { get; set; }
        public int      ProductId                { get; set; }
        public DateTime DateLastBuy              { get; set; }

    }
}
