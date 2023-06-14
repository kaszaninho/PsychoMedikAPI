using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PsychoMedikAPI.Migrations
{
    public partial class M5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wizyta_Pokoj_PokojId",
                table: "Wizyta");

            migrationBuilder.RenameColumn(
                name: "PokojId",
                table: "Wizyta",
                newName: "IdPokoju");

            migrationBuilder.RenameIndex(
                name: "IX_Wizyta_PokojId",
                table: "Wizyta",
                newName: "IX_Wizyta_IdPokoju");

            migrationBuilder.AddForeignKey(
                name: "FK_Wizyta_Pokoj_IdPokoju",
                table: "Wizyta",
                column: "IdPokoju",
                principalTable: "Pokoj",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wizyta_Pokoj_IdPokoju",
                table: "Wizyta");

            migrationBuilder.RenameColumn(
                name: "IdPokoju",
                table: "Wizyta",
                newName: "PokojId");

            migrationBuilder.RenameIndex(
                name: "IX_Wizyta_IdPokoju",
                table: "Wizyta",
                newName: "IX_Wizyta_PokojId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wizyta_Pokoj_PokojId",
                table: "Wizyta",
                column: "PokojId",
                principalTable: "Pokoj",
                principalColumn: "Id");
        }
    }
}
