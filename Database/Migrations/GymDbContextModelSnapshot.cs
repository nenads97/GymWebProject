﻿// <auto-generated />
using System;
using Database.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(GymDbContext))]
    partial class GymDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Database.AdditionalRelations.ClientGroupToken", b =>
                {
                    b.Property<int>("ClientGroupTokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientGroupTokenId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("GroupTokenId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfGroupTokens")
                        .HasColumnType("int");

                    b.HasKey("ClientGroupTokenId");

                    b.HasIndex("ClientId");

                    b.HasIndex("GroupTokenId");

                    b.ToTable("ClientGroupTokens");
                });

            modelBuilder.Entity("Database.AdditionalRelations.ClientPersonalToken", b =>
                {
                    b.Property<int>("ClientPersonalTokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientPersonalTokenId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPersonalTokens")
                        .HasColumnType("int");

                    b.Property<int>("PersonalTokenId")
                        .HasColumnType("int");

                    b.HasKey("ClientPersonalTokenId");

                    b.HasIndex("ClientId");

                    b.HasIndex("PersonalTokenId");

                    b.ToTable("ClientPersonalTokens");
                });

            modelBuilder.Entity("Database.AdditionalRelations.PackageAdministrator", b =>
                {
                    b.Property<int>("PackageAdministratorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PackageAdministratorId"));

                    b.Property<int>("AdministratorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.HasKey("PackageAdministratorId");

                    b.HasIndex("AdministratorId");

                    b.HasIndex("PackageId");

                    b.ToTable("PackageAdministrators");
                });

            modelBuilder.Entity("Database.AdditionalRelations.TokenPackage", b =>
                {
                    b.Property<int>("TokenPackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TokenPackageId"));

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("TokenId")
                        .HasColumnType("int");

                    b.HasKey("TokenPackageId");

                    b.HasIndex("PackageId");

                    b.HasIndex("TokenId");

                    b.ToTable("TokenPackages");
                });

            modelBuilder.Entity("Database.AdditionalRelations.TokenPurchase", b =>
                {
                    b.Property<int>("TokenPurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TokenPurchaseId"));

                    b.Property<int>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("TokenId")
                        .HasColumnType("int");

                    b.HasKey("TokenPurchaseId");

                    b.HasIndex("PurchaseId");

                    b.HasIndex("TokenId");

                    b.ToTable("TokenPurchases");
                });

            modelBuilder.Entity("Database.Entities.Membership", b =>
                {
                    b.Property<int>("MembershipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MembershipId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.HasKey("MembershipId");

                    b.HasIndex("ClientId");

                    b.HasIndex("PackageId");

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("Database.Entities.Package", b =>
                {
                    b.Property<int>("PackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PackageId"));

                    b.Property<int>("AdministratorId")
                        .HasColumnType("int");

                    b.Property<string>("PackageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PackageId");

                    b.HasIndex("AdministratorId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("Database.Entities.PackageDiscount", b =>
                {
                    b.Property<int>("PackageDiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PackageDiscountId"));

                    b.Property<int>("AdministratorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("PackageDiscountId");

                    b.HasIndex("AdministratorId");

                    b.ToTable("PackageDiscounts");
                });

            modelBuilder.Entity("Database.Entities.PackagePrice", b =>
                {
                    b.Property<int>("PackagePriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PackagePriceId"));

                    b.Property<int>("AdministratorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("PackagePriceId");

                    b.HasIndex("AdministratorId");

                    b.HasIndex("PackageId");

                    b.ToTable("PackagePrices");
                });

            modelBuilder.Entity("Database.Entities.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<decimal>("PaymentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PaymentId");

                    b.HasIndex("ClientId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Database.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<long>("JMBG")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PhoneNumber")
                        .HasColumnType("float");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Database.Entities.Purchase", b =>
                {
                    b.Property<int>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurchaseId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("PurchaseId");

                    b.HasIndex("ClientId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("Database.Entities.Token", b =>
                {
                    b.Property<int>("TokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TokenId"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TokenType")
                        .HasColumnType("int");

                    b.HasKey("TokenId");

                    b.ToTable("Tokens");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Token");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Database.Entities.TokenPrice", b =>
                {
                    b.Property<int>("TokenPriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TokenPriceId"));

                    b.Property<int>("AdministratorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("TokenId")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("TokenPriceId");

                    b.HasIndex("AdministratorId");

                    b.HasIndex("TokenId");

                    b.ToTable("TokenPrices");
                });

            modelBuilder.Entity("Database.JoinTables.PackagePackageDiscount", b =>
                {
                    b.Property<int>("PackagePackageDiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PackagePackageDiscountId"));

                    b.Property<int>("PackageDiscountId")
                        .HasColumnType("int");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.HasKey("PackagePackageDiscountId");

                    b.HasIndex("PackageDiscountId");

                    b.HasIndex("PackageId");

                    b.ToTable("PackagePackageDiscounts");
                });

            modelBuilder.Entity("Database.Entities.Administrator", b =>
                {
                    b.HasBaseType("Database.Entities.Person");

                    b.HasDiscriminator().HasValue("Administrator");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "nenad.suknovic@gmail.com",
                            Firstname = "Nenad",
                            Gender = 0,
                            JMBG = 1001997800095L,
                            Password = "admin",
                            PhoneNumber = 613618201.0,
                            Role = 0,
                            Surname = "Suknovic",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("Database.Entities.Client", b =>
                {
                    b.HasBaseType("Database.Entities.Person");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("Database.Entities.Employee", b =>
                {
                    b.HasBaseType("Database.Entities.Person");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("Database.Entities.Trainer", b =>
                {
                    b.HasBaseType("Database.Entities.Person");

                    b.HasDiscriminator().HasValue("Trainer");
                });

            modelBuilder.Entity("Database.Entities.GroupToken", b =>
                {
                    b.HasBaseType("Database.Entities.Token");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.HasIndex("ClientId");

                    b.ToTable("Tokens", t =>
                        {
                            t.Property("ClientId")
                                .HasColumnName("GroupToken_ClientId");
                        });

                    b.HasDiscriminator().HasValue("GroupToken");
                });

            modelBuilder.Entity("Database.Entities.PersonalToken", b =>
                {
                    b.HasBaseType("Database.Entities.Token");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.HasIndex("ClientId");

                    b.HasDiscriminator().HasValue("PersonalToken");
                });

            modelBuilder.Entity("Database.AdditionalRelations.ClientGroupToken", b =>
                {
                    b.HasOne("Database.Entities.Client", "Client")
                        .WithMany("ClientGroupTokens")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Database.Entities.GroupToken", "GroupToken")
                        .WithMany("ClientGroupTokens")
                        .HasForeignKey("GroupTokenId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("GroupToken");
                });

            modelBuilder.Entity("Database.AdditionalRelations.ClientPersonalToken", b =>
                {
                    b.HasOne("Database.Entities.Client", "Client")
                        .WithMany("ClientPersonalTokens")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Database.Entities.PersonalToken", "PersonalToken")
                        .WithMany("ClientPersonalTokens")
                        .HasForeignKey("PersonalTokenId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("PersonalToken");
                });

            modelBuilder.Entity("Database.AdditionalRelations.PackageAdministrator", b =>
                {
                    b.HasOne("Database.Entities.Administrator", "Administrator")
                        .WithMany("PackageAdministrators")
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Database.Entities.Package", "Package")
                        .WithMany("PackageAdministrators")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Administrator");

                    b.Navigation("Package");
                });

            modelBuilder.Entity("Database.AdditionalRelations.TokenPackage", b =>
                {
                    b.HasOne("Database.Entities.Package", "Package")
                        .WithMany("TokenPackages")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Database.Entities.Token", "Token")
                        .WithMany("TokenPackages")
                        .HasForeignKey("TokenId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Package");

                    b.Navigation("Token");
                });

            modelBuilder.Entity("Database.AdditionalRelations.TokenPurchase", b =>
                {
                    b.HasOne("Database.Entities.Purchase", "Purchase")
                        .WithMany("TokenPurchases")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Entities.Token", "Token")
                        .WithMany("TokenPurchases")
                        .HasForeignKey("TokenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Purchase");

                    b.Navigation("Token");
                });

            modelBuilder.Entity("Database.Entities.Membership", b =>
                {
                    b.HasOne("Database.Entities.Client", "Client")
                        .WithMany("Memberships")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Database.Entities.Package", "Package")
                        .WithMany("Memberships")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Package");
                });

            modelBuilder.Entity("Database.Entities.Package", b =>
                {
                    b.HasOne("Database.Entities.Administrator", "Administrator")
                        .WithMany()
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrator");
                });

            modelBuilder.Entity("Database.Entities.PackageDiscount", b =>
                {
                    b.HasOne("Database.Entities.Administrator", "Administrator")
                        .WithMany("PackageDiscounts")
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrator");
                });

            modelBuilder.Entity("Database.Entities.PackagePrice", b =>
                {
                    b.HasOne("Database.Entities.Administrator", "Administrator")
                        .WithMany("PackagePrices")
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Database.Entities.Package", "Package")
                        .WithMany("PackagePrices")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Administrator");

                    b.Navigation("Package");
                });

            modelBuilder.Entity("Database.Entities.Payment", b =>
                {
                    b.HasOne("Database.Entities.Client", "Client")
                        .WithMany("Payments")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Database.Entities.Employee", "Employee")
                        .WithMany("Payments")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Database.Entities.Purchase", b =>
                {
                    b.HasOne("Database.Entities.Client", "Client")
                        .WithMany("Purchases")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Database.Entities.TokenPrice", b =>
                {
                    b.HasOne("Database.Entities.Administrator", "Administrator")
                        .WithMany("TokenPrices")
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Database.Entities.Token", "Token")
                        .WithMany("TokenPrices")
                        .HasForeignKey("TokenId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Administrator");

                    b.Navigation("Token");
                });

            modelBuilder.Entity("Database.JoinTables.PackagePackageDiscount", b =>
                {
                    b.HasOne("Database.Entities.PackageDiscount", "PackageDiscount")
                        .WithMany("PackagePackageDiscounts")
                        .HasForeignKey("PackageDiscountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Database.Entities.Package", "Package")
                        .WithMany("PackagePackageDiscounts")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Package");

                    b.Navigation("PackageDiscount");
                });

            modelBuilder.Entity("Database.Entities.GroupToken", b =>
                {
                    b.HasOne("Database.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Database.Entities.PersonalToken", b =>
                {
                    b.HasOne("Database.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Database.Entities.Package", b =>
                {
                    b.Navigation("Memberships");

                    b.Navigation("PackageAdministrators");

                    b.Navigation("PackagePackageDiscounts");

                    b.Navigation("PackagePrices");

                    b.Navigation("TokenPackages");
                });

            modelBuilder.Entity("Database.Entities.PackageDiscount", b =>
                {
                    b.Navigation("PackagePackageDiscounts");
                });

            modelBuilder.Entity("Database.Entities.Purchase", b =>
                {
                    b.Navigation("TokenPurchases");
                });

            modelBuilder.Entity("Database.Entities.Token", b =>
                {
                    b.Navigation("TokenPackages");

                    b.Navigation("TokenPrices");

                    b.Navigation("TokenPurchases");
                });

            modelBuilder.Entity("Database.Entities.Administrator", b =>
                {
                    b.Navigation("PackageAdministrators");

                    b.Navigation("PackageDiscounts");

                    b.Navigation("PackagePrices");

                    b.Navigation("TokenPrices");
                });

            modelBuilder.Entity("Database.Entities.Client", b =>
                {
                    b.Navigation("ClientGroupTokens");

                    b.Navigation("ClientPersonalTokens");

                    b.Navigation("Memberships");

                    b.Navigation("Payments");

                    b.Navigation("Purchases");
                });

            modelBuilder.Entity("Database.Entities.Employee", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Database.Entities.GroupToken", b =>
                {
                    b.Navigation("ClientGroupTokens");
                });

            modelBuilder.Entity("Database.Entities.PersonalToken", b =>
                {
                    b.Navigation("ClientPersonalTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
