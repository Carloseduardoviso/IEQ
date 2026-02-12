using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Migrations
{
    /// <inheritdoc />
    public partial class Cargos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CargoLocal",
                table: "Diaconato");

            migrationBuilder.AddColumn<string>(
                name: "Cargos",
                table: "Diaconato",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cargos",
                table: "Diaconato");

            migrationBuilder.AddColumn<int>(
                name: "CargoLocal",
                table: "Diaconato",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
