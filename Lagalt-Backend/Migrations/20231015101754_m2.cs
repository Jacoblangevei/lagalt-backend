using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lagalt_Backend.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Project_ProjectId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Project_ProjectId1",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_UserId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_UserId1",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_ProjectId1",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_UserId1",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Message");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 15, 12, 17, 53, 910, DateTimeKind.Local).AddTicks(5898));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 15, 12, 17, 53, 910, DateTimeKind.Local).AddTicks(5913));

            migrationBuilder.UpdateData(
                table: "ProjectRequest",
                keyColumn: "ProjectRequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2023, 10, 15, 12, 17, 53, 910, DateTimeKind.Local).AddTicks(3424));

            migrationBuilder.UpdateData(
                table: "Update",
                keyColumn: "UpdateId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 15, 12, 17, 53, 907, DateTimeKind.Local).AddTicks(8612));

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Project_ProjectId",
                table: "Message",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_UserId",
                table: "Message",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Project_ProjectId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_UserId",
                table: "Message");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId1",
                table: "Message",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "Message",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                columns: new[] { "ProjectId1", "Timestamp", "UserId1" },
                values: new object[] { null, new DateTime(2023, 10, 15, 12, 15, 50, 738, DateTimeKind.Local).AddTicks(8721), null });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                columns: new[] { "ProjectId1", "Timestamp", "UserId1" },
                values: new object[] { null, new DateTime(2023, 10, 15, 12, 15, 50, 738, DateTimeKind.Local).AddTicks(8749), null });

            migrationBuilder.UpdateData(
                table: "ProjectRequest",
                keyColumn: "ProjectRequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2023, 10, 15, 12, 15, 50, 737, DateTimeKind.Local).AddTicks(1439));

            migrationBuilder.UpdateData(
                table: "Update",
                keyColumn: "UpdateId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 15, 12, 15, 50, 734, DateTimeKind.Local).AddTicks(7394));

            migrationBuilder.CreateIndex(
                name: "IX_Message_ProjectId1",
                table: "Message",
                column: "ProjectId1");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserId1",
                table: "Message",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Project_ProjectId",
                table: "Message",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Project_ProjectId1",
                table: "Message",
                column: "ProjectId1",
                principalTable: "Project",
                principalColumn: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_UserId",
                table: "Message",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_UserId1",
                table: "Message",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "UserId");
        }
    }
}
