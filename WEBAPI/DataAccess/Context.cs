using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI.Entities;

namespace WEBAPI.DataAccess
{
    public class Context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-AQCSOUN\MSSQLSERVER19;Database=Northwind; Trusted_Connection = True;");
        
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category>  Categories{ get; set; }

    }
}
