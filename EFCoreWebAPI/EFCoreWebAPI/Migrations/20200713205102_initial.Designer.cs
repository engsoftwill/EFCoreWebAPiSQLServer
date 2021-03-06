﻿// <auto-generated />
using System;
using EFCoreWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreWebAPI.Migrations
{
    [DbContext(typeof(HeroContext))]
    [Migration("20200713205102_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreWebAPI.Models.Battle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BattleId");

                    b.Property<DateTime>("Dtbegin");

                    b.Property<DateTime>("Dtfinish");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Battles");
                });

            modelBuilder.Entity("EFCoreWebAPI.Models.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BattleId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BattleId");

                    b.ToTable("Heros");
                });

            modelBuilder.Entity("EFCoreWebAPI.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HeroId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("HeroId");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("EFCoreWebAPI.Models.Hero", b =>
                {
                    b.HasOne("EFCoreWebAPI.Models.Battle", "Battle")
                        .WithMany()
                        .HasForeignKey("BattleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFCoreWebAPI.Models.Weapon", b =>
                {
                    b.HasOne("EFCoreWebAPI.Models.Hero", "Hero")
                        .WithMany()
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
