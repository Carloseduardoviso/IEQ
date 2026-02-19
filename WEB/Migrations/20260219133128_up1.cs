using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Migrations
{
    /// <inheritdoc />
    public partial class up1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoUrl",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FotoUrl",
                table: "SuperintendenteRegional",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FotoUrl",
                table: "SuperintendenteEstadual",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FotoUrl",
                table: "Pastores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Igreja",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FotoUrl",
                table: "Igreja",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoUrl",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "FotoUrl",
                table: "SuperintendenteRegional");

            migrationBuilder.DropColumn(
                name: "FotoUrl",
                table: "SuperintendenteEstadual");

            migrationBuilder.DropColumn(
                name: "FotoUrl",
                table: "Pastores");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Igreja");

            migrationBuilder.DropColumn(
                name: "FotoUrl",
                table: "Igreja");
        }
    }
}
