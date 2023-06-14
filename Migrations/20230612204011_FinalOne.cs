using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PsychoMedikAPI.Migrations
{
    public partial class FinalOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjawPacjent");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataUrodzenia",
                table: "Pacjent",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataUrodzenia",
                table: "Pacjent",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_ObjawPacjent_PacjenciId",
                table: "ObjawPacjent",
                column: "PacjenciId");
        }
    }
}
