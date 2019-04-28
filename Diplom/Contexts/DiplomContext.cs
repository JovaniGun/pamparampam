using Diplom.Models;
using System.Data.Entity;

namespace Diplom.Contexts 
{
    public class DiplomContext : DbContext
    {
        public DiplomContext()
            :base("ISU_DB"){ }
        public DbSet<Client>    Clients    { get; set; }
        public DbSet<Gender>    Genders    { get; set; }
        public DbSet<Purchase>  Purchases  { get; set; } 
    }
}
