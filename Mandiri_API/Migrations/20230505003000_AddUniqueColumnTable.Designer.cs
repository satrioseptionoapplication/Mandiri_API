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
    [Migration("20230505003000_AddUniqueColumnTable")]
    partial class AddUniqueColumnTable
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

                    b.HasIndex("UsersId")
                        .IsUnique();

                    b.ToTable("Position");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Manager",
                            UpdatedDate = new DateTime(2023, 5, 5, 7, 29, 59, 744, DateTimeKind.Local).AddTicks(6758),
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
                            UpdatedDate = new DateTime(2023, 5, 5, 7, 29, 59, 744, DateTimeKind.Local).AddTicks(6858)
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Zuma",
                            UpdatedDate = new DateTime(2023, 5, 5, 7, 29, 59, 744, DateTimeKind.Local).AddTicks(6867)
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

                    b.HasIndex("UsersId");

                    b.HasIndex("ProjectId", "UsersId")
                        .IsUnique();

                    b.ToTable("ProjectUsers");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ProjectId = 1L,
                            UpdatedDate = new DateTime(2023, 5, 5, 7, 29, 59, 744, DateTimeKind.Local).AddTicks(6904),
                            UsersId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            ProjectId = 2L,
                            UpdatedDate = new DateTime(2023, 5, 5, 7, 29, 59, 744, DateTimeKind.Local).AddTicks(6907),
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
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UsersId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsersId", "SkillName")
                        .IsUnique();

                    b.ToTable("Skill");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            SkillLevel = 0,
                            SkillName = "Net Core",
                            UpdatedDate = new DateTime(2023, 5, 5, 7, 29, 59, 744, DateTimeKind.Local).AddTicks(6801),
                            UsersId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            SkillLevel = 0,
                            SkillName = "Sql Server",
                            UpdatedDate = new DateTime(2023, 5, 5, 7, 29, 59, 744, DateTimeKind.Local).AddTicks(6806),
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
                            UpdatedDate = new DateTime(2023, 5, 5, 7, 29, 59, 744, DateTimeKind.Local).AddTicks(6684)
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
