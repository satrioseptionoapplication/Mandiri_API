using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mandiri_API.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ProjectUsers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Position");

            migrationBuilder.InsertData(
                table: "LocalUsers",
                columns: new[] { "Id", "Name", "Password", "Role", "UserName" },
                values: new object[] { 1, "admin", "admin", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, "Kalkulator", new DateTime(2023, 5, 5, 6, 48, 55, 214, DateTimeKind.Local).AddTicks(4149) },
                    { 2L, "Zuma", new DateTime(2023, 5, 5, 6, 48, 55, 214, DateTimeKind.Local).AddTicks(4154) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "FullName", "UpdatedDate" },
                values: new object[] { 1L, "Bogor", "Satrio", new DateTime(2023, 5, 5, 6, 48, 55, 214, DateTimeKind.Local).AddTicks(3843) });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "Id", "Name", "UpdatedDate", "UsersId" },
                values: new object[] { 1L, "Manager", new DateTime(2023, 5, 5, 6, 48, 55, 214, DateTimeKind.Local).AddTicks(3951), 1L });

            migrationBuilder.InsertData(
                table: "ProjectUsers",
                columns: new[] { "Id", "ProjectId", "UpdatedDate", "UsersId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2023, 5, 5, 6, 48, 55, 214, DateTimeKind.Local).AddTicks(4220), 1L },
                    { 2L, 2L, new DateTime(2023, 5, 5, 6, 48, 55, 214, DateTimeKind.Local).AddTicks(4223), 1L }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "SkillLevel", "SkillName", "UpdatedDate", "UsersId" },
                values: new object[,]
                {
                    { 1L, 0, "Net Core", new DateTime(2023, 5, 5, 6, 48, 55, 214, DateTimeKind.Local).AddTicks(4045), 1L },
                    { 2L, 0, "Sql Server", new DateTime(2023, 5, 5, 6, 48, 55, 214, DateTimeKind.Local).AddTicks(4053), 1L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LocalUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ProjectUsers",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ProjectUsers",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Skill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ProjectUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Project",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Position",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
