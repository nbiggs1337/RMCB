﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RMCB.Models;

namespace RMCB.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210629184038_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RMCB.Models.Bootcamp", b =>
                {
                    b.Property<int>("BootcampID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Facility")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Flex")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("GIBill")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Online")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Subjects")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("BootcampID");

                    b.ToTable("Bootcamps");
                });

            modelBuilder.Entity("RMCB.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BootcampID")
                        .HasColumnType("int");

                    b.Property<int>("CourseCatID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CourseID");

                    b.HasIndex("BootcampID");

                    b.HasIndex("CourseCatID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("RMCB.Models.CourseCat", b =>
                {
                    b.Property<int>("CourseCatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CourseCatID");

                    b.ToTable("CourseCats");
                });

            modelBuilder.Entity("RMCB.Models.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BootcampID")
                        .HasColumnType("int");

                    b.Property<int>("StateID")
                        .HasColumnType("int");

                    b.HasKey("LocationID");

                    b.HasIndex("BootcampID");

                    b.HasIndex("StateID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("RMCB.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BootcampID")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Cohort")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Cons")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Course")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Curriculum")
                        .HasColumnType("int");

                    b.Property<int>("Difficulty")
                        .HasColumnType("int");

                    b.Property<int>("Facility")
                        .HasColumnType("int");

                    b.Property<int>("Instructors")
                        .HasColumnType("int");

                    b.Property<int>("JobSupport")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Online")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Pros")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Recommend")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Textbook")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ReviewID");

                    b.HasIndex("BootcampID");

                    b.HasIndex("UserID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("RMCB.Models.State", b =>
                {
                    b.Property<int>("StateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("StateID");

                    b.ToTable("States");
                });

            modelBuilder.Entity("RMCB.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ConfirmEmail")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RMCB.Models.Course", b =>
                {
                    b.HasOne("RMCB.Models.Bootcamp", "Bootcamp")
                        .WithMany("Courses")
                        .HasForeignKey("BootcampID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RMCB.Models.CourseCat", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CourseCatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RMCB.Models.Location", b =>
                {
                    b.HasOne("RMCB.Models.Bootcamp", "Bootcamp")
                        .WithMany("Locations")
                        .HasForeignKey("BootcampID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RMCB.Models.State", "State")
                        .WithMany("Locations")
                        .HasForeignKey("StateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RMCB.Models.Review", b =>
                {
                    b.HasOne("RMCB.Models.Bootcamp", "Bootcamp")
                        .WithMany("Reviews")
                        .HasForeignKey("BootcampID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RMCB.Models.User", "Creator")
                        .WithMany("Reviews")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
