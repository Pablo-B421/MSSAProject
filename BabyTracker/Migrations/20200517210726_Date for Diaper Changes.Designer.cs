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
    [Migration("20200517210726_Date for Diaper Changes")]
    partial class DateforDiaperChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BabyTracker.Models.BabyInfo", b =>
                {
                    b.Property<string>("BabyName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BabyGender")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("BabyName");

                    b.HasIndex("UserID");

                    b.ToTable("BabyInfo");
                });

            modelBuilder.Entity("BabyTracker.Models.BabyMileStone", b =>
                {
                    b.Property<int>("MileStoneID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BabyName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MileStoneID");

                    b.HasIndex("BabyName");

                    b.ToTable("BabyMileStone");
                });

            modelBuilder.Entity("BabyTracker.Models.DiaperChange", b =>
                {
                    b.Property<int>("DiaperChangeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BabyName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberofDiaperChanges")
                        .HasColumnType("int");

                    b.HasKey("DiaperChangeID");

                    b.HasIndex("BabyName");

                    b.ToTable("DiaperChange");
                });

            modelBuilder.Entity("BabyTracker.Models.Feeding", b =>
                {
                    b.Property<int>("FeedingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BabyName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("FeedingTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfFeedings")
                        .HasColumnType("int");

                    b.HasKey("FeedingID");

                    b.HasIndex("BabyName");

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

            modelBuilder.Entity("BabyTracker.Models.BabyMileStone", b =>
                {
                    b.HasOne("BabyTracker.Models.BabyInfo", "BabyInfo")
                        .WithMany("BabyMileStones")
                        .HasForeignKey("BabyName");
                });

            modelBuilder.Entity("BabyTracker.Models.DiaperChange", b =>
                {
                    b.HasOne("BabyTracker.Models.BabyInfo", "BabyInfo")
                        .WithMany("DiaperChanges")
                        .HasForeignKey("BabyName");
                });

            modelBuilder.Entity("BabyTracker.Models.Feeding", b =>
                {
                    b.HasOne("BabyTracker.Models.BabyInfo", "BabyInfo")
                        .WithMany("Feedings")
                        .HasForeignKey("BabyName");
                });
#pragma warning restore 612, 618
        }
    }
}
