using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Migrations
{
    /// <inheritdoc />
    public partial class User : Migration
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

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Contato",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DataBatismo",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DataMinisterio",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "PastorId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "SuperintendenteEstadualId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "SuperintendenteRegionalId",
                table: "Usuario");

            migrationBuilder.AlterColumn<Guid>(
                name: "RegiaoId",
                table: "Usuario",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IgrejaId",
                table: "Usuario",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Membro",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Membro_UsuarioId",
                table: "Membro",
                column: "UsuarioId",
                unique: true,
                filter: "[UsuarioId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Membro_Usuario_UsuarioId",
                table: "Membro",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

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
                name: "UsuarioId",
                table: "Membro");

            migrationBuilder.AlterColumn<Guid>(
                name: "RegiaoId",
                table: "Usuario",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IgrejaId",
                table: "Usuario",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contato",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataBatismo",
                table: "Usuario",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataMinisterio",
                table: "Usuario",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Usuario",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Genero",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "PastorId",
                table: "Usuario",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SuperintendenteEstadualId",
                table: "Usuario",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SuperintendenteRegionalId",
                table: "Usuario",
                type: "uniqueidentifier",
                nullable: true);

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
