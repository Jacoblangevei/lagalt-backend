using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lagalt_Backend.Migrations
{
    /// <inheritdoc />
    public partial class m12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectUpdate");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Update",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 18, 13, 4, 32, 760, DateTimeKind.Local).AddTicks(2725));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 18, 13, 4, 32, 760, DateTimeKind.Local).AddTicks(2750));

            migrationBuilder.UpdateData(
                table: "ProjectRequest",
                keyColumn: "ProjectRequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2023, 10, 18, 13, 4, 32, 759, DateTimeKind.Local).AddTicks(5671));

            migrationBuilder.UpdateData(
                table: "Update",
                keyColumn: "UpdateId",
                keyValue: 1,
                columns: new[] { "ProjectId", "Timestamp" },
                values: new object[] { 1, new DateTime(2023, 10, 18, 13, 4, 32, 756, DateTimeKind.Local).AddTicks(5155) });

            migrationBuilder.CreateIndex(
                name: "IX_Update_ProjectId",
                table: "Update",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Update_Project_ProjectId",
                table: "Update",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Update_Project_ProjectId",
                table: "Update");

            migrationBuilder.DropIndex(
                name: "IX_Update_ProjectId",
                table: "Update");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Update");

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

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 18, 10, 54, 1, 741, DateTimeKind.Local).AddTicks(412));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 18, 10, 54, 1, 741, DateTimeKind.Local).AddTicks(436));

            migrationBuilder.UpdateData(
                table: "ProjectRequest",
                keyColumn: "ProjectRequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2023, 10, 18, 10, 54, 1, 740, DateTimeKind.Local).AddTicks(2237));

            migrationBuilder.InsertData(
                table: "ProjectUpdate",
                columns: new[] { "ProjectId", "UpdateId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Update",
                keyColumn: "UpdateId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 18, 10, 54, 1, 733, DateTimeKind.Local).AddTicks(9174));

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUpdate_UpdateId",
                table: "ProjectUpdate",
                column: "UpdateId");
        }
    }
}
