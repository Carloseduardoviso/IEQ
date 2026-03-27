using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Migrations
{
    /// <inheritdoc />
    public partial class upyklsu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membro_Pastores_PastorId",
                table: "Membro");

            migrationBuilder.DropIndex(
                name: "IX_Membro_PastorId",
                table: "Membro");

            migrationBuilder.AddColumn<Guid>(
                name: "MembroId",
                table: "Pastores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Pastores_MembroId",
                table: "Pastores",
                column: "MembroId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pastores_Membro_MembroId",
                table: "Pastores",
                column: "MembroId",
                principalTable: "Membro",
                principalColumn: "MembroId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pastores_Membro_MembroId",
                table: "Pastores");

            migrationBuilder.DropIndex(
                name: "IX_Pastores_MembroId",
                table: "Pastores");

            migrationBuilder.DropColumn(
                name: "MembroId",
                table: "Pastores");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_PastorId",
                table: "Membro",
                column: "PastorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membro_Pastores_PastorId",
                table: "Membro",
                column: "PastorId",
                principalTable: "Pastores",
                principalColumn: "PastorId");
        }
    }
}
