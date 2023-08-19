using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WepApp.Migrations
{
    /// <inheritdoc />
    public partial class BolumAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BolumId",
                table: "Ogrenciler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Bolumler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolumler", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ogrenciler_BolumId",
                table: "Ogrenciler",
                column: "BolumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ogrenciler_Bolumler_BolumId",
                table: "Ogrenciler",
                column: "BolumId",
                principalTable: "Bolumler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ogrenciler_Bolumler_BolumId",
                table: "Ogrenciler");

            migrationBuilder.DropTable(
                name: "Bolumler");

            migrationBuilder.DropIndex(
                name: "IX_Ogrenciler_BolumId",
                table: "Ogrenciler");

            migrationBuilder.DropColumn(
                name: "BolumId",
                table: "Ogrenciler");
        }
    }
}
