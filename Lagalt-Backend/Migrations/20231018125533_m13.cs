using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lagalt_Backend.Migrations
{
    /// <inheritdoc />
    public partial class m13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 18, 14, 55, 33, 460, DateTimeKind.Local).AddTicks(263));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 18, 14, 55, 33, 460, DateTimeKind.Local).AddTicks(279));

            migrationBuilder.UpdateData(
                table: "MilestoneStatus",
                keyColumn: "MilestoneStatusId",
                keyValue: 1,
                column: "MilestoneStatusName",
                value: "Not Started");

            migrationBuilder.InsertData(
                table: "MilestoneStatus",
                columns: new[] { "MilestoneStatusId", "MilestoneStatusName" },
                values: new object[,]
                {
                    { 2, "In Progress" },
                    { 3, "On Hold" },
                    { 4, "Completed" },
                    { 5, "Cancelled" },
                    { 6, "Delayed" }
                });

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "ProjectStatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 2,
                column: "ProjectStatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProjectRequest",
                keyColumn: "ProjectRequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2023, 10, 18, 14, 55, 33, 459, DateTimeKind.Local).AddTicks(6691));

            migrationBuilder.UpdateData(
                table: "ProjectStatus",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "StatusName",
                value: "Not Started");

            migrationBuilder.InsertData(
                table: "ProjectStatus",
                columns: new[] { "StatusId", "StatusName" },
                values: new object[,]
                {
                    { 2, "In Progress" },
                    { 3, "On Hold" },
                    { 4, "Completed" },
                    { 5, "Cancelled" },
                    { 6, "Delayed" }
                });

            migrationBuilder.UpdateData(
                table: "Update",
                keyColumn: "UpdateId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 18, 14, 55, 33, 458, DateTimeKind.Local).AddTicks(7564));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MilestoneStatus",
                keyColumn: "MilestoneStatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MilestoneStatus",
                keyColumn: "MilestoneStatusId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MilestoneStatus",
                keyColumn: "MilestoneStatusId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MilestoneStatus",
                keyColumn: "MilestoneStatusId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MilestoneStatus",
                keyColumn: "MilestoneStatusId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProjectStatus",
                keyColumn: "StatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProjectStatus",
                keyColumn: "StatusId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProjectStatus",
                keyColumn: "StatusId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProjectStatus",
                keyColumn: "StatusId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProjectStatus",
                keyColumn: "StatusId",
                keyValue: 6);

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
                table: "MilestoneStatus",
                keyColumn: "MilestoneStatusId",
                keyValue: 1,
                column: "MilestoneStatusName",
                value: "Completed");

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "ProjectStatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 2,
                column: "ProjectStatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProjectRequest",
                keyColumn: "ProjectRequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2023, 10, 18, 13, 4, 32, 759, DateTimeKind.Local).AddTicks(5671));

            migrationBuilder.UpdateData(
                table: "ProjectStatus",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "StatusName",
                value: "Completed");

            migrationBuilder.UpdateData(
                table: "Update",
                keyColumn: "UpdateId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 18, 13, 4, 32, 756, DateTimeKind.Local).AddTicks(5155));
        }
    }
}
