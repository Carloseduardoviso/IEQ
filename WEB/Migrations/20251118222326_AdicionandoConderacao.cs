using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoConderacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoUrl10Anos",
                table: "Diaconato",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FotoUrl15Anos",
                table: "Diaconato",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FotoUrl20Anos",
                table: "Diaconato",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FotoUrl25Anos",
                table: "Diaconato",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FotoUrl5Anos",
                table: "Diaconato",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FotoUrlConsagracao",
                table: "Diaconato",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoUrl10Anos",
                table: "Diaconato");

            migrationBuilder.DropColumn(
                name: "FotoUrl15Anos",
                table: "Diaconato");

            migrationBuilder.DropColumn(
                name: "FotoUrl20Anos",
                table: "Diaconato");

            migrationBuilder.DropColumn(
                name: "FotoUrl25Anos",
                table: "Diaconato");

            migrationBuilder.DropColumn(
                name: "FotoUrl5Anos",
                table: "Diaconato");

            migrationBuilder.DropColumn(
                name: "FotoUrlConsagracao",
                table: "Diaconato");
        }
    }
}
