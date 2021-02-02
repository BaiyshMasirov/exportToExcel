using KeremetBank.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeremetBank.Data
{
    public class BankClientsContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public BankClientsContext(DbContextOptions<BankClientsContext> options)
            : base(options)
        {

        }
    }
}
