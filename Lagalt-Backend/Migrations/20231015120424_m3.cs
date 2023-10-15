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
                name: "FK_ProjectTag_Project_ProjectsProjectId",
                table: "ProjectTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTag_Tag_TagsTagId",
                table: "ProjectTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Requirement_Project_ProjectId",
                table: "Requirement");

            migrationBuilder.DropIndex(
                name: "IX_Requirement_ProjectId",
                table: "Requirement");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Requirement");

            migrationBuilder.RenameColumn(
                name: "TagsTagId",
                table: "ProjectTag",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "ProjectsProjectId",
                table: "ProjectTag",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTag_TagsTagId",
                table: "ProjectTag",
                newName: "IX_ProjectTag_TagId");

            migrationBuilder.CreateTable(
                name: "ProjectRequirement",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    RequirementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRequirement", x => new { x.ProjectId, x.RequirementId });
                    table.ForeignKey(
                        name: "FK_ProjectRequirement_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectRequirement_Requirement_RequirementId",
                        column: x => x.RequirementId,
                        principalTable: "Requirement",
                        principalColumn: "RequirementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 15, 14, 4, 23, 920, DateTimeKind.Local).AddTicks(9873));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2023, 10, 15, 14, 4, 23, 920, DateTimeKind.Local).AddTicks(9902));

            migrationBuilder.UpdateData(
                table: "ProjectRequest",
                keyColumn: "ProjectRequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2023, 10, 15, 14, 4, 23, 920, DateTimeKind.Local).AddTicks(5726));

            migrationBuilder.InsertData(
                table: "ProjectRequirement",
                columns: new[] { "ProjectId", "RequirementId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ProjectTag",
                columns: new[] { "ProjectId", "TagId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Update",
                keyColumn: "UpdateId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 15, 14, 4, 23, 915, DateTimeKind.Local).AddTicks(8736));

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRequirement_RequirementId",
                table: "ProjectRequirement",
                column: "RequirementId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTag_Project_ProjectId",
                table: "ProjectTag",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTag_Tag_TagId",
                table: "ProjectTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTag_Project_ProjectId",
                table: "ProjectTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTag_Tag_TagId",
                table: "ProjectTag");

            migrationBuilder.DropTable(
                name: "ProjectRequirement");

            migrationBuilder.DeleteData(
                table: "ProjectTag",
                keyColumns: new[] { "ProjectId", "TagId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "ProjectTag",
                newName: "TagsTagId");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "ProjectTag",
                newName: "ProjectsProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTag_TagId",
                table: "ProjectTag",
                newName: "IX_ProjectTag_TagsTagId");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Requirement",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                table: "Requirement",
                keyColumn: "RequirementId",
                keyValue: 1,
                column: "ProjectId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Update",
                keyColumn: "UpdateId",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2023, 10, 15, 12, 17, 53, 907, DateTimeKind.Local).AddTicks(8612));

            migrationBuilder.CreateIndex(
                name: "IX_Requirement_ProjectId",
                table: "Requirement",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTag_Project_ProjectsProjectId",
                table: "ProjectTag",
                column: "ProjectsProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTag_Tag_TagsTagId",
                table: "ProjectTag",
                column: "TagsTagId",
                principalTable: "Tag",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requirement_Project_ProjectId",
                table: "Requirement",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
