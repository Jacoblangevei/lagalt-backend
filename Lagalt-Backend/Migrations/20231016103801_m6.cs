using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lagalt_Backend.Migrations
{
    /// <inheritdoc />
    public partial class m6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 16, 12, 38, 1, 330, DateTimeKind.Local).AddTicks(1687));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 16, 12, 38, 1, 330, DateTimeKind.Local).AddTicks(1701));

            migrationBuilder.UpdateData(
                table: "ProjectRequest",
                keyColumn: "ProjectRequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2023, 10, 16, 12, 38, 1, 329, DateTimeKind.Local).AddTicks(9481));

            migrationBuilder.UpdateData(
                table: "Update",
                keyColumn: "UpdateId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 16, 12, 38, 1, 327, DateTimeKind.Local).AddTicks(5296));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 16, 12, 15, 41, 510, DateTimeKind.Local).AddTicks(4842));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 16, 12, 15, 41, 510, DateTimeKind.Local).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "ProjectRequest",
                keyColumn: "ProjectRequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2023, 10, 16, 12, 15, 41, 510, DateTimeKind.Local).AddTicks(2869));

            migrationBuilder.UpdateData(
                table: "Update",
                keyColumn: "UpdateId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 16, 12, 15, 41, 507, DateTimeKind.Local).AddTicks(9693));
        }
    }
}
