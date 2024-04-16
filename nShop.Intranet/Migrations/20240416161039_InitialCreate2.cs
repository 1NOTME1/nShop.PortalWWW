using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nShop.Intranet.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recenzja_Produkt_ProduktId",
                table: "Recenzja");

            migrationBuilder.DropForeignKey(
                name: "FK_Recenzja_Uzytkownik_UzytkownikId",
                table: "Recenzja");

            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "StatusZamowienia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "UzytkownikId",
                table: "Recenzja",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProduktId",
                table: "Recenzja",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Recenzja_Produkt_ProduktId",
                table: "Recenzja",
                column: "ProduktId",
                principalTable: "Produkt",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recenzja_Uzytkownik_UzytkownikId",
                table: "Recenzja",
                column: "UzytkownikId",
                principalTable: "Uzytkownik",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recenzja_Produkt_ProduktId",
                table: "Recenzja");

            migrationBuilder.DropForeignKey(
                name: "FK_Recenzja_Uzytkownik_UzytkownikId",
                table: "Recenzja");

            migrationBuilder.DropColumn(
                name: "Opis",
                table: "StatusZamowienia");

            migrationBuilder.AlterColumn<int>(
                name: "UzytkownikId",
                table: "Recenzja",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProduktId",
                table: "Recenzja",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recenzja_Produkt_ProduktId",
                table: "Recenzja",
                column: "ProduktId",
                principalTable: "Produkt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recenzja_Uzytkownik_UzytkownikId",
                table: "Recenzja",
                column: "UzytkownikId",
                principalTable: "Uzytkownik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
