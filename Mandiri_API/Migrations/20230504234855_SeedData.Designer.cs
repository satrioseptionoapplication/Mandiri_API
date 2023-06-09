﻿// <auto-generated />
using System;
using Mandiri_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mandiri_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230504234855_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Mandiri_API.Models.LocalUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LocalUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "admin",
                            Password = "admin",
                            Role = "admin",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Mandiri_API.Models.Position", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UsersId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("Position");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Manager",
                            UpdatedDate = new DateTime(2023, 5, 5, 6, 48, 55, 214, DateTimeKind.Local).AddTicks(3951),
                            UsersId = 1L
                        });
                });

            modelBuilder.Entity("Mandiri_API.Models.Project", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Project");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Kalkulator",
                            UpdatedDate = new DateTime(2023, 5, 5, 6, 48, 55, 214, DateTimeKind.Local).AddTicks(4149)
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Zuma",
                            UpdatedDate = new DateTime(2023, 5, 5, 6, 48, 55, 214, DateTimeKind.Local).AddTicks(4154)
                        });
                });

            modelBuilder.Entity("Mandiri_API.Models.ProjectUsers", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UsersId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UsersId");

                    b.ToTable("ProjectUsers");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ProjectId = 1L,
                            UpdatedDate = new DateTime(2023, 5, 5, 6, 48, 55, 214, DateTimeKind.Local).AddTicks(4220),
                            UsersId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            ProjectId = 2L,
                            UpdatedDate = new DateTime(2023, 5, 5, 6, 48, 55, 214, DateTimeKind.Local).AddTicks(4223),
                            UsersId = 1L
                        });
                });

            modelBuilder.Entity("Mandiri_API.Models.Skill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("SkillLevel")
                        .HasColumnType("int");

                    b.Property<string>("SkillName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UsersId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("Skill");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            SkillLevel = 0,
                            SkillName = "Net Core",
                            UpdatedDate = new DateTime(2023, 5, 5, 6, 48, 55, 214, DateTimeKind.Local).AddTicks(4045),
                            UsersId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            SkillLevel = 0,
                            SkillName = "Sql Server",
                            UpdatedDate = new DateTime(2023, 5, 5, 6, 48, 55, 214, DateTimeKind.Local).AddTicks(4053),
                            UsersId = 1L
                        });
                });

            modelBuilder.Entity("Mandiri_API.Models.Users", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Address = "Bogor",
                            FullName = "Satrio",
                            UpdatedDate = new DateTime(2023, 5, 5, 6, 48, 55, 214, DateTimeKind.Local).AddTicks(3843)
                        });
                });

            modelBuilder.Entity("Mandiri_API.Models.Position", b =>
                {
                    b.HasOne("Mandiri_API.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Mandiri_API.Models.ProjectUsers", b =>
                {
                    b.HasOne("Mandiri_API.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mandiri_API.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Mandiri_API.Models.Skill", b =>
                {
                    b.HasOne("Mandiri_API.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
