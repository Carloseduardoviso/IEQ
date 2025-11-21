using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Migrations
{
    /// <inheritdoc />
    public partial class AddCidadeEstado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Diaconato",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Diaconato",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Diaconato");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Diaconato");
        }
    }
}
