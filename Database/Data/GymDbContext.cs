using Azure;
using Database.AdditionalRelations;
using Database.Entities;
using Database.JoinTables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.Metrics;

namespace Database.Data
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Administrator> Administraotrs { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<PackageDiscount> PackageDiscounts { get; set; }
        public virtual DbSet<PackagePrice> PackagePrices { get; set; }
        public virtual DbSet<PackageAdministrator> PackageAdministrators { get; set; }
        public virtual DbSet<TokenPrice> TokenPrices { get; set; }
        public virtual DbSet<PackagePackageDiscount> PackagePackageDiscounts { get; set; }
        public virtual DbSet<Membership> Memberships { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>().HasData(
                new Administrator (1, 1001997800095, 0613618201, "admin", "admin", Enums.Gender.Male,"nenad.suknovic@gmail.com", "Suknovic", "Nenad")
                );


            modelBuilder.Entity<PackagePrice>()
                .HasOne(m => m.Administrator)
                .WithMany(p => p.PackagePrices)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PackagePrice>()
                .HasOne(m => m.Package)
                .WithMany(p => p.PackagePrices)
                .OnDelete(DeleteBehavior.Restrict);

            /*
            modelBuilder.Entity<PackageAdministrator>()
            .HasOne(a => a.Package)
            .WithOne(a => a.PackageAdministrator)
            .HasForeignKey<Package>(c => c.PackageAdministratorId);
            */

            modelBuilder.Entity<PackageAdministrator>()
            .HasOne(a => a.Package)
            .WithMany(a => a.PackageAdministrators)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PackageAdministrator>()
            .HasOne(a => a.Administrator)
            .WithMany(a => a.PackageAdministrators)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PackagePackageDiscount>()
                .HasOne(m => m.Package)
                .WithMany(p => p.PackagePackageDiscounts)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PackagePackageDiscount>()
                .HasOne(m => m.PackageDiscount)
                .WithMany(p => p.PackagePackageDiscounts)
                .OnDelete(DeleteBehavior.Restrict);

            //EMPLOYEE
            modelBuilder.Entity<Payment>()
                .HasOne(m => m.Client)
                .WithMany(p => p.Payments)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(m => m.Client)
                .WithMany(p => p.Payments)
                .OnDelete(DeleteBehavior.Restrict);

            //CLIENT
            modelBuilder.Entity<Membership>()
                .HasOne(m => m.Package)
                .WithMany(p => p.Memberships)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Membership>()
                .HasOne(m => m.Client)
                .WithMany(p => p.Memberships)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
