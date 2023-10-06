using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lagalt_Backend.Migrations
{
    public partial class m7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioProjectUser_PortfolioProject_PortfolioProjectsPortfolioProjectId",
                table: "PortfolioProjectUser");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioProjectUser_User_UsersUserId",
                table: "PortfolioProjectUser");

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "PortfolioProjectUser",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "PortfolioProjectsPortfolioProjectId",
                table: "PortfolioProjectUser",
                newName: "PortfolioProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_PortfolioProjectUser_UsersUserId",
                table: "PortfolioProjectUser",
                newName: "IX_PortfolioProjectUser_UserId");

            migrationBuilder.InsertData(
                table: "PortfolioProjectUser",
                columns: new[] { "PortfolioProjectId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioProjectUser_PortfolioProject_PortfolioProjectId",
                table: "PortfolioProjectUser",
                column: "PortfolioProjectId",
                principalTable: "PortfolioProject",
                principalColumn: "PortfolioProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioProjectUser_User_UserId",
                table: "PortfolioProjectUser",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioProjectUser_PortfolioProject_PortfolioProjectId",
                table: "PortfolioProjectUser");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioProjectUser_User_UserId",
                table: "PortfolioProjectUser");

            migrationBuilder.DeleteData(
                table: "PortfolioProjectUser",
                keyColumns: new[] { "PortfolioProjectId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PortfolioProjectUser",
                newName: "UsersUserId");

            migrationBuilder.RenameColumn(
                name: "PortfolioProjectId",
                table: "PortfolioProjectUser",
                newName: "PortfolioProjectsPortfolioProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_PortfolioProjectUser_UserId",
                table: "PortfolioProjectUser",
                newName: "IX_PortfolioProjectUser_UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioProjectUser_PortfolioProject_PortfolioProjectsPortfolioProjectId",
                table: "PortfolioProjectUser",
                column: "PortfolioProjectsPortfolioProjectId",
                principalTable: "PortfolioProject",
                principalColumn: "PortfolioProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioProjectUser_User_UsersUserId",
                table: "PortfolioProjectUser",
                column: "UsersUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
