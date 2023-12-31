﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyMvcApp.DAL;

#nullable disable

namespace MyMvcApp.Migrations
{
    [DbContext(typeof(GymPopulationDbContext))]
    [Migration("20231206032132_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Capstone.Models.DbEntities.GymPopulation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Friday")
                        .HasColumnType("int");

                    b.Property<int>("Monday")
                        .HasColumnType("int");

                    b.Property<int>("Saturday")
                        .HasColumnType("int");

                    b.Property<int>("Sunday")
                        .HasColumnType("int");

                    b.Property<int>("Thursday")
                        .HasColumnType("int");

                    b.Property<int>("Tuesday")
                        .HasColumnType("int");

                    b.Property<int>("Wednesday")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("gymPopulations");
                });
#pragma warning restore 612, 618
        }
    }
}
