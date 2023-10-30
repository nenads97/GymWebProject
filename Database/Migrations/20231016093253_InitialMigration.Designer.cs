﻿// <auto-generated />
using System;
using Database.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(GymDbContext))]
    [Migration("20231016093253_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.ToTable("PackageAdministrators");
                });

            modelBuilder.Entity("Database.Entities.Package", b =>
                {
                    b.Property<int>("PackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PackageId"));

                    b.Property<int>("PackageAdministratorId")
                        .HasColumnType("int");

                    b.Property<string>("PackageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PackageId");

                    b.HasIndex("PackageAdministratorId")
                        .IsUnique();

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<long>("JMBG")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PhoneNumber")
                        .HasColumnType("float");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");

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

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("TokenPriceId");

                    b.HasIndex("AdministratorId");

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

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("Database.Entities.Employee", b =>
                {
                    b.HasBaseType("Database.Entities.Person");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("Database.AdditionalRelations.PackageAdministrator", b =>
                {
                    b.HasOne("Database.Entities.Administrator", "Administrator")
                        .WithMany("PackageAdmins")
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrator");
                });

            modelBuilder.Entity("Database.Entities.Package", b =>
                {
                    b.HasOne("Database.AdditionalRelations.PackageAdministrator", "PackageAdministrator")
                        .WithOne("Package")
                        .HasForeignKey("Database.Entities.Package", "PackageAdministratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PackageAdministrator");
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

            modelBuilder.Entity("Database.Entities.TokenPrice", b =>
                {
                    b.HasOne("Database.Entities.Administrator", "Administrator")
                        .WithMany("TokenPrices")
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrator");
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

            modelBuilder.Entity("Database.AdditionalRelations.PackageAdministrator", b =>
                {
                    b.Navigation("Package");
                });

            modelBuilder.Entity("Database.Entities.Package", b =>
                {
                    b.Navigation("PackagePackageDiscounts");

                    b.Navigation("PackagePrices");
                });

            modelBuilder.Entity("Database.Entities.PackageDiscount", b =>
                {
                    b.Navigation("PackagePackageDiscounts");
                });

            modelBuilder.Entity("Database.Entities.Administrator", b =>
                {
                    b.Navigation("PackageAdmins");

                    b.Navigation("PackageDiscounts");

                    b.Navigation("PackagePrices");

                    b.Navigation("TokenPrices");
                });
#pragma warning restore 612, 618
        }
    }
}