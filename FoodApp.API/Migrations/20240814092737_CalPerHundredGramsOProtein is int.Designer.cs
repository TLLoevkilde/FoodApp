﻿// <auto-generated />
using System;
using FoodApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodApp.API.Migrations
{
    [DbContext(typeof(FoodAppDbContext))]
    [Migration("20240814092737_CalPerHundredGramsOProtein is int")]
    partial class CalPerHundredGramsOProteinisint
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FoodApp.API.Models.Domain.FoodItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("CalPerHundredGrams")
                        .HasColumnType("float");

                    b.Property<int>("CalPerHundredGramsOfProtein")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("PricePerHundredGramsOfProtein")
                        .HasColumnType("float");

                    b.Property<double>("ProteinPerHundredGrams")
                        .HasColumnType("float");

                    b.Property<double>("ProteinPerWeightInGrams")
                        .HasColumnType("float");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<double>("WeightInGrams")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("FoodItems");
                });
#pragma warning restore 612, 618
        }
    }
}
