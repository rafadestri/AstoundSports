﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AstoundSports.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20220406192947_InitialData")]
    partial class InitialData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Models.Athlete", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AthleteId");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaximumCalories")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Athletes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1147a2a4-b23f-4a7e-805e-92eb9c9b7098"),
                            Age = 35,
                            Country = "BR",
                            MaximumCalories = 100,
                            Name = "Audrey ",
                            SurName = "Hughes"
                        },
                        new
                        {
                            Id = new Guid("ab617dfa-5466-4a9b-a970-fcc7378be30e"),
                            Age = 20,
                            Country = "CO",
                            MaximumCalories = 250,
                            Name = "Sue ",
                            SurName = "Sharp"
                        },
                        new
                        {
                            Id = new Guid("4cd5757a-6d6c-47aa-919e-67cef680dd36"),
                            Age = 40,
                            Country = "BR",
                            MaximumCalories = 80,
                            Name = "Joseph ",
                            SurName = "Sutherland"
                        });
                });

            modelBuilder.Entity("Entities.Models.Sport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("SportId");

                    b.Property<int>("CaloriesBurntByMinute")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfPlayers")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Sports");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4332840c-d45c-47c5-b27e-c29e325c9cc4"),
                            CaloriesBurntByMinute = 10,
                            Duration = 90,
                            Name = "Soccer",
                            NumberOfPlayers = 24
                        },
                        new
                        {
                            Id = new Guid("8642cadb-b70a-407d-ba05-022f9306bba3"),
                            CaloriesBurntByMinute = 10,
                            Duration = 48,
                            Name = "Basket",
                            NumberOfPlayers = 10
                        },
                        new
                        {
                            Id = new Guid("3e2eb6b9-0eae-4d97-b7cb-27c8beff4b86"),
                            CaloriesBurntByMinute = 15,
                            Duration = 30,
                            Name = "Table Tenis",
                            NumberOfPlayers = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}