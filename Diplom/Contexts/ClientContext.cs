using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Models;
using System.Data.Entity;

namespace Diplom.Contexts 
{
    class ClientContext : DbContext
    {
        public ClientContext()
            :base("ISU_DB"){ }
        public DbSet<Client> Clients { get; set; }
    }
}
