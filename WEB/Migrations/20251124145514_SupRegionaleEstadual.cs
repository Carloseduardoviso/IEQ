using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Migrations
{
    /// <inheritdoc />
    public partial class SupRegionaleEstadual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeSuperintendente",
                table: "Diaconato",
                newName: "NomeSuperintendenteRegional");

            migrationBuilder.AddColumn<string>(
                name: "NomeSuperintendenteEstadual",
                table: "Diaconato",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeSuperintendenteEstadual",
                table: "Diaconato");

            migrationBuilder.RenameColumn(
                name: "NomeSuperintendenteRegional",
                table: "Diaconato",
                newName: "NomeSuperintendente");
        }
    }
}
