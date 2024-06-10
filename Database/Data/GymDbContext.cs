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
        public virtual DbSet<PersonalToken> PersonalTokens { get; set; }
        public virtual DbSet<ClientPersonalToken> ClientPersonalTokens { get; set; }
        public virtual DbSet<GroupToken> GroupTokens { get; set; }
        public virtual DbSet<ClientGroupToken> ClientGroupTokens { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<TokenPurchase> TokenPurchases { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<TokenPackage> TokenPackages { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<SignUpForTraining> SignUpsForTraining { get; set; }
        public virtual DbSet<SignOutFromTraining> SignOutsFromTraining { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Response> Responses { get; set; }
        public virtual DbSet<ClientRequest> ClientRequests { get; set; }
        public virtual DbSet<TrainerTrainingSignOut> TrainerTrainingSignOuts { get; set; }
        public virtual DbSet<TrainerTrainingSignUp> TrainerTrainingSignUps { get; set; }
        public virtual DbSet<Training> Trainings { get; set; }
        public virtual DbSet<GroupTraining> GroupTrainings { get; set; }
        public virtual DbSet<PersonalTraining> PersonalTrainings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>().HasData(
                new Administrator (1, 1001997800095, 0613618201, "admin", "admin", Enums.Gender.Male,"nenad.suknovic@gmail.com", "Suknovic", "Nenad")
                );

            modelBuilder.Entity<Token>().HasData(
                new Token (1, Enums.Category.Personal),
                new Token (2, Enums.Category.Group)
                );

            modelBuilder.Entity<Package>().HasData(
                new Package (1, "Silver", 1),
                new Package (2, "Gold", 1),
                new Package (3, "Premium", 1)
                );

            modelBuilder.Entity<PackagePrice>().HasData(
                new PackagePrice (1, 3000, DateTime.Now, 1, 1),
                new PackagePrice (2, 4500, DateTime.Now, 1, 2),
                new PackagePrice (3, 8000, DateTime.Now, 1, 3)
                );

            modelBuilder.Entity<TokenPackage>().HasData(
                new TokenPackage (1, 0, 1, 1),
                new TokenPackage (2, 0, 1, 1),
                new TokenPackage (3, 10, 2, 2),
                new TokenPackage (4, 0, 1, 2),
                new TokenPackage (5, 10, 1, 3),
                new TokenPackage (6, 10, 2, 3)
                );

            modelBuilder.Entity<TokenPrice>().HasData(
                new TokenPrice (1, 1000, DateTime.Now, 1, 1),
                new TokenPrice (2, 500, DateTime.Now, 1, 2)
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

            modelBuilder.Entity<TokenPrice>()
                .HasOne(m => m.Token)
                .WithMany(p => p.TokenPrices)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TokenPrice>()
                .HasOne(m => m.Administrator)
                .WithMany(p => p.TokenPrices)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TokenPackage>()
                .HasOne(m => m.Package)
                .WithMany(p => p.TokenPackages)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TokenPackage>()
                .HasOne(m => m.Token)
                .WithMany(p => p.TokenPackages)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClientPersonalToken>()
                .HasOne(m => m.Client)
                .WithMany(p => p.ClientPersonalTokens)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClientPersonalToken>()
                .HasOne(m => m.PersonalToken)
                .WithMany(p => p.ClientPersonalTokens)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClientGroupToken>()
                .HasOne(m => m.GroupToken)
                .WithMany(p => p.ClientGroupTokens)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClientGroupToken>()
                .HasOne(m => m.Client)
                .WithMany(p => p.ClientGroupTokens)
                .OnDelete(DeleteBehavior.Restrict);

            //Trainer
            modelBuilder.Entity<Application>()
                .HasOne(a => a.Trainer)
                .WithMany(a => a.Applications)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Application>()
                .HasMany(a => a.SignOut)
                .WithOne(a => a.Application)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Application>()
                .HasMany(a => a.SignUp)
                .WithOne(a => a.Application)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Response>()
                .HasOne(a => a.Trainer)
                .WithMany(a => a.Responses)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Request>()
                .HasOne(a => a.Response)
                .WithOne(a => a.Request)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Request>()
                .HasOne(a => a.ClientRequest)
                .WithOne(a => a.Request)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Client>()
                .HasMany(a => a.ClientRequests)
                .WithOne(a => a.Client)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Trainer>()
                .HasMany(a => a.TrainerTrainingSignUps)
                .WithOne(a => a.Trainer)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Trainer>()
                .HasMany(a => a.TrainerTrainingSignOuts)
                .WithOne(a => a.Trainer)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Training>()
                .HasOne(a => a.TrainerTrainingSignOut)
                .WithOne(a => a.Training)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Training>()
                .HasOne(a => a.TrainerTrainingSignUp)
                .WithOne(a => a.Training)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Trainer>()
                .HasMany(a => a.ClientRequests)
                .WithOne(a => a.Trainer)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
