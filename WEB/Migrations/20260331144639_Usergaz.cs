using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Migrations
{
    /// <inheritdoc />
    public partial class Usergaz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Igreja_IgrejaId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Regiao_RegiaoId",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Usuario",
                newName: "NomeCompleto");                 


            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Igreja_IgrejaId",
                table: "Usuario",
                column: "IgrejaId",
                principalTable: "Igreja",
                principalColumn: "IgrejaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Regiao_RegiaoId",
                table: "Usuario",
                column: "RegiaoId",
                principalTable: "Regiao",
                principalColumn: "RegiaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membro_Usuario_UsuarioId",
                table: "Membro");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Igreja_IgrejaId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Regiao_RegiaoId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Membro_UsuarioId",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Membro");

            migrationBuilder.RenameColumn(
                name: "NomeCompleto",
                table: "Usuario",
                newName: "Nome");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Igreja_IgrejaId",
                table: "Usuario",
                column: "IgrejaId",
                principalTable: "Igreja",
                principalColumn: "IgrejaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Regiao_RegiaoId",
                table: "Usuario",
                column: "RegiaoId",
                principalTable: "Regiao",
                principalColumn: "RegiaoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
