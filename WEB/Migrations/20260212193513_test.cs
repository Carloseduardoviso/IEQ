using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CargoRegional",
                table: "Diaconato",
                type: "int",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 80);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CargoRegional",
                table: "Diaconato",
                type: "int",
                maxLength: 80,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 80,
                oldNullable: true);
        }
    }
}
