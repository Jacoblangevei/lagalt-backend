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
            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 1,
                columns: new[] { "MessageId", "Timestamp" },
                values: new object[] { 1, new DateTime(2023, 10, 9, 14, 29, 50, 477, DateTimeKind.Local).AddTicks(9794) });

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 2,
                columns: new[] { "MessageId", "Timestamp" },
                values: new object[] { 2, new DateTime(2023, 10, 9, 14, 29, 50, 477, DateTimeKind.Local).AddTicks(9815) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 1,
                columns: new[] { "MessageId", "Timestamp" },
                values: new object[] { null, new DateTime(2023, 10, 9, 14, 26, 17, 695, DateTimeKind.Local).AddTicks(694) });

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 2,
                columns: new[] { "MessageId", "Timestamp" },
                values: new object[] { null, new DateTime(2023, 10, 9, 14, 26, 17, 695, DateTimeKind.Local).AddTicks(713) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 9, 14, 26, 17, 692, DateTimeKind.Local).AddTicks(9638));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 9, 14, 26, 17, 692, DateTimeKind.Local).AddTicks(9652));

            migrationBuilder.UpdateData(
                table: "ProjectRequest",
                keyColumn: "ProjectRequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2023, 10, 9, 14, 26, 17, 690, DateTimeKind.Local).AddTicks(9013));

            migrationBuilder.UpdateData(
                table: "Update",
                keyColumn: "UpdateId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 9, 14, 26, 17, 689, DateTimeKind.Local).AddTicks(1047));
        }
    }
}
