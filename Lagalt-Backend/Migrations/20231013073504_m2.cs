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
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "User",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Owner",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 13, 9, 35, 4, 463, DateTimeKind.Local).AddTicks(1442));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 13, 9, 35, 4, 463, DateTimeKind.Local).AddTicks(1454));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 13, 9, 35, 4, 461, DateTimeKind.Local).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 13, 9, 35, 4, 461, DateTimeKind.Local).AddTicks(568));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "Id",
                keyValue: 1,
                column: "Role",
                value: "Owner");

            migrationBuilder.UpdateData(
                table: "ProjectRequest",
                keyColumn: "ProjectRequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2023, 10, 13, 9, 35, 4, 458, DateTimeKind.Local).AddTicks(9962));

            migrationBuilder.UpdateData(
                table: "Update",
                keyColumn: "UpdateId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 13, 9, 35, 4, 457, DateTimeKind.Local).AddTicks(1042));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Role",
                value: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Owner");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "User",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 12, 10, 23, 22, 642, DateTimeKind.Local).AddTicks(5161));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 12, 10, 23, 22, 642, DateTimeKind.Local).AddTicks(5182));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 12, 10, 23, 22, 638, DateTimeKind.Local).AddTicks(9579));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 12, 10, 23, 22, 638, DateTimeKind.Local).AddTicks(9600));

            migrationBuilder.UpdateData(
                table: "ProjectRequest",
                keyColumn: "ProjectRequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2023, 10, 12, 10, 23, 22, 635, DateTimeKind.Local).AddTicks(4083));

            migrationBuilder.UpdateData(
                table: "Update",
                keyColumn: "UpdateId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 12, 10, 23, 22, 632, DateTimeKind.Local).AddTicks(2384));
        }
    }
}
