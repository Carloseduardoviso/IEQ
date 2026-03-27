using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Migrations
{
    /// <inheritdoc />
    public partial class upy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CargoRegional",
                table: "Pastores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "CasalId",
                table: "Membro",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CriancaId",
                table: "Membro",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DancaId",
                table: "Membro",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DiaconatoId",
                table: "Membro",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "HomensId",
                table: "Membro",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "JovemAdolescenteJovemAdolecenteId",
                table: "Membro",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LouvorId",
                table: "Membro",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MidiaId",
                table: "Membro",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MulheresId",
                table: "Membro",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TeatroId",
                table: "Membro",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Membro_CasalId",
                table: "Membro",
                column: "CasalId");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_CriancaId",
                table: "Membro",
                column: "CriancaId");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_DancaId",
                table: "Membro",
                column: "DancaId");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_DiaconatoId",
                table: "Membro",
                column: "DiaconatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_HomensId",
                table: "Membro",
                column: "HomensId");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_JovemAdolescenteJovemAdolecenteId",
                table: "Membro",
                column: "JovemAdolescenteJovemAdolecenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_LouvorId",
                table: "Membro",
                column: "LouvorId");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_MidiaId",
                table: "Membro",
                column: "MidiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_MulheresId",
                table: "Membro",
                column: "MulheresId");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_TeatroId",
                table: "Membro",
                column: "TeatroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membro_Casal_CasalId",
                table: "Membro",
                column: "CasalId",
                principalTable: "Casal",
                principalColumn: "CasalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membro_Crianca_CriancaId",
                table: "Membro",
                column: "CriancaId",
                principalTable: "Crianca",
                principalColumn: "CriancaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membro_Danca_DancaId",
                table: "Membro",
                column: "DancaId",
                principalTable: "Danca",
                principalColumn: "DancaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membro_Diaconato_DiaconatoId",
                table: "Membro",
                column: "DiaconatoId",
                principalTable: "Diaconato",
                principalColumn: "DiaconatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membro_Homens_HomensId",
                table: "Membro",
                column: "HomensId",
                principalTable: "Homens",
                principalColumn: "HomensId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membro_JovemAdolescente_JovemAdolescenteJovemAdolecenteId",
                table: "Membro",
                column: "JovemAdolescenteJovemAdolecenteId",
                principalTable: "JovemAdolescente",
                principalColumn: "JovemAdolecenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membro_Louvor_LouvorId",
                table: "Membro",
                column: "LouvorId",
                principalTable: "Louvor",
                principalColumn: "LouvorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membro_Midia_MidiaId",
                table: "Membro",
                column: "MidiaId",
                principalTable: "Midia",
                principalColumn: "MidiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membro_Mulheres_MulheresId",
                table: "Membro",
                column: "MulheresId",
                principalTable: "Mulheres",
                principalColumn: "MulheresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membro_Teatro_TeatroId",
                table: "Membro",
                column: "TeatroId",
                principalTable: "Teatro",
                principalColumn: "TeatroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membro_Casal_CasalId",
                table: "Membro");

            migrationBuilder.DropForeignKey(
                name: "FK_Membro_Crianca_CriancaId",
                table: "Membro");

            migrationBuilder.DropForeignKey(
                name: "FK_Membro_Danca_DancaId",
                table: "Membro");

            migrationBuilder.DropForeignKey(
                name: "FK_Membro_Diaconato_DiaconatoId",
                table: "Membro");

            migrationBuilder.DropForeignKey(
                name: "FK_Membro_Homens_HomensId",
                table: "Membro");

            migrationBuilder.DropForeignKey(
                name: "FK_Membro_JovemAdolescente_JovemAdolescenteJovemAdolecenteId",
                table: "Membro");

            migrationBuilder.DropForeignKey(
                name: "FK_Membro_Louvor_LouvorId",
                table: "Membro");

            migrationBuilder.DropForeignKey(
                name: "FK_Membro_Midia_MidiaId",
                table: "Membro");

            migrationBuilder.DropForeignKey(
                name: "FK_Membro_Mulheres_MulheresId",
                table: "Membro");

            migrationBuilder.DropForeignKey(
                name: "FK_Membro_Teatro_TeatroId",
                table: "Membro");

            migrationBuilder.DropIndex(
                name: "IX_Membro_CasalId",
                table: "Membro");

            migrationBuilder.DropIndex(
                name: "IX_Membro_CriancaId",
                table: "Membro");

            migrationBuilder.DropIndex(
                name: "IX_Membro_DancaId",
                table: "Membro");

            migrationBuilder.DropIndex(
                name: "IX_Membro_DiaconatoId",
                table: "Membro");

            migrationBuilder.DropIndex(
                name: "IX_Membro_HomensId",
                table: "Membro");

            migrationBuilder.DropIndex(
                name: "IX_Membro_JovemAdolescenteJovemAdolecenteId",
                table: "Membro");

            migrationBuilder.DropIndex(
                name: "IX_Membro_LouvorId",
                table: "Membro");

            migrationBuilder.DropIndex(
                name: "IX_Membro_MidiaId",
                table: "Membro");

            migrationBuilder.DropIndex(
                name: "IX_Membro_MulheresId",
                table: "Membro");

            migrationBuilder.DropIndex(
                name: "IX_Membro_TeatroId",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "CasalId",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "CriancaId",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "DancaId",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "DiaconatoId",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "HomensId",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "JovemAdolescenteJovemAdolecenteId",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "LouvorId",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "MidiaId",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "MulheresId",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "TeatroId",
                table: "Membro");

            migrationBuilder.AlterColumn<int>(
                name: "CargoRegional",
                table: "Pastores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
