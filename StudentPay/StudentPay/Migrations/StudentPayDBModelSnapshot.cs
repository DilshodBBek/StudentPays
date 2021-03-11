﻿// <auto-generated />
using System;
using Customer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace StudentPay.Migrations
{
    [DbContext(typeof(StudentPayDB))]
    partial class StudentPayDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Customer.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int>("Course")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentPay.Models.Payment", b =>
                {
                    b.Property<int>("Pay_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("PayAmount")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("PayDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Pay_Name")
                        .HasColumnType("text");

                    b.Property<int?>("_StudentId")
                        .HasColumnType("integer");

                    b.HasKey("Pay_ID");

                    b.HasIndex("_StudentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("StudentPay.Models.Payment", b =>
                {
                    b.HasOne("Customer.Models.Student", "_Student")
                        .WithMany()
                        .HasForeignKey("_StudentId");

                    b.Navigation("_Student");
                });
#pragma warning restore 612, 618
        }
    }
}