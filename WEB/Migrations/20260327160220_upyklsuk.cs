using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Migrations
{
    /// <inheritdoc />
    public partial class upyklsuk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pastores_MembroId",
                table: "Pastores");

            migrationBuilder.AlterColumn<Guid>(
                name: "MembroId",
                table: "Pastores",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Pastores_MembroId",
                table: "Pastores",
                column: "MembroId",
                unique: true,
                filter: "[MembroId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pastores_MembroId",
                table: "Pastores");

            migrationBuilder.AlterColumn<Guid>(
                name: "MembroId",
                table: "Pastores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pastores_MembroId",
                table: "Pastores",
                column: "MembroId",
                unique: true);
        }
    }
}
