using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lagalt_Backend.Migrations
{
    /// <inheritdoc />
    public partial class m5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 12, 8, 54, 7, 72, DateTimeKind.Local).AddTicks(2006));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 12, 8, 54, 7, 72, DateTimeKind.Local).AddTicks(2029));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 12, 8, 54, 7, 68, DateTimeKind.Local).AddTicks(6766));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 12, 8, 54, 7, 68, DateTimeKind.Local).AddTicks(6798));

            migrationBuilder.UpdateData(
                table: "ProjectRequest",
                keyColumn: "ProjectRequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2023, 10, 12, 8, 54, 7, 64, DateTimeKind.Local).AddTicks(9457));

            migrationBuilder.InsertData(
                table: "Requirement",
                columns: new[] { "RequirementId", "ProjectId", "RequirementText" },
                values: new object[] { 1, 1, "Experience with hacking" });

            migrationBuilder.UpdateData(
                table: "Update",
                keyColumn: "UpdateId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 12, 8, 54, 7, 60, DateTimeKind.Local).AddTicks(1760));

            migrationBuilder.CreateIndex(
                name: "IX_Requirement_ProjectId",
                table: "Requirement",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requirement");

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 10, 11, 4, 24, 840, DateTimeKind.Local).AddTicks(5512));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 10, 11, 4, 24, 840, DateTimeKind.Local).AddTicks(5538));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 10, 11, 4, 24, 835, DateTimeKind.Local).AddTicks(8629));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 10, 11, 4, 24, 835, DateTimeKind.Local).AddTicks(8658));

            migrationBuilder.UpdateData(
                table: "ProjectRequest",
                keyColumn: "ProjectRequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2023, 10, 10, 11, 4, 24, 831, DateTimeKind.Local).AddTicks(2137));

            migrationBuilder.UpdateData(
                table: "Update",
                keyColumn: "UpdateId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 10, 11, 4, 24, 826, DateTimeKind.Local).AddTicks(7680));
        }
    }
}
