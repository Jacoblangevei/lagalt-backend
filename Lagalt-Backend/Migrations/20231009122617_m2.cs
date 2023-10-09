using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lagalt_Backend.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentMessage");

            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "Comment",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Comment_MessageId",
                table: "Comment",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Message_MessageId",
                table: "Comment",
                column: "MessageId",
                principalTable: "Message",
                principalColumn: "MessageId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Message_MessageId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_MessageId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "Comment");

            migrationBuilder.CreateTable(
                name: "CommentMessage",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    MessageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentMessage", x => new { x.CommentId, x.MessageId });
                    table.ForeignKey(
                        name: "FK_CommentMessage_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentMessage_Message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Message",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 9, 10, 16, 22, 911, DateTimeKind.Local).AddTicks(7991));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 9, 10, 16, 22, 911, DateTimeKind.Local).AddTicks(8014));

            migrationBuilder.InsertData(
                table: "CommentMessage",
                columns: new[] { "CommentId", "MessageId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 9, 10, 16, 22, 908, DateTimeKind.Local).AddTicks(8307));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 9, 10, 16, 22, 908, DateTimeKind.Local).AddTicks(8332));

            migrationBuilder.UpdateData(
                table: "ProjectRequest",
                keyColumn: "ProjectRequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2023, 10, 9, 10, 16, 22, 905, DateTimeKind.Local).AddTicks(4331));

            migrationBuilder.UpdateData(
                table: "Update",
                keyColumn: "UpdateId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 9, 10, 16, 22, 901, DateTimeKind.Local).AddTicks(7460));

            migrationBuilder.CreateIndex(
                name: "IX_CommentMessage_MessageId",
                table: "CommentMessage",
                column: "MessageId");
        }
    }
}
