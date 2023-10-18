using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lagalt_Backend.Migrations
{
    /// <inheritdoc />
    public partial class m11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Update",
                keyColumn: "UpdateId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 18, 10, 54, 1, 733, DateTimeKind.Local).AddTicks(9174));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "AnonymousModeOn", "Description", "Education", "UserName" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), false, "Love photos", "Photo Academy", "UserNr2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 17, 11, 38, 57, 387, DateTimeKind.Local).AddTicks(7423));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 17, 11, 38, 57, 387, DateTimeKind.Local).AddTicks(7445));

            migrationBuilder.UpdateData(
                table: "ProjectRequest",
                keyColumn: "ProjectRequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2023, 10, 17, 11, 38, 57, 387, DateTimeKind.Local).AddTicks(2111));

            migrationBuilder.UpdateData(
                table: "Update",
                keyColumn: "UpdateId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 17, 11, 38, 57, 383, DateTimeKind.Local).AddTicks(6214));
        }
    }
}
