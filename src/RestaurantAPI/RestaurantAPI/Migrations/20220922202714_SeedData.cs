using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAPI.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "Category", "Image", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, 1, "japchae.png", 13.99, 1, "Japchae" },
                    { 2, 1, "jajangmyeon.png", 14.99, 1, "Jajangmyeon" },
                    { 3, 1, "janchi_guksu.png", 12.99, 1, "Janchi Guksu" },
                    { 4, 1, "budae_jjigae.png", 14.99, 1, "Budae Jjigae" },
                    { 5, 1, "naengmyeon.png", 12.99, 1, "Naengmyeon" },
                    { 6, 5, "soda.png", 2.5, 1, "Soda" },
                    { 7, 5, "iced_tea.png", 3.5, 1, "Iced Tea" },
                    { 8, 5, "tea.png", 4.0, 1, "Hot Tea" },
                    { 9, 5, "coffee.png", 4.0, 1, "Coffee" },
                    { 10, 5, "milk.png", 5.0, 1, "Milk" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
