﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using The100DaysOfCode.Lib;

#nullable disable

namespace The100DaysOfCode.Lib.Migrations
{
    [DbContext(typeof(DayOfCodeContext))]
    [Migration("20220130154628_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("The100DaysOfCode.Lib.Models.DayOfCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("UtcTimestamp")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("DayOfCode", (string)null);
                });

            modelBuilder.Entity("The100DaysOfCode.Lib.Models.Goal", b =>
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

                    b.Property<long>("UtcTimestamp")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DayOfCodeId");

                    b.ToTable("Goal", (string)null);
                });

            modelBuilder.Entity("The100DaysOfCode.Lib.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DayOfCodeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("UtcTimestamp")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DayOfCodeId");

                    b.ToTable("Note", (string)null);
                });

            modelBuilder.Entity("The100DaysOfCode.Lib.Models.Goal", b =>
                {
                    b.HasOne("The100DaysOfCode.Lib.Models.DayOfCode", "DayOfCode")
                        .WithMany("Goals")
                        .HasForeignKey("DayOfCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DayOfCode");
                });

            modelBuilder.Entity("The100DaysOfCode.Lib.Models.Note", b =>
                {
                    b.HasOne("The100DaysOfCode.Lib.Models.DayOfCode", "DayOfCode")
                        .WithMany("Notes")
                        .HasForeignKey("DayOfCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DayOfCode");
                });

            modelBuilder.Entity("The100DaysOfCode.Lib.Models.DayOfCode", b =>
                {
                    b.Navigation("Goals");

                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}
