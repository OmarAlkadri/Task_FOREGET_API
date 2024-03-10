﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task_FOREGET;

#nullable disable

namespace Task_FOREGET.Migrations
{
    [DbContext(typeof(Context_DB))]
    partial class Context_DBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Task_FOREGET.Models.Shipments", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("citiy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("currency")
                        .HasColumnType("int");

                    b.Property<int>("incoterms")
                        .HasColumnType("int");

                    b.Property<int>("mode")
                        .HasColumnType("int");

                    b.Property<int>("movementType")
                        .HasColumnType("int");

                    b.Property<int>("packageType")
                        .HasColumnType("int");

                    b.Property<int>("secondUnit")
                        .HasColumnType("int");

                    b.Property<int>("unitFirst")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Shipment");
                });

            modelBuilder.Entity("Task_FOREGET.Models.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("HashPassword")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}