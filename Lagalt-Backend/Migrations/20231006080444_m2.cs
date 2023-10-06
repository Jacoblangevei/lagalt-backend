using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lagalt_Backend.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUser_Project_ProjectsProjectId",
                table: "ProjectUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUser_User_UsersUserId",
                table: "ProjectUser");

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "ProjectUser",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ProjectsProjectId",
                table: "ProjectUser",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectUser_UsersUserId",
                table: "ProjectUser",
                newName: "IX_ProjectUser_UserId");

            migrationBuilder.InsertData(
                table: "ProjectUser",
                columns: new[] { "ProjectId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUser_Project_ProjectId",
                table: "ProjectUser",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUser_User_UserId",
                table: "ProjectUser",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUser_Project_ProjectId",
                table: "ProjectUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUser_User_UserId",
                table: "ProjectUser");

            migrationBuilder.DeleteData(
                table: "ProjectUser",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ProjectUser",
                newName: "UsersUserId");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "ProjectUser",
                newName: "ProjectsProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectUser_UserId",
                table: "ProjectUser",
                newName: "IX_ProjectUser_UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUser_Project_ProjectsProjectId",
                table: "ProjectUser",
                column: "ProjectsProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUser_User_UsersUserId",
                table: "ProjectUser",
                column: "UsersUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
