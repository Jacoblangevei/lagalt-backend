﻿// <auto-generated />
using System;
using Lagalt_Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lagalt_Backend.Migrations
{
    [DbContext(typeof(LagaltDbContext))]
    [Migration("20231006112613_initialCreate")]
    partial class initialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lagalt_Backend.Data.Models.OwnerModels.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Owner");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "BestBoss123",
                            Username = "BestBoss"
                        });
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.ProjectModels.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Project");

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            Description = "Hacking someone important",
                            Name = "Happy Hacking",
                            OwnerId = 1
                        });
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.UserModels.PortfolioProject", b =>
                {
                    b.Property<int>("PortfolioProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PortfolioProjectId"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PortfolioProjectDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PortfolioProjectName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PortfolioProjectId");

                    b.ToTable("PortfolioProject");

                    b.HasData(
                        new
                        {
                            PortfolioProjectId = 1,
                            EndDate = new DateTime(2001, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "calculator.no",
                            PortfolioProjectDescription = "Coded a simple calculator",
                            PortfolioProjectName = "Calculator",
                            StartDate = new DateTime(2000, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.UserModels.PortfolioProjectUser", b =>
                {
                    b.Property<int>("PortfolioProjectId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PortfolioProjectId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("PortfolioProjectUser", (string)null);

                    b.HasData(
                        new
                        {
                            PortfolioProjectId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.UserModels.ProjectUser", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectUser", (string)null);

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.UserModels.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillId"));

                    b.Property<string>("SkillName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SkillId");

                    b.ToTable("Skill");

                    b.HasData(
                        new
                        {
                            SkillId = 1,
                            SkillName = "Hacking"
                        });
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.UserModels.SkillUser", b =>
                {
                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SkillId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("SkillUser", (string)null);

                    b.HasData(
                        new
                        {
                            SkillId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.UserModels.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Description = "I love coding",
                            Education = "Coding Academy",
                            Password = "Qwerty12345",
                            UserName = "UserNr1"
                        });
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.ProjectModels.Project", b =>
                {
                    b.HasOne("Lagalt_Backend.Data.Models.OwnerModels.Owner", "Owner")
                        .WithMany("Projects")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.UserModels.PortfolioProjectUser", b =>
                {
                    b.HasOne("Lagalt_Backend.Data.Models.UserModels.PortfolioProject", "PortfolioProjects")
                        .WithMany()
                        .HasForeignKey("PortfolioProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lagalt_Backend.Data.Models.UserModels.User", "Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PortfolioProjects");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.UserModels.ProjectUser", b =>
                {
                    b.HasOne("Lagalt_Backend.Data.Models.ProjectModels.Project", "Projects")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lagalt_Backend.Data.Models.UserModels.User", "Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projects");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.UserModels.SkillUser", b =>
                {
                    b.HasOne("Lagalt_Backend.Data.Models.UserModels.Skill", "Skills")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lagalt_Backend.Data.Models.UserModels.User", "Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skills");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.OwnerModels.Owner", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
