using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class productsdelivered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edbe66c7-bb61-497d-ab9b-b0daee4eb595");

            migrationBuilder.AddColumn<int>(
                name: "Delivered",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToDeliver",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29ba77cf-0ccd-411d-b797-9e7d041ea07e", "1022403e-141f-4cdb-826f-bad2f56ebddc", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29ba77cf-0ccd-411d-b797-9e7d041ea07e");

            migrationBuilder.DropColumn(
                name: "Delivered",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ToDeliver",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "edbe66c7-bb61-497d-ab9b-b0daee4eb595", "26b22df0-40f9-4e60-a874-0e5f67ee7ff6", "Admin", "ADMIN" });
        }
    }
}
