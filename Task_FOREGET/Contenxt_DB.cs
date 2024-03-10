using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Emit;
using System.Security.Policy;
using Task_FOREGET.Models;
using Task_FOREGET.ViewModels;

namespace Task_FOREGET
{
    public class Context_DB : DbContext
    {
        public DbSet<Users> User { get; set; }
        public DbSet<Shipments> Shipment { get; set; }

        public Context_DB()
        {

        }

        public Context_DB(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context_DB).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;database=foregetDB;user=admin;password=admin");
            }
        }
    }
}
