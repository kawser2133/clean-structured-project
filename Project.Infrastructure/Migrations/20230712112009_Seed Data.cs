using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "Description", "EntryDate", "IsActive", "Name", "Price", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "P001", null, null, true, "Product 1", 9.99f, null },
                    { 2, "P002", null, null, true, "Product 2", 12f, null },
                    { 3, "P003", null, null, true, "Product 3", 13f, null },
                    { 4, "P004", null, null, true, "Product 4", 14f, null },
                    { 5, "P005", null, null, true, "Product 5", 15f, null },
                    { 6, "P006", null, null, true, "Product 6", 16f, null },
                    { 7, "P007", null, null, true, "Product 7", 17f, null },
                    { 8, "P008", null, null, true, "Product 8", 18f, null },
                    { 9, "P009", null, null, true, "Product 9", 19f, null },
                    { 10, "P010", null, null, true, "Product 10", 19.99f, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
