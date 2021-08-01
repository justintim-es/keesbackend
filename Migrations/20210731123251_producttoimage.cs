using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class producttoimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_ImageId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8a25ab8-308d-45ed-8672-2263833b9b04");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "edbe66c7-bb61-497d-ab9b-b0daee4eb595", "26b22df0-40f9-4e60-a874-0e5f67ee7ff6", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ImageId",
                table: "Products",
                column: "ImageId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_ImageId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edbe66c7-bb61-497d-ab9b-b0daee4eb595");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b8a25ab8-308d-45ed-8672-2263833b9b04", "7e66445c-984b-4283-8b0b-e5a64f6f024b", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ImageId",
                table: "Products",
                column: "ImageId");
        }
    }
}
