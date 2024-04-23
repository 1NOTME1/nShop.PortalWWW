using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nShop.Intranet.Migrations
{
    /// <inheritdoc />
    public partial class AddIloscNaMagazynieToProdukt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IloscNaMagazynie",
                table: "Produkt",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IloscNaMagazynie",
                table: "Produkt");
        }
    }
}
