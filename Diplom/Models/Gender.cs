using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Models
{
    [Table("Genders")]
    public class Gender
    {
        [Key]
        public int            Gender_id   { get; set; }
        public string         Gender_name { get; set; }
        public List<Client>   Client      { get; set; }
    }
}
