using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WepApp.Migrations
{
    /// <inheritdoc />
    public partial class BolumSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bolumler",
                columns: new[] { "Id", "Adi" },
                values: new object[,]
                {
                    { 1, "Bilgisayar" },
                    { 2, "Matematik" },
                    { 3, "Resim" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bolumler",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bolumler",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bolumler",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
