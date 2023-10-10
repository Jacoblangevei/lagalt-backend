using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lagalt_Backend.Migrations
{
    /// <inheritdoc />
    public partial class m4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Education",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "User",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Education",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "User",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 9, 14, 29, 50, 477, DateTimeKind.Local).AddTicks(9794));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 9, 14, 29, 50, 477, DateTimeKind.Local).AddTicks(9815));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 9, 14, 29, 50, 475, DateTimeKind.Local).AddTicks(8076));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 9, 14, 29, 50, 475, DateTimeKind.Local).AddTicks(8104));

            migrationBuilder.UpdateData(
                table: "ProjectRequest",
                keyColumn: "ProjectRequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2023, 10, 9, 14, 29, 50, 473, DateTimeKind.Local).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "Update",
                keyColumn: "UpdateId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 9, 14, 29, 50, 471, DateTimeKind.Local).AddTicks(7246));
        }
    }
}
