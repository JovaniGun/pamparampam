using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Models
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        public int Client_id        { get; set; }
        public string Family        { get; set; }
        public string Name          { get; set; }
        public string Patronymic    { get; set; }
        public int    Gender_id     { get; set; }
        public Gender Gender        { get; set; }
        public DateTime Birthday    { get; set; }
        public string Email         { get; set; }
        public string Phone         { get; set; }
        public int Consent          { get; set; }
        
    }
}
