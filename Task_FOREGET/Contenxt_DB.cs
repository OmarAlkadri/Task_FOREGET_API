using Microsoft.EntityFrameworkCore;
using Task_FOREGET.Models;

namespace Task_FOREGET
{
    public class Context_DB : DbContext
    {
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

        public DbSet<Users> Users { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<MovementType> MovementTypes { get; set; }
        public DbSet<Mode> Modes { get; set; }
        public DbSet<UnitFirst> UnitFirst { get; set; }
        public DbSet<SecondUnit> SecondUnit { get; set; }
        public DbSet<PackageType> PackageType { get; set; }
        public DbSet<Incoterms> Incoterms { get; set; }
        public DbSet<Currency> Currency { get; set; }
    }
}
