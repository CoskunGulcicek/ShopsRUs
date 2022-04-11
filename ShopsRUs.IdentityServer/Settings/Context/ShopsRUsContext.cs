using Microsoft.EntityFrameworkCore;
using ShopsRUs.IdentityServer.Models;
using ShopsRUs.IdentityServer.Settings.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.IdentityServer.Settings.Context
{
    public class ShopsRUsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ShopsRUsIdentityDB;Trusted_Connection=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserMap());
        }
        public DbSet<AppUser> AppUsers { get; set; }


    }
}
