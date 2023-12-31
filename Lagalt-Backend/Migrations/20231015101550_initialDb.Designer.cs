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
    [Migration("20231015101550_initialDb")]
    partial class initialDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lagalt_Backend.Data.Models.MessageModels.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageContent")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectId1")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MessageId");

                    b.HasIndex("ParentId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("ProjectId1");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("Message");

                    b.HasData(
                        new
                        {
                            MessageId = 1,
                            ImageUrl = "www.image.no",
                            MessageContent = "Hi, I need a link",
                            ProjectId = 1,
                            Subject = "Need link",
                            Timestamp = new DateTime(2023, 10, 15, 12, 15, 50, 738, DateTimeKind.Local).AddTicks(8721),
                            UserId = new Guid("00000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            MessageId = 2,
                            ImageUrl = "www.image.no",
                            MessageContent = "Can someone explain how...",
                            ProjectId = 1,
                            Subject = "How to do...",
                            Timestamp = new DateTime(2023, 10, 15, 12, 15, 50, 738, DateTimeKind.Local).AddTicks(8749),
                            UserId = new Guid("00000000-0000-0000-0000-000000000001")
                        });
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.ProjectModels.Milestone", b =>
                {
                    b.Property<int>("MilestoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MilestoneId"));

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MilestoneStatusId")
                        .HasColumnType("int");

                    b.Property<decimal>("PaymentAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MilestoneId");

                    b.HasIndex("MilestoneStatusId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Milestone");

                    b.HasData(
                        new
                        {
                            MilestoneId = 1,
                            Currency = "EUR",
                            Description = "Set up Azure",
                            DueDate = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MilestoneStatusId = 1,
                            PaymentAmount = 10.99m,
                            Title = "Set up Azure"
                        });
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.ProjectModels.MilestoneStatus", b =>
                {
                    b.Property<int>("MilestoneStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MilestoneStatusId"));

                    b.Property<string>("MilestoneStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MilestoneStatusId");

                    b.ToTable("MilestoneStatus");

                    b.HasData(
                        new
                        {
                            MilestoneStatusId = 1,
                            MilestoneStatusName = "Completed"
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

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("ProjectStatusId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectTypeId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ProjectStatusId");

                    b.HasIndex("ProjectTypeId");

                    b.ToTable("Project");

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            Description = "Hacking someone important",
                            ImageUrl = "www.example.no",
                            Name = "Happy Hacking",
                            OwnerId = new Guid("00000000-0000-0000-0000-000000000001"),
                            ProjectTypeId = 10
                        },
                        new
                        {
                            ProjectId = 2,
                            Description = "Make a cool movie",
                            ImageUrl = "www.example.no",
                            Name = "Movie Maker",
                            OwnerId = new Guid("00000000-0000-0000-0000-000000000001"),
                            ProjectTypeId = 4
                        });
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.ProjectModels.ProjectRequest", b =>
                {
                    b.Property<int>("ProjectRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectRequestId"));

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProjectRequestId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectRequest");

                    b.HasData(
                        new
                        {
                            ProjectRequestId = 1,
                            ProjectId = 2,
                            RequestDate = new DateTime(2023, 10, 15, 12, 15, 50, 737, DateTimeKind.Local).AddTicks(1439),
                            UserId = new Guid("00000000-0000-0000-0000-000000000001")
                        });
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.ProjectModels.ProjectStatus", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("ProjectStatus");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            StatusName = "Completed"
                        });
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.ProjectModels.ProjectType", b =>
                {
                    b.Property<int>("ProjectTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectTypeId"));

                    b.Property<string>("ProjectTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectTypeId");

                    b.ToTable("ProjectType");

                    b.HasData(
                        new
                        {
                            ProjectTypeId = 1,
                            ProjectTypeName = "Software Development"
                        },
                        new
                        {
                            ProjectTypeId = 2,
                            ProjectTypeName = "Graphic Design"
                        },
                        new
                        {
                            ProjectTypeId = 3,
                            ProjectTypeName = "Game Development"
                        },
                        new
                        {
                            ProjectTypeId = 4,
                            ProjectTypeName = "Film Production"
                        },
                        new
                        {
                            ProjectTypeId = 5,
                            ProjectTypeName = "Music Production"
                        },
                        new
                        {
                            ProjectTypeId = 6,
                            ProjectTypeName = "Photography"
                        },
                        new
                        {
                            ProjectTypeId = 7,
                            ProjectTypeName = "Fashion Design"
                        },
                        new
                        {
                            ProjectTypeId = 8,
                            ProjectTypeName = "Interior Design"
                        },
                        new
                        {
                            ProjectTypeId = 9,
                            ProjectTypeName = "Research and Analysis"
                        },
                        new
                        {
                            ProjectTypeId = 10,
                            ProjectTypeName = "Hacking"
                        });
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.ProjectModels.ProjectUpdate", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("UpdateId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId", "UpdateId");

                    b.HasIndex("UpdateId");

                    b.ToTable("ProjectUpdate", (string)null);

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            UpdateId = 1
                        });
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.ProjectModels.Requirement", b =>
                {
                    b.Property<int>("RequirementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequirementId"));

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("RequirementText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequirementId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Requirement");

                    b.HasData(
                        new
                        {
                            RequirementId = 1,
                            ProjectId = 1,
                            RequirementText = "Experience with hacking"
                        });
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.ProjectModels.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagId"));

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagId");

                    b.ToTable("Tag");

                    b.HasData(
                        new
                        {
                            TagId = 1,
                            TagName = ".NET"
                        });
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.ProjectModels.Update", b =>
                {
                    b.Property<int>("UpdateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UpdateId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UpdateId");

                    b.HasIndex("UserId");

                    b.ToTable("Update");

                    b.HasData(
                        new
                        {
                            UpdateId = 1,
                            Description = "Fixed everything",
                            Timestamp = new DateTime(2023, 10, 15, 12, 15, 50, 734, DateTimeKind.Local).AddTicks(7394),
                            UserId = new Guid("00000000-0000-0000-0000-000000000001")
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

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PortfolioProjectId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("PortfolioProjectUser", (string)null);

                    b.HasData(
                        new
                        {
                            PortfolioProjectId = 1,
                            UserId = new Guid("00000000-0000-0000-0000-000000000001")
                        });
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.UserModels.ProjectUser", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectUser", (string)null);

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            UserId = new Guid("00000000-0000-0000-0000-000000000001"),
                            Role = "Owner"
                        },
                        new
                        {
                            ProjectId = 2,
                            UserId = new Guid("00000000-0000-0000-0000-000000000001"),
                            Role = "User"
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

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SkillId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("SkillUser", (string)null);

                    b.HasData(
                        new
                        {
                            SkillId = 1,
                            UserId = new Guid("00000000-0000-0000-0000-000000000001")
                        });
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.UserModels.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AnonymousModeOn")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Education")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("00000000-0000-0000-0000-000000000001"),
                            AnonymousModeOn = false,
                            Description = "I love coding",
                            Education = "Coding Academy",
                            Role = "User",
                            UserName = "UserNr1"
                        });
                });

            modelBuilder.Entity("ProjectTag", b =>
                {
                    b.Property<int>("ProjectsProjectId")
                        .HasColumnType("int");

                    b.Property<int>("TagsTagId")
                        .HasColumnType("int");

                    b.HasKey("ProjectsProjectId", "TagsTagId");

                    b.HasIndex("TagsTagId");

                    b.ToTable("ProjectTag");
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.MessageModels.Message", b =>
                {
                    b.HasOne("Lagalt_Backend.Data.Models.MessageModels.Message", "Parent")
                        .WithMany("Replies")
                        .HasForeignKey("ParentId");

                    b.HasOne("Lagalt_Backend.Data.Models.ProjectModels.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Lagalt_Backend.Data.Models.ProjectModels.Project", null)
                        .WithMany("Messages")
                        .HasForeignKey("ProjectId1");

                    b.HasOne("Lagalt_Backend.Data.Models.UserModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Lagalt_Backend.Data.Models.UserModels.User", null)
                        .WithMany("Messages")
                        .HasForeignKey("UserId1");

                    b.Navigation("Parent");

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.ProjectModels.Milestone", b =>
                {
                    b.HasOne("Lagalt_Backend.Data.Models.ProjectModels.MilestoneStatus", "MilestoneStatus")
                        .WithMany("Milestones")
                        .HasForeignKey("MilestoneStatusId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Lagalt_Backend.Data.Models.ProjectModels.Project", "Project")
                        .WithMany("Milestones")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("MilestoneStatus");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.ProjectModels.Project", b =>
                {
                    b.HasOne("Lagalt_Backend.Data.Models.UserModels.User", "Owner")
                        .WithMany("ProjectsOwned")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Lagalt_Backend.Data.Models.ProjectModels.ProjectStatus", "ProjectStatus")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectStatusId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Lagalt_Backend.Data.Models.ProjectModels.ProjectType", "ProjectType")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectTypeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Owner");

                    b.Navigation("ProjectStatus");

                    b.Navigation("ProjectType");
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.ProjectModels.ProjectRequest", b =>
                {
                    b.HasOne("Lagalt_Backend.Data.Models.ProjectModels.Project", "Project")
                        .WithMany("ProjectRequests")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Lagalt_Backend.Data.Models.UserModels.User", "User")
                        .WithMany("ProjectRequests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.ProjectModels.ProjectUpdate", b =>
                {
                    b.HasOne("Lagalt_Backend.Data.Models.ProjectModels.Project", "Projects")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lagalt_Backend.Data.Models.ProjectModels.Update", "Updates")
                        .WithMany()
                        .HasForeignKey("UpdateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projects");

                    b.Navigation("Updates");
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.ProjectModels.Requirement", b =>
                {
                    b.HasOne("Lagalt_Backend.Data.Models.ProjectModels.Project", "Project")
                        .WithMany("Requirements")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.ProjectModels.Update", b =>
                {
                    b.HasOne("Lagalt_Backend.Data.Models.UserModels.User", "User")
                        .WithMany("Updates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("User");
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

            modelBuilder.Entity("ProjectTag", b =>
                {
                    b.HasOne("Lagalt_Backend.Data.Models.ProjectModels.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lagalt_Backend.Data.Models.ProjectModels.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.MessageModels.Message", b =>
                {
                    b.Navigation("Replies");
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.ProjectModels.MilestoneStatus", b =>
                {
                    b.Navigation("Milestones");
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.ProjectModels.Project", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Milestones");

                    b.Navigation("ProjectRequests");

                    b.Navigation("Requirements");
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.ProjectModels.ProjectStatus", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.ProjectModels.ProjectType", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.UserModels.User", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("ProjectRequests");

                    b.Navigation("ProjectsOwned");

                    b.Navigation("Updates");
                });
#pragma warning restore 612, 618
        }
    }
}
