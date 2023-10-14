using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lagalt_Backend.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_CreatorId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_UserId",
                table: "Message");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "Message",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Message_CreatorId",
                table: "Message",
                newName: "IX_Message_UserId1");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Message",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Timestamp", "UserId", "UserId1" },
                values: new object[] { "www.image.no", new DateTime(2023, 10, 13, 14, 51, 1, 264, DateTimeKind.Local).AddTicks(8636), new Guid("00000000-0000-0000-0000-000000000001"), null });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                columns: new[] { "ImageUrl", "Timestamp", "UserId", "UserId1" },
                values: new object[] { "www.image.no", new DateTime(2023, 10, 13, 14, 51, 1, 264, DateTimeKind.Local).AddTicks(8665), new Guid("00000000-0000-0000-0000-000000000001"), null });

            migrationBuilder.UpdateData(
                table: "ProjectRequest",
                keyColumn: "ProjectRequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2023, 10, 13, 14, 51, 1, 263, DateTimeKind.Local).AddTicks(5422));

            migrationBuilder.UpdateData(
                table: "Update",
                keyColumn: "UpdateId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 13, 14, 51, 1, 259, DateTimeKind.Local).AddTicks(6350));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_UserId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_UserId1",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Message");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Message",
                newName: "CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_UserId1",
                table: "Message",
                newName: "IX_Message_CreatorId");

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                columns: new[] { "CreatorId", "Timestamp", "UserId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2023, 10, 13, 14, 17, 1, 945, DateTimeKind.Local).AddTicks(4009), null });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                columns: new[] { "CreatorId", "Timestamp", "UserId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2023, 10, 13, 14, 17, 1, 945, DateTimeKind.Local).AddTicks(4040), null });

            migrationBuilder.UpdateData(
                table: "ProjectRequest",
                keyColumn: "ProjectRequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2023, 10, 13, 14, 17, 1, 943, DateTimeKind.Local).AddTicks(5402));

            migrationBuilder.UpdateData(
                table: "Update",
                keyColumn: "UpdateId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 13, 14, 17, 1, 938, DateTimeKind.Local).AddTicks(8568));

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_CreatorId",
                table: "Message",
                column: "CreatorId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_UserId",
                table: "Message",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }
    }
}
