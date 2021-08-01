using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class productdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57767607-77f2-43ad-93c4-1e533f3dcb66");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b8a25ab8-308d-45ed-8672-2263833b9b04", "7e66445c-984b-4283-8b0b-e5a64f6f024b", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8a25ab8-308d-45ed-8672-2263833b9b04");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "57767607-77f2-43ad-93c4-1e533f3dcb66", "822dd1f4-dd13-40c3-886a-6dae07144d2e", "Admin", "ADMIN" });
        }
    }
}
