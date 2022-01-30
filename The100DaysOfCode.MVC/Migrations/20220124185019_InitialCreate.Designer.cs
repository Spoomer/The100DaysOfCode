﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace The100DaysOfCode.MVC.Migrations
{
    [DbContext(typeof(DayOfCodeContext))]
    [Migration("20220124185019_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("The100DaysOfCode.MVC.Models.DayOfCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DaysOfCode");
                });

            modelBuilder.Entity("The100DaysOfCode.MVC.Models.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Check")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DayOfCodeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DayOfCodeId");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("The100DaysOfCode.MVC.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DayOfCodeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DayOfCodeId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("The100DaysOfCode.MVC.Models.Goal", b =>
                {
                    b.HasOne("The100DaysOfCode.MVC.Models.DayOfCode", "DayOfCode")
                        .WithMany("Goals")
                        .HasForeignKey("DayOfCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DayOfCode");
                });

            modelBuilder.Entity("The100DaysOfCode.MVC.Models.Note", b =>
                {
                    b.HasOne("The100DaysOfCode.MVC.Models.DayOfCode", "DayOfCode")
                        .WithMany("Notes")
                        .HasForeignKey("DayOfCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DayOfCode");
                });

            modelBuilder.Entity("The100DaysOfCode.MVC.Models.DayOfCode", b =>
                {
                    b.Navigation("Goals");

                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}
