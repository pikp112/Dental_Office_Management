﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WhiteDentalClinic.DataAccess;

#nullable disable

namespace WhiteDentalClinic.DataAccess.Migrations
{
    [DbContext(typeof(ApiDbTempContext))]
    [Migration("20230406092429_AddOneToManyRelationAppAndMedServ")]
    partial class AddOneToManyRelationAppAndMedServ
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WhiteDentalClinic.DataAccess.Entities.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateTime")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DentistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MedicalServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DentistId");

                    b.HasIndex("MedicalServiceId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("WhiteDentalClinic.DataAccess.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WhiteDentalClinic.DataAccess.Entities.Dentist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dentists");
                });

            modelBuilder.Entity("WhiteDentalClinic.DataAccess.Entities.DentistServiceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DentistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MedicalServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DentistId");

                    b.HasIndex("MedicalServiceId");

                    b.ToTable("DentistServices");
                });

            modelBuilder.Entity("WhiteDentalClinic.DataAccess.Entities.MedicalService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MedicalServices");
                });

            modelBuilder.Entity("WhiteDentalClinic.DataAccess.Entities.Appointment", b =>
                {
                    b.HasOne("WhiteDentalClinic.DataAccess.Entities.Customer", "Customer")
                        .WithMany("Appointments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WhiteDentalClinic.DataAccess.Entities.Dentist", "Dentist")
                        .WithMany("Appointments")
                        .HasForeignKey("DentistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WhiteDentalClinic.DataAccess.Entities.MedicalService", "MedicalService")
                        .WithMany("Appointments")
                        .HasForeignKey("MedicalServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Dentist");

                    b.Navigation("MedicalService");
                });

            modelBuilder.Entity("WhiteDentalClinic.DataAccess.Entities.DentistServiceEntity", b =>
                {
                    b.HasOne("WhiteDentalClinic.DataAccess.Entities.Dentist", "Dentist")
                        .WithMany("dentistServices")
                        .HasForeignKey("DentistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WhiteDentalClinic.DataAccess.Entities.MedicalService", "MedicalService")
                        .WithMany("DentistServices")
                        .HasForeignKey("MedicalServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dentist");

                    b.Navigation("MedicalService");
                });

            modelBuilder.Entity("WhiteDentalClinic.DataAccess.Entities.Customer", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("WhiteDentalClinic.DataAccess.Entities.Dentist", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("dentistServices");
                });

            modelBuilder.Entity("WhiteDentalClinic.DataAccess.Entities.MedicalService", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("DentistServices");
                });
#pragma warning restore 612, 618
        }
    }
}
