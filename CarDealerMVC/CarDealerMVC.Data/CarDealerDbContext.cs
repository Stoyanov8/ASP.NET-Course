using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CarDealerMVC.Entities;

namespace CarDealerMVC.Data
{
    public class CarDealerDbContext : IdentityDbContext<User>
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<PartCars> PartCars { get; set; }
        

        public CarDealerDbContext(DbContextOptions<CarDealerDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PartCars>()
               .HasOne(x => x.Part)
               .WithMany(a => a.Cars)
                .HasForeignKey(x => x.PartId);

            builder.Entity<PartCars>()
               .HasOne(x => x.Car)
               .WithMany(a => a.Parts)
               .HasForeignKey(a => a.CarId);

            builder.Entity<PartCars>()
                .HasKey(x => new { x.CarId, x.PartId });

            builder.Entity<Car>()
                .HasOne(x => x.Sale)
                .WithOne(x => x.Car)
                .HasForeignKey<Car>(x => x.SaleId);

            builder.Entity<Sale>()
                .HasOne(x => x.Customer)
                .WithMany(x => x.Sales)
                .HasForeignKey(x => x.CustomerId);

            builder.Entity<Supplier>()
                .HasMany(x => x.Parts)
                .WithOne(x => x.Supplier)
                .HasForeignKey(x => x.SuplierId);
        }
    }
}