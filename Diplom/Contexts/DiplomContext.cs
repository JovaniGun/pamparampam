using Diplom.Models;
using System.Data.Entity;

namespace Diplom.Contexts 
{
    public class DiplomContext : DbContext
    {
        public DiplomContext() : base("ISU_DB"){ }

        public DbSet<Client>    Clients     { get; set; }
        public DbSet<Gender>    Genders     { get; set; }
        public DbSet<Purchase>  Purchases   { get; set; } 
        public DbSet<Product>   Products    { get; set; }
        public DbSet<ClientPreferenceByProduct> ClientPreferencesByProduct { get; set; }
        public DbSet<ClientPreferenceByCategory> ClientPreferencesByCategory { get; set; }
        public DbSet<ClientPreferenceByManufacturer> ClientPreferencesByManufacturer { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

    }
}
