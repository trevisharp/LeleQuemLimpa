﻿// <auto-generated />
using System;
using LeleQuemLimpa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LeleQuemLimpa.Migrations
{
    [DbContext(typeof(LeleQuemLimpaDbContext))]
    [Migration("20250718164057_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DayDiva", b =>
                {
                    b.Property<int>("DaysID")
                        .HasColumnType("int");

                    b.Property<Guid>("DivasID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DaysID", "DivasID");

                    b.HasIndex("DivasID");

                    b.ToTable("DayDiva", (string)null);
                });

            modelBuilder.Entity("LeleQuemLimpa.Models.Day", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Done")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DoneAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("LeleQuemLimpa.Models.Diva", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Divas");
                });

            modelBuilder.Entity("DayDiva", b =>
                {
                    b.HasOne("LeleQuemLimpa.Models.Day", null)
                        .WithMany()
                        .HasForeignKey("DaysID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeleQuemLimpa.Models.Diva", null)
                        .WithMany()
                        .HasForeignKey("DivasID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
