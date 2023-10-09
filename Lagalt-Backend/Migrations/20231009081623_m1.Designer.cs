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
    [Migration("20231009081623_m1")]
    partial class m1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lagalt_Backend.Data.Models.MessageModels.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("CreatorType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");

                    b.HasData(
                        new
                        {
                            CommentId = 1,
                            CommentText = "I can help!",
                            CreatorId = 1,
                            CreatorType = "User",
                            Timestamp = new DateTime(2023, 10, 9, 10, 16, 22, 911, DateTimeKind.Local).AddTicks(7991)
                        },
                        new
                        {
                            CommentId = 2,
                            CommentText = "This is cool",
                            CreatorId = 1,
                            CreatorType = "Owner",
                            Timestamp = new DateTime(2023, 10, 9, 10, 16, 22, 911, DateTimeKind.Local).AddTicks(8014)
                        });
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.MessageModels.CommentMessage", b =>
                {
                    b.Property<int?>("CommentId")
                        .HasColumnType("int");

                    b.Property<int?>("MessageId")
                        .HasColumnType("int");

                    b.HasKey("CommentId", "MessageId");

                    b.HasIndex("MessageId");

                    b.ToTable("CommentMessage", (string)null);

                    b.HasData(
                        new
                        {
                            CommentId = 1,
                            MessageId = 1
                        },
                        new
                        {
                            CommentId = 2,
                            MessageId = 2
                        });
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.MessageModels.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"));

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("CreatorType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageContent")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("MessageId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Message");

                    b.HasData(
                        new
                        {
                            MessageId = 1,
                            CreatorId = 1,
                            CreatorType = "User",
                            MessageContent = "Hi, I need a link",
                            ProjectId = 1,
                            Subject = "Need link",
                            Timestamp = new DateTime(2023, 10, 9, 10, 16, 22, 908, DateTimeKind.Local).AddTicks(8307)
                        },
                        new
                        {
                            MessageId = 2,
                            CreatorId = 1,
                            CreatorType = "Owner",
                            MessageContent = "Can someone explain how...",
                            ProjectId = 1,
                            Subject = "How to do...",
                            Timestamp = new DateTime(2023, 10, 9, 10, 16, 22, 908, DateTimeKind.Local).AddTicks(8332)
                        });
                });

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

            modelBuilder.Entity("Lagalt_Backend.Data.Models.OwnerModels.UserReview", b =>
                {
                    b.Property<int>("UserReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserReviewId"));

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserReviewId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("UserId");

                    b.ToTable("UserReview");

                    b.HasData(
                        new
                        {
                            UserReviewId = 1,
                            OwnerId = 1,
                            Review = "Very good",
                            UserId = 1
                        },
                        new
                        {
                            UserReviewId = 2,
                            OwnerId = 1,
                            Review = "Did a very good job",
                            UserId = 1
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

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
                            Name = "Happy Hacking",
                            OwnerId = 1
                        },
                        new
                        {
                            ProjectId = 2,
                            Description = "Make a cool movie",
                            Name = "Movie Maker",
                            OwnerId = 1
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

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProjectRequestId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectRequest");

                    b.HasData(
                        new
                        {
                            ProjectRequestId = 1,
                            ProjectId = 2,
                            RequestDate = new DateTime(2023, 10, 9, 10, 16, 22, 905, DateTimeKind.Local).AddTicks(4331),
                            UserId = 1
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
                            ProjectTypeName = "Coding"
                        },
                        new
                        {
                            ProjectTypeId = 2,
                            ProjectTypeName = "Movie"
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

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UpdateId");

                    b.HasIndex("UserId");

                    b.ToTable("Update");

                    b.HasData(
                        new
                        {
                            UpdateId = 1,
                            Description = "Fixed everything",
                            Timestamp = new DateTime(2023, 10, 9, 10, 16, 22, 901, DateTimeKind.Local).AddTicks(7460),
                            UserId = 1
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

            modelBuilder.Entity("Lagalt_Backend.Data.Models.MessageModels.Comment", b =>
                {
                    b.HasOne("Lagalt_Backend.Data.Models.OwnerModels.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_Comment_Owner");

                    b.HasOne("Lagalt_Backend.Data.Models.UserModels.User", "User")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_Comment_User");

                    b.HasOne("Lagalt_Backend.Data.Models.OwnerModels.Owner", null)
                        .WithMany("Comments")
                        .HasForeignKey("OwnerId");

                    b.HasOne("Lagalt_Backend.Data.Models.UserModels.User", null)
                        .WithMany("Comments")
                        .HasForeignKey("UserId");

                    b.Navigation("Owner");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.MessageModels.CommentMessage", b =>
                {
                    b.HasOne("Lagalt_Backend.Data.Models.MessageModels.Comment", "Comments")
                        .WithMany()
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lagalt_Backend.Data.Models.MessageModels.Message", "Messages")
                        .WithMany()
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comments");

                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.MessageModels.Message", b =>
                {
                    b.HasOne("Lagalt_Backend.Data.Models.OwnerModels.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_Message_Owner");

                    b.HasOne("Lagalt_Backend.Data.Models.UserModels.User", "User")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_Message_User");

                    b.HasOne("Lagalt_Backend.Data.Models.OwnerModels.Owner", null)
                        .WithMany("Messages")
                        .HasForeignKey("OwnerId");

                    b.HasOne("Lagalt_Backend.Data.Models.ProjectModels.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.HasOne("Lagalt_Backend.Data.Models.UserModels.User", null)
                        .WithMany("Messages")
                        .HasForeignKey("UserId");

                    b.Navigation("Owner");

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.OwnerModels.UserReview", b =>
                {
                    b.HasOne("Lagalt_Backend.Data.Models.OwnerModels.Owner", "Owner")
                        .WithMany("UserReviews")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Lagalt_Backend.Data.Models.UserModels.User", "User")
                        .WithMany("UserReviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Owner");

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
                    b.HasOne("Lagalt_Backend.Data.Models.OwnerModels.Owner", "Owner")
                        .WithMany("Projects")
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

            modelBuilder.Entity("Lagalt_Backend.Data.Models.OwnerModels.Owner", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Messages");

                    b.Navigation("Projects");

                    b.Navigation("UserReviews");
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.ProjectModels.MilestoneStatus", b =>
                {
                    b.Navigation("Milestones");
                });

            modelBuilder.Entity("Lagalt_Backend.Data.Models.ProjectModels.Project", b =>
                {
                    b.Navigation("Milestones");

                    b.Navigation("ProjectRequests");
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
                    b.Navigation("Comments");

                    b.Navigation("Messages");

                    b.Navigation("ProjectRequests");

                    b.Navigation("Updates");

                    b.Navigation("UserReviews");
                });
#pragma warning restore 612, 618
        }
    }
}
