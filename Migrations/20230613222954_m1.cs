using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PsychoMedikAPI.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wizyta_Pracownik_IdLekarza",
                table: "Wizyta");

            migrationBuilder.RenameColumn(
                name: "IdLekarza",
                table: "Wizyta",
                newName: "IdPracownika");

            migrationBuilder.RenameIndex(
                name: "IX_Wizyta_IdLekarza",
                table: "Wizyta",
                newName: "IX_Wizyta_IdPracownika");

            migrationBuilder.AddForeignKey(
                name: "FK_Wizyta_Pracownik_IdPracownika",
                table: "Wizyta",
                column: "IdPracownika",
                principalTable: "Pracownik",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wizyta_Pracownik_IdPracownika",
                table: "Wizyta");

            migrationBuilder.RenameColumn(
                name: "IdPracownika",
                table: "Wizyta",
                newName: "IdLekarza");

            migrationBuilder.RenameIndex(
                name: "IX_Wizyta_IdPracownika",
                table: "Wizyta",
                newName: "IX_Wizyta_IdLekarza");

            migrationBuilder.AddForeignKey(
                name: "FK_Wizyta_Pracownik_IdLekarza",
                table: "Wizyta",
                column: "IdLekarza",
                principalTable: "Pracownik",
                principalColumn: "Id");
        }
    }
}
