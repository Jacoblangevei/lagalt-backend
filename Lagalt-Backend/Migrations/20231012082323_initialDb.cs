using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lagalt_Backend.Migrations
{
    /// <inheritdoc />
    public partial class initialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MilestoneStatus",
                columns: table => new
                {
                    MilestoneStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MilestoneStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilestoneStatus", x => x.MilestoneStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioProject",
                columns: table => new
                {
                    PortfolioProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioProjectName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PortfolioProjectDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioProject", x => x.PortfolioProjectId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectStatus",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStatus", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectType",
                columns: table => new
                {
                    ProjectTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectType", x => x.ProjectTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    ProjectStatusId = table.Column<int>(type: "int", nullable: true),
                    ProjectTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Project_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Project_ProjectStatus_ProjectStatusId",
                        column: x => x.ProjectStatusId,
                        principalTable: "ProjectStatus",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Project_ProjectType_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalTable: "ProjectType",
                        principalColumn: "ProjectTypeId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioProjectUser",
                columns: table => new
                {
                    PortfolioProjectId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioProjectUser", x => new { x.PortfolioProjectId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PortfolioProjectUser_PortfolioProject_PortfolioProjectId",
                        column: x => x.PortfolioProjectId,
                        principalTable: "PortfolioProject",
                        principalColumn: "PortfolioProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioProjectUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillUser",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillUser", x => new { x.SkillId, x.UserId });
                    table.ForeignKey(
                        name: "FK_SkillUser_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Update",
                columns: table => new
                {
                    UpdateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Update", x => x.UpdateId);
                    table.ForeignKey(
                        name: "FK_Update_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "UserReview",
                columns: table => new
                {
                    UserReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Review = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReview", x => x.UserReviewId);
                    table.ForeignKey(
                        name: "FK_UserReview_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_UserReview_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatorType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageContent = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Message_Owner",
                        column: x => x.CreatorId,
                        principalTable: "Owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Message_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId");
                    table.ForeignKey(
                        name: "FK_Message_User",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Milestone",
                columns: table => new
                {
                    MilestoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    MilestoneStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Milestone", x => x.MilestoneId);
                    table.ForeignKey(
                        name: "FK_Milestone_MilestoneStatus_MilestoneStatusId",
                        column: x => x.MilestoneStatusId,
                        principalTable: "MilestoneStatus",
                        principalColumn: "MilestoneStatusId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Milestone_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ProjectRequest",
                columns: table => new
                {
                    ProjectRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRequest", x => x.ProjectRequestId);
                    table.ForeignKey(
                        name: "FK_ProjectRequest_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ProjectRequest_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTag",
                columns: table => new
                {
                    ProjectsProjectId = table.Column<int>(type: "int", nullable: false),
                    TagsTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTag", x => new { x.ProjectsProjectId, x.TagsTagId });
                    table.ForeignKey(
                        name: "FK_ProjectTag_Project_ProjectsProjectId",
                        column: x => x.ProjectsProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTag_Tag_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectUser",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUser", x => new { x.ProjectId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ProjectUser_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requirement",
                columns: table => new
                {
                    RequirementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequirementText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirement", x => x.RequirementId);
                    table.ForeignKey(
                        name: "FK_Requirement_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectUpdate",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    UpdateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUpdate", x => new { x.ProjectId, x.UpdateId });
                    table.ForeignKey(
                        name: "FK_ProjectUpdate_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUpdate_Update_UpdateId",
                        column: x => x.UpdateId,
                        principalTable: "Update",
                        principalColumn: "UpdateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentText = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatorType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    MessageId = table.Column<int>(type: "int", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_Message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Message",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Comment_Owner",
                        column: x => x.CreatorId,
                        principalTable: "Owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_User",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "MilestoneStatus",
                columns: new[] { "MilestoneStatusId", "MilestoneStatusName" },
                values: new object[] { 1, "Completed" });

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { 1, "BestBoss123", "BestBoss" });

            migrationBuilder.InsertData(
                table: "PortfolioProject",
                columns: new[] { "PortfolioProjectId", "EndDate", "ImageUrl", "PortfolioProjectDescription", "PortfolioProjectName", "StartDate" },
                values: new object[] { 1, new DateTime(2001, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "calculator.no", "Coded a simple calculator", "Calculator", new DateTime(2000, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ProjectStatus",
                columns: new[] { "StatusId", "StatusName" },
                values: new object[] { 1, "Completed" });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "ProjectTypeId", "ProjectTypeName" },
                values: new object[,]
                {
                    { 1, "Software Development" },
                    { 2, "Graphic Design" },
                    { 3, "Game Development" },
                    { 4, "Film Production" },
                    { 5, "Music Production" },
                    { 6, "Photography" },
                    { 7, "Fashion Design" },
                    { 8, "Interior Design" },
                    { 9, "Research and Analysis" },
                    { 10, "Hacking" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "SkillId", "SkillName" },
                values: new object[] { 1, "Hacking" });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "TagId", "TagName" },
                values: new object[] { 1, ".NET" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Description", "Education", "Password", "UserName" },
                values: new object[] { 1, "I love coding", "Coding Academy", "Qwerty12345", "UserNr1" });

            migrationBuilder.InsertData(
                table: "Milestone",
                columns: new[] { "MilestoneId", "Currency", "Description", "DueDate", "MilestoneStatusId", "PaymentAmount", "ProjectId", "Title" },
                values: new object[] { 1, "EUR", "Set up Azure", new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10.99m, null, "Set up Azure" });

            migrationBuilder.InsertData(
                table: "PortfolioProjectUser",
                columns: new[] { "PortfolioProjectId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "Description", "ImageUrl", "Name", "OwnerId", "ProjectStatusId", "ProjectTypeId" },
                values: new object[,]
                {
                    { 1, "Hacking someone important", "www.example.no", "Happy Hacking", 1, null, 10 },
                    { 2, "Make a cool movie", "www.example.no", "Movie Maker", 1, null, 4 }
                });

            migrationBuilder.InsertData(
                table: "SkillUser",
                columns: new[] { "SkillId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Update",
                columns: new[] { "UpdateId", "Description", "Timestamp", "UserId" },
                values: new object[] { 1, "Fixed everything", new DateTime(2023, 10, 12, 10, 23, 22, 632, DateTimeKind.Local).AddTicks(2384), 1 });

            migrationBuilder.InsertData(
                table: "UserReview",
                columns: new[] { "UserReviewId", "OwnerId", "Review", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Very good", 1 },
                    { 2, 1, "Did a very good job", 1 }
                });

            migrationBuilder.InsertData(
                table: "Message",
                columns: new[] { "MessageId", "CreatorId", "CreatorType", "MessageContent", "OwnerId", "ProjectId", "Subject", "Timestamp", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "User", "Hi, I need a link", null, 1, "Need link", new DateTime(2023, 10, 12, 10, 23, 22, 638, DateTimeKind.Local).AddTicks(9579), null },
                    { 2, 1, "Owner", "Can someone explain how...", null, 1, "How to do...", new DateTime(2023, 10, 12, 10, 23, 22, 638, DateTimeKind.Local).AddTicks(9600), null }
                });

            migrationBuilder.InsertData(
                table: "ProjectRequest",
                columns: new[] { "ProjectRequestId", "ProjectId", "RequestDate", "UserId" },
                values: new object[] { 1, 2, new DateTime(2023, 10, 12, 10, 23, 22, 635, DateTimeKind.Local).AddTicks(4083), 1 });

            migrationBuilder.InsertData(
                table: "ProjectUpdate",
                columns: new[] { "ProjectId", "UpdateId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ProjectUser",
                columns: new[] { "ProjectId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Requirement",
                columns: new[] { "RequirementId", "ProjectId", "RequirementText" },
                values: new object[] { 1, 1, "Experience with hacking" });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "CommentId", "CommentText", "CreatorId", "CreatorType", "MessageId", "OwnerId", "Timestamp", "UserId" },
                values: new object[,]
                {
                    { 1, "I can help!", 1, "User", 1, null, new DateTime(2023, 10, 12, 10, 23, 22, 642, DateTimeKind.Local).AddTicks(5161), null },
                    { 2, "This is cool", 1, "Owner", 2, null, new DateTime(2023, 10, 12, 10, 23, 22, 642, DateTimeKind.Local).AddTicks(5182), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CreatorId",
                table: "Comment",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_MessageId",
                table: "Comment",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_OwnerId",
                table: "Comment",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_CreatorId",
                table: "Message",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_OwnerId",
                table: "Message",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ProjectId",
                table: "Message",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserId",
                table: "Message",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Milestone_MilestoneStatusId",
                table: "Milestone",
                column: "MilestoneStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Milestone_ProjectId",
                table: "Milestone",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioProjectUser_UserId",
                table: "PortfolioProjectUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_OwnerId",
                table: "Project",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectStatusId",
                table: "Project",
                column: "ProjectStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectTypeId",
                table: "Project",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRequest_ProjectId",
                table: "ProjectRequest",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRequest_UserId",
                table: "ProjectRequest",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTag_TagsTagId",
                table: "ProjectTag",
                column: "TagsTagId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUpdate_UpdateId",
                table: "ProjectUpdate",
                column: "UpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_UserId",
                table: "ProjectUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirement_ProjectId",
                table: "Requirement",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillUser_UserId",
                table: "SkillUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Update_UserId",
                table: "Update",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_OwnerId",
                table: "UserReview",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_UserId",
                table: "UserReview",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Milestone");

            migrationBuilder.DropTable(
                name: "PortfolioProjectUser");

            migrationBuilder.DropTable(
                name: "ProjectRequest");

            migrationBuilder.DropTable(
                name: "ProjectTag");

            migrationBuilder.DropTable(
                name: "ProjectUpdate");

            migrationBuilder.DropTable(
                name: "ProjectUser");

            migrationBuilder.DropTable(
                name: "Requirement");

            migrationBuilder.DropTable(
                name: "SkillUser");

            migrationBuilder.DropTable(
                name: "UserReview");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "MilestoneStatus");

            migrationBuilder.DropTable(
                name: "PortfolioProject");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Update");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "ProjectStatus");

            migrationBuilder.DropTable(
                name: "ProjectType");
        }
    }
}
