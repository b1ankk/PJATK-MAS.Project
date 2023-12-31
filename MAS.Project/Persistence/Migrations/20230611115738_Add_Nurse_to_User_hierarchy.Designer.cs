﻿// <auto-generated />
using System;
using MAS.Project.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MAS.Project.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230611115738_Add_Nurse_to_User_hierarchy")]
    partial class Add_Nurse_to_User_hierarchy
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MAS.Project.Model.MedicalWorker", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("EmployedDate")
                        .HasColumnType("date");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("MedicalWorker");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("MAS.Project.Model.Patient", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Registered")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("MAS.Project.Model.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleNames")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pesel")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("MAS.Project.Model.Doctor", b =>
                {
                    b.HasBaseType("MAS.Project.Model.MedicalWorker");

                    b.Property<string>("AcademicTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specializations")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("MAS.Project.Model.Nurse", b =>
                {
                    b.HasBaseType("MAS.Project.Model.MedicalWorker");

                    b.Property<string>("Certificates")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Nurse");
                });

            modelBuilder.Entity("MAS.Project.Model.MedicalWorker", b =>
                {
                    b.HasOne("MAS.Project.Model.User", "Parent")
                        .WithOne()
                        .HasForeignKey("MAS.Project.Model.MedicalWorker", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("MAS.Project.Model.Patient", b =>
                {
                    b.HasOne("MAS.Project.Model.User", "Parent")
                        .WithOne()
                        .HasForeignKey("MAS.Project.Model.Patient", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("MAS.Project.Model.User", b =>
                {
                    b.OwnsOne("MAS.Project.Model.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .HasColumnType("bigint");

                            b1.Property<string>("ApartmentNumber")
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("StreetNumber")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(6)
                                .HasColumnType("nvarchar(6)");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("MAS.Project.Model.Doctor", b =>
                {
                    b.HasOne("MAS.Project.Model.MedicalWorker", null)
                        .WithOne()
                        .HasForeignKey("MAS.Project.Model.Doctor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MAS.Project.Model.Nurse", b =>
                {
                    b.HasOne("MAS.Project.Model.MedicalWorker", null)
                        .WithOne()
                        .HasForeignKey("MAS.Project.Model.Nurse", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
