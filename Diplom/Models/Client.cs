using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Contexts;
using System.Data.Entity;
namespace Diplom.Models
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        public int      ClientId    { get; set; }
        public string   Family      { get; set; }
        public string   Name        { get; set; }
        public string   Patronymic  { get; set; }
        public string   GenderId    { get; set; }
        public DateTime Birthday    { get; set; }
        public string   Email       { get; set; }
        public string   Phone       { get; set; }
        public bool     Consent     { get; set; }

        public List<Purchase> getPurchases(){
            var context = new DiplomContext();
            return context.Purchases.Where(p => p.ClientId == ClientId).ToList();
        }
        
    }
}
