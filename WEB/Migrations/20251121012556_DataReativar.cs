using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Migrations
{
    /// <inheritdoc />
    public partial class DataReativar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataReativacao",
                table: "Diaconato",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TempoAcumuladoEmMeses",
                table: "Diaconato",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataReativacao",
                table: "Diaconato");

            migrationBuilder.DropColumn(
                name: "TempoAcumuladoEmMeses",
                table: "Diaconato");
        }
    }
}
