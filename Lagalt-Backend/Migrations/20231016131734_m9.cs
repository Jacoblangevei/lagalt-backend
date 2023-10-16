using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lagalt_Backend.Migrations
{
    /// <inheritdoc />
    public partial class m9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectRequest_Project_ProjectId",
                table: "ProjectRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectRequest_User_UserId",
                table: "ProjectRequest");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 16, 15, 17, 34, 330, DateTimeKind.Local).AddTicks(9977));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 16, 15, 17, 34, 330, DateTimeKind.Local).AddTicks(9991));

            migrationBuilder.UpdateData(
                table: "ProjectRequest",
                keyColumn: "ProjectRequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2023, 10, 16, 15, 17, 34, 330, DateTimeKind.Local).AddTicks(7065));

            migrationBuilder.UpdateData(
                table: "Update",
                keyColumn: "UpdateId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 16, 15, 17, 34, 328, DateTimeKind.Local).AddTicks(2530));

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectRequest_Project_ProjectId",
                table: "ProjectRequest",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectRequest_User_UserId",
                table: "ProjectRequest",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectRequest_Project_ProjectId",
                table: "ProjectRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectRequest_User_UserId",
                table: "ProjectRequest");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 16, 13, 40, 41, 605, DateTimeKind.Local).AddTicks(6097));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 16, 13, 40, 41, 605, DateTimeKind.Local).AddTicks(6112));

            migrationBuilder.UpdateData(
                table: "ProjectRequest",
                keyColumn: "ProjectRequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2023, 10, 16, 13, 40, 41, 605, DateTimeKind.Local).AddTicks(3323));

            migrationBuilder.UpdateData(
                table: "Update",
                keyColumn: "UpdateId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 16, 13, 40, 41, 603, DateTimeKind.Local).AddTicks(1942));

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectRequest_Project_ProjectId",
                table: "ProjectRequest",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectRequest_User_UserId",
                table: "ProjectRequest",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
