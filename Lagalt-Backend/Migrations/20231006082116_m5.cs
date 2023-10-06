using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lagalt_Backend.Migrations
{
    public partial class m5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillUser_Skill_SkillsSkillId",
                table: "SkillUser");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillUser_User_UsersUserId",
                table: "SkillUser");

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "SkillUser",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "SkillsSkillId",
                table: "SkillUser",
                newName: "SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_SkillUser_UsersUserId",
                table: "SkillUser",
                newName: "IX_SkillUser_UserId");

            migrationBuilder.InsertData(
                table: "SkillUser",
                columns: new[] { "SkillId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_SkillUser_Skill_SkillId",
                table: "SkillUser",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillUser_User_UserId",
                table: "SkillUser",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillUser_Skill_SkillId",
                table: "SkillUser");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillUser_User_UserId",
                table: "SkillUser");

            migrationBuilder.DeleteData(
                table: "SkillUser",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "SkillUser",
                newName: "UsersUserId");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "SkillUser",
                newName: "SkillsSkillId");

            migrationBuilder.RenameIndex(
                name: "IX_SkillUser_UserId",
                table: "SkillUser",
                newName: "IX_SkillUser_UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillUser_Skill_SkillsSkillId",
                table: "SkillUser",
                column: "SkillsSkillId",
                principalTable: "Skill",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillUser_User_UsersUserId",
                table: "SkillUser",
                column: "UsersUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
