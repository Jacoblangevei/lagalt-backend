using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lagalt_Backend.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentMessage_Comment_CommentsCommentId",
                table: "CommentMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentMessage_Message_MessagesMessageId",
                table: "CommentMessage");

            migrationBuilder.RenameColumn(
                name: "MessagesMessageId",
                table: "CommentMessage",
                newName: "MessageId");

            migrationBuilder.RenameColumn(
                name: "CommentsCommentId",
                table: "CommentMessage",
                newName: "CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentMessage_MessagesMessageId",
                table: "CommentMessage",
                newName: "IX_CommentMessage_MessageId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CommentMessage_Comment_CommentId",
                table: "CommentMessage",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentMessage_Message_MessageId",
                table: "CommentMessage",
                column: "MessageId",
                principalTable: "Message",
                principalColumn: "MessageId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentMessage_Comment_CommentId",
                table: "CommentMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentMessage_Message_MessageId",
                table: "CommentMessage");

            migrationBuilder.DeleteData(
                table: "CommentMessage",
                keyColumns: new[] { "CommentId", "MessageId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CommentMessage",
                keyColumns: new[] { "CommentId", "MessageId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "CommentMessage",
                newName: "MessagesMessageId");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "CommentMessage",
                newName: "CommentsCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentMessage_MessageId",
                table: "CommentMessage",
                newName: "IX_CommentMessage_MessagesMessageId");

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 9, 10, 14, 1, 392, DateTimeKind.Local).AddTicks(6466));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 9, 10, 14, 1, 392, DateTimeKind.Local).AddTicks(6487));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 9, 10, 14, 1, 389, DateTimeKind.Local).AddTicks(6501));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 9, 10, 14, 1, 389, DateTimeKind.Local).AddTicks(6523));

            migrationBuilder.UpdateData(
                table: "ProjectRequest",
                keyColumn: "ProjectRequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2023, 10, 9, 10, 14, 1, 386, DateTimeKind.Local).AddTicks(3210));

            migrationBuilder.UpdateData(
                table: "Update",
                keyColumn: "UpdateId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 9, 10, 14, 1, 383, DateTimeKind.Local).AddTicks(1946));

            migrationBuilder.AddForeignKey(
                name: "FK_CommentMessage_Comment_CommentsCommentId",
                table: "CommentMessage",
                column: "CommentsCommentId",
                principalTable: "Comment",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentMessage_Message_MessagesMessageId",
                table: "CommentMessage",
                column: "MessagesMessageId",
                principalTable: "Message",
                principalColumn: "MessageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
