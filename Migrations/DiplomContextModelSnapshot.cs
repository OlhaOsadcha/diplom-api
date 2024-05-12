﻿// <auto-generated />
using System;
using DiplomApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DiplomApi.Migrations
{
    [DbContext(typeof(DiplomContext))]
    partial class DiplomContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DiplomApi.Models.Income", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Deposit")
                        .HasColumnType("int");

                    b.Property<int>("DepositSpouse")
                        .HasColumnType("int");

                    b.Property<bool>("HasSpouse")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBaseline")
                        .HasColumnType("bit");

                    b.Property<int>("Other")
                        .HasColumnType("int");

                    b.Property<int>("OtherSpouse")
                        .HasColumnType("int");

                    b.Property<int>("Pension")
                        .HasColumnType("int");

                    b.Property<int>("PensionSpouse")
                        .HasColumnType("int");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<int>("SalarySpouse")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("DiplomApi.Models.Livingcost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Education")
                        .HasColumnType("int");

                    b.Property<bool>("IsBaseline")
                        .HasColumnType("bit");

                    b.Property<int>("Loans")
                        .HasColumnType("int");

                    b.Property<int>("Markets")
                        .HasColumnType("int");

                    b.Property<int>("Mortgage")
                        .HasColumnType("int");

                    b.Property<int>("Other")
                        .HasColumnType("int");

                    b.Property<int>("Rent")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.Property<int>("Transportation")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Utilities")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Livingcosts");
                });

            modelBuilder.Entity("DiplomApi.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
