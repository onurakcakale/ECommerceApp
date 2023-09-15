using EcommerceWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApi.Context
{
    public class ApplicationContext : DbContext
    {
        //All classes are defined here as DbSet.
        public DbSet<Product> products { get; set; }
        public DbSet<Categories> categories { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
