﻿// <auto-generated />
using System;
using Flippd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Flippd.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220830222919_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Flippd.Data.Entities.ListingEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PropType")
                        .HasColumnType("int");

                    b.Property<int>("PropertyFeaturesId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserEntityId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Zip")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.ToTable("Listings");
                });

            modelBuilder.Entity("Flippd.Data.Entities.PropertyFeaturesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Baths")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Bedrooms")
                        .HasColumnType("int");

                    b.Property<int>("GarageSpaces")
                        .HasColumnType("int");

                    b.Property<int>("LotSize")
                        .HasColumnType("int");

                    b.Property<int>("SquareFootage")
                        .HasColumnType("int");

                    b.Property<int>("YearBuilt")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PropertyFeatures");
                });

            modelBuilder.Entity("Flippd.Data.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Flippd.Data.Entities.ListingEntity", b =>
                {
                    b.HasOne("Flippd.Data.Entities.UserEntity", null)
                        .WithMany("MyListings")
                        .HasForeignKey("UserEntityId");
                });

            modelBuilder.Entity("Flippd.Data.Entities.UserEntity", b =>
                {
                    b.Navigation("MyListings");
                });
#pragma warning restore 612, 618
        }
    }
}
