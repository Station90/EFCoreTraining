﻿// <auto-generated />
using System;
using EFCoreTraining;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreTraining.Migrations
{
    [DbContext(typeof(EFCoreContext))]
    [Migration("20210217123013_CreateFunction")]
    partial class CreateFunction
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreTraining.Models.InsertProcedureTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InsertName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InsertNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("InsertProcedureTemplates");
                });

            modelBuilder.Entity("EFCoreTraining.Models.PostalCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PostalCodes");
                });

            modelBuilder.Entity("EFCoreTraining.Models.StoredProcResult", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("SPResult");
                });

            modelBuilder.Entity("EFCoreTraining.Models.Street", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Streets");
                });

            modelBuilder.Entity("EFCoreTraining.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("EFCoreTraining.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DetailsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DetailsId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EFCoreTraining.Models.UserDetails", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("PostalCodeStreet", b =>
                {
                    b.Property<int>("PostalCodesId")
                        .HasColumnType("int");

                    b.Property<int>("StreetsId")
                        .HasColumnType("int");

                    b.HasKey("PostalCodesId", "StreetsId");

                    b.HasIndex("StreetsId");

                    b.ToTable("PostalCodeStreet");
                });

            modelBuilder.Entity("EFCoreTraining.Models.Task", b =>
                {
                    b.HasOne("EFCoreTraining.Models.User", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EFCoreTraining.Models.User", b =>
                {
                    b.HasOne("EFCoreTraining.Models.UserDetails", "Details")
                        .WithMany()
                        .HasForeignKey("DetailsId");

                    b.Navigation("Details");
                });

            modelBuilder.Entity("PostalCodeStreet", b =>
                {
                    b.HasOne("EFCoreTraining.Models.PostalCode", null)
                        .WithMany()
                        .HasForeignKey("PostalCodesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreTraining.Models.Street", null)
                        .WithMany()
                        .HasForeignKey("StreetsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreTraining.Models.User", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}