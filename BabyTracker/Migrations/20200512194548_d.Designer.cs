﻿// <auto-generated />
using System;
using BabyTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BabyTracker.Migrations
{
    [DbContext(typeof(BabyTrackerContext))]
    [Migration("20200512194548_d")]
    partial class d
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BabyTracker.Models.BabyInfo", b =>
                {
                    b.Property<int>("BabyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BabyGender")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("BabyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("BabyID");

                    b.HasIndex("UserID");

                    b.ToTable("BabyInfo");
                });

            modelBuilder.Entity("BabyTracker.Models.DiaperChange", b =>
                {
                    b.Property<int>("NumberofDiaperChanges")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BabyID")
                        .HasColumnType("int");

                    b.HasKey("NumberofDiaperChanges");

                    b.HasIndex("BabyID");

                    b.ToTable("DiaperChange");
                });

            modelBuilder.Entity("BabyTracker.Models.Feeding", b =>
                {
                    b.Property<int>("NumberOfFeedings")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BabyID")
                        .HasColumnType("int");

                    b.Property<DateTime>("FeedingTime")
                        .HasColumnType("datetime2");

                    b.HasKey("NumberOfFeedings");

                    b.HasIndex("BabyID");

                    b.ToTable("Feeding");
                });

            modelBuilder.Entity("BabyTracker.Models.Users", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BabyTracker.Models.BabyInfo", b =>
                {
                    b.HasOne("BabyTracker.Models.Users", "Users")
                        .WithMany("BabyInfos")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BabyTracker.Models.DiaperChange", b =>
                {
                    b.HasOne("BabyTracker.Models.BabyInfo", "BabyInfo")
                        .WithMany("DiaperChanges")
                        .HasForeignKey("BabyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BabyTracker.Models.Feeding", b =>
                {
                    b.HasOne("BabyTracker.Models.BabyInfo", "BabyInfo")
                        .WithMany("Feedings")
                        .HasForeignKey("BabyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
