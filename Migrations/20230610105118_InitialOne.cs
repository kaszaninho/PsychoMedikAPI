using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PsychoMedikAPI.Migrations
{
    public partial class InitialOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Choroba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataModyfikacji = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choroba", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Objaw",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataModyfikacji = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objaw", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pokoj",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataModyfikacji = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokoj", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stanowisko",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataModyfikacji = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stanowisko", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChorobaObjaw",
                columns: table => new
                {
                    ChorobyId = table.Column<int>(type: "int", nullable: false),
                    ObjawyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChorobaObjaw", x => new { x.ChorobyId, x.ObjawyId });
                    table.ForeignKey(
                        name: "FK_ChorobaObjaw_Choroba_ChorobyId",
                        column: x => x.ChorobyId,
                        principalTable: "Choroba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChorobaObjaw_Objaw_ObjawyId",
                        column: x => x.ObjawyId,
                        principalTable: "Objaw",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pracownik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataZatrudnienia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRezygnacji = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Plec = table.Column<bool>(type: "bit", nullable: false),
                    StanCywilny = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdStanowiska = table.Column<int>(type: "int", nullable: true),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataModyfikacji = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pracownik_Stanowisko_IdStanowiska",
                        column: x => x.IdStanowiska,
                        principalTable: "Stanowisko",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Harmonogram",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPracownika = table.Column<int>(type: "int", nullable: true),
                    DzienRoku = table.Column<int>(type: "int", nullable: false),
                    GodzinaRozpoczecia = table.Column<int>(type: "int", nullable: false),
                    GodzinaZakonczenia = table.Column<int>(type: "int", nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataModyfikacji = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harmonogram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Harmonogram_Pracownik_IdPracownika",
                        column: x => x.IdPracownika,
                        principalTable: "Pracownik",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pacjent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Plec = table.Column<bool>(type: "bit", nullable: false),
                    IdPracownika = table.Column<int>(type: "int", nullable: true),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataModyfikacji = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacjent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacjent_Pracownik_IdPracownika",
                        column: x => x.IdPracownika,
                        principalTable: "Pracownik",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HistoriaChoroby",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPacjenta = table.Column<int>(type: "int", nullable: true),
                    IdChoroby = table.Column<int>(type: "int", nullable: true),
                    IdPracownika = table.Column<int>(type: "int", nullable: true),
                    DataZdiagnozowania = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataWyleczenia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataModyfikacji = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriaChoroby", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoriaChoroby_Choroba_IdChoroby",
                        column: x => x.IdChoroby,
                        principalTable: "Choroba",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoriaChoroby_Pacjent_IdPacjenta",
                        column: x => x.IdPacjenta,
                        principalTable: "Pacjent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoriaChoroby_Pracownik_IdPracownika",
                        column: x => x.IdPracownika,
                        principalTable: "Pracownik",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ObjawPacjent",
                columns: table => new
                {
                    ObjawyId = table.Column<int>(type: "int", nullable: false),
                    PacjenciId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjawPacjent", x => new { x.ObjawyId, x.PacjenciId });
                    table.ForeignKey(
                        name: "FK_ObjawPacjent_Objaw_ObjawyId",
                        column: x => x.ObjawyId,
                        principalTable: "Objaw",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjawPacjent_Pacjent_PacjenciId",
                        column: x => x.PacjenciId,
                        principalTable: "Pacjent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wizyta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataWizyty = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdPacjenta = table.Column<int>(type: "int", nullable: true),
                    IdLekarza = table.Column<int>(type: "int", nullable: true),
                    PokojId = table.Column<int>(type: "int", nullable: true),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataModyfikacji = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wizyta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wizyta_Pacjent_IdPacjenta",
                        column: x => x.IdPacjenta,
                        principalTable: "Pacjent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Wizyta_Pokoj_PokojId",
                        column: x => x.PokojId,
                        principalTable: "Pokoj",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Wizyta_Pracownik_IdLekarza",
                        column: x => x.IdLekarza,
                        principalTable: "Pracownik",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChorobaObjaw_ObjawyId",
                table: "ChorobaObjaw",
                column: "ObjawyId");

            migrationBuilder.CreateIndex(
                name: "IX_Harmonogram_IdPracownika",
                table: "Harmonogram",
                column: "IdPracownika");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaChoroby_IdChoroby",
                table: "HistoriaChoroby",
                column: "IdChoroby");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaChoroby_IdPacjenta",
                table: "HistoriaChoroby",
                column: "IdPacjenta");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaChoroby_IdPracownika",
                table: "HistoriaChoroby",
                column: "IdPracownika");

            migrationBuilder.CreateIndex(
                name: "IX_ObjawPacjent_PacjenciId",
                table: "ObjawPacjent",
                column: "PacjenciId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacjent_IdPracownika",
                table: "Pacjent",
                column: "IdPracownika");

            migrationBuilder.CreateIndex(
                name: "IX_Pracownik_IdStanowiska",
                table: "Pracownik",
                column: "IdStanowiska");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyta_IdLekarza",
                table: "Wizyta",
                column: "IdLekarza");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyta_IdPacjenta",
                table: "Wizyta",
                column: "IdPacjenta");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyta_PokojId",
                table: "Wizyta",
                column: "PokojId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChorobaObjaw");

            migrationBuilder.DropTable(
                name: "Harmonogram");

            migrationBuilder.DropTable(
                name: "HistoriaChoroby");

            migrationBuilder.DropTable(
                name: "ObjawPacjent");

            migrationBuilder.DropTable(
                name: "Wizyta");

            migrationBuilder.DropTable(
                name: "Choroba");

            migrationBuilder.DropTable(
                name: "Objaw");

            migrationBuilder.DropTable(
                name: "Pacjent");

            migrationBuilder.DropTable(
                name: "Pokoj");

            migrationBuilder.DropTable(
                name: "Pracownik");

            migrationBuilder.DropTable(
                name: "Stanowisko");
        }
    }
}
