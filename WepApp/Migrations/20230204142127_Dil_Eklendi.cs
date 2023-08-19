using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WepApp.Migrations
{
    /// <inheritdoc />
    public partial class DilEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dil",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dil", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Dil",
                columns: new[] { "Id", "Adi" },
                values: new object[,]
                {
                    { new Guid("a72fa537-b77b-4848-9d2d-738d3b1b8f7f"), "EN" },
                    { new Guid("c02ad632-fc80-4f24-b270-93cc9105c1ce"), "TR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dil");
        }
    }
}
