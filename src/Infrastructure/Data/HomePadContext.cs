using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class HomePadContext : DbContext
    {
        public DbSet<AccountHead> AccountHeads { get; set; }
        public DbSet<Income> Incomes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=HomePadDB;Trusted_Connection=True;");
        }
    }

   
   

    
}
