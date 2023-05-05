using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mandiri_API.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueColumnTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Skill_UsersId",
                table: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_ProjectUsers_ProjectId",
                table: "ProjectUsers");

            migrationBuilder.DropIndex(
                name: "IX_Position_UsersId",
                table: "Position");

            migrationBuilder.AlterColumn<string>(
                name: "SkillName",
                table: "Skill",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Position",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 7, 29, 59, 744, DateTimeKind.Local).AddTicks(6758));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 7, 29, 59, 744, DateTimeKind.Local).AddTicks(6858));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 2L,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 7, 29, 59, 744, DateTimeKind.Local).AddTicks(6867));

            migrationBuilder.UpdateData(
                table: "ProjectUsers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 7, 29, 59, 744, DateTimeKind.Local).AddTicks(6904));

            migrationBuilder.UpdateData(
                table: "ProjectUsers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 7, 29, 59, 744, DateTimeKind.Local).AddTicks(6907));

            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 7, 29, 59, 744, DateTimeKind.Local).AddTicks(6801));

            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: 2L,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 7, 29, 59, 744, DateTimeKind.Local).AddTicks(6806));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 7, 29, 59, 744, DateTimeKind.Local).AddTicks(6684));

            migrationBuilder.CreateIndex(
                name: "IX_Skill_UsersId_SkillName",
                table: "Skill",
                columns: new[] { "UsersId", "SkillName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsers_ProjectId_UsersId",
                table: "ProjectUsers",
                columns: new[] { "ProjectId", "UsersId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Position_UsersId",
                table: "Position",
                column: "UsersId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Skill_UsersId_SkillName",
                table: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_ProjectUsers_ProjectId_UsersId",
                table: "ProjectUsers");

            migrationBuilder.DropIndex(
                name: "IX_Position_UsersId",
                table: "Position");

            migrationBuilder.AlterColumn<string>(
                name: "SkillName",
                table: "Skill",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Position",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 6, 48, 55, 214, DateTimeKind.Local).AddTicks(3951));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 6, 48, 55, 214, DateTimeKind.Local).AddTicks(4149));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 2L,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 6, 48, 55, 214, DateTimeKind.Local).AddTicks(4154));

            migrationBuilder.UpdateData(
                table: "ProjectUsers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 6, 48, 55, 214, DateTimeKind.Local).AddTicks(4220));

            migrationBuilder.UpdateData(
                table: "ProjectUsers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 6, 48, 55, 214, DateTimeKind.Local).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 6, 48, 55, 214, DateTimeKind.Local).AddTicks(4045));

            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: 2L,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 6, 48, 55, 214, DateTimeKind.Local).AddTicks(4053));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 6, 48, 55, 214, DateTimeKind.Local).AddTicks(3843));

            migrationBuilder.CreateIndex(
                name: "IX_Skill_UsersId",
                table: "Skill",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsers_ProjectId",
                table: "ProjectUsers",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Position_UsersId",
                table: "Position",
                column: "UsersId");
        }
    }
}
