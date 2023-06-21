using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PsychoMedikAPI.Migrations
{
    public partial class DataPracyHarmongoram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DzienRoku",
                table: "Harmonogram");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPracy",
                table: "Harmonogram",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataPracy",
                table: "Harmonogram");

            migrationBuilder.AddColumn<int>(
                name: "DzienRoku",
                table: "Harmonogram",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
