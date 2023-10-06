using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lagalt_Backend.Migrations
{
    public partial class m6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Skill_Name",
                table: "Skill",
                newName: "SkillName");

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
                name: "PortfolioProjectUser",
                columns: table => new
                {
                    PortfolioProjectsPortfolioProjectId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioProjectUser", x => new { x.PortfolioProjectsPortfolioProjectId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_PortfolioProjectUser_PortfolioProject_PortfolioProjectsPortfolioProjectId",
                        column: x => x.PortfolioProjectsPortfolioProjectId,
                        principalTable: "PortfolioProject",
                        principalColumn: "PortfolioProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioProjectUser_User_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PortfolioProject",
                columns: new[] { "PortfolioProjectId", "EndDate", "ImageUrl", "PortfolioProjectDescription", "PortfolioProjectName", "StartDate" },
                values: new object[] { 1, new DateTime(2001, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "calculator.no", "Coded a simple calculator", "Calculator", new DateTime(2000, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioProjectUser_UsersUserId",
                table: "PortfolioProjectUser",
                column: "UsersUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PortfolioProjectUser");

            migrationBuilder.DropTable(
                name: "PortfolioProject");

            migrationBuilder.RenameColumn(
                name: "SkillName",
                table: "Skill",
                newName: "Skill_Name");
        }
    }
}
