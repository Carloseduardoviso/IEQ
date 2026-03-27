using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Migrations
{
    /// <inheritdoc />
    public partial class upykl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membro_Casal_CasalId",
                table: "Membro");

            migrationBuilder.DropIndex(
                name: "IX_Membro_CasalId",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "CasalId",
                table: "Membro");

            migrationBuilder.AddColumn<Guid>(
                name: "MembroId",
                table: "Casal",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Casal_MembroId",
                table: "Casal",
                column: "MembroId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Casal_Membro_MembroId",
                table: "Casal",
                column: "MembroId",
                principalTable: "Membro",
                principalColumn: "MembroId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Casal_Membro_MembroId",
                table: "Casal");

            migrationBuilder.DropIndex(
                name: "IX_Casal_MembroId",
                table: "Casal");

            migrationBuilder.DropColumn(
                name: "MembroId",
                table: "Casal");

            migrationBuilder.AddColumn<Guid>(
                name: "CasalId",
                table: "Membro",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Membro_CasalId",
                table: "Membro",
                column: "CasalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membro_Casal_CasalId",
                table: "Membro",
                column: "CasalId",
                principalTable: "Casal",
                principalColumn: "CasalId");
        }
    }
}
