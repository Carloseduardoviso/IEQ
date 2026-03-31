using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Migrations
{
    /// <inheritdoc />
    public partial class Usergazp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoCivil",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoCivil",
                table: "Usuario");
        }
    }
}
