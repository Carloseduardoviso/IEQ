using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Migrations
{
    /// <inheritdoc />
    public partial class upykls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "MembroId",
                table: "Teatro",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MembroId",
                table: "Mulheres",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MembroId",
                table: "Midia",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MembroId",
                table: "Louvor",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MembroId",
                table: "JovemAdolescente",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MembroId",
                table: "Homens",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MembroId",
                table: "Diaconato",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MembroId",
                table: "Danca",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MembroId",
                table: "Crianca",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Teatro_MembroId",
                table: "Teatro",
                column: "MembroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mulheres_MembroId",
                table: "Mulheres",
                column: "MembroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Midia_MembroId",
                table: "Midia",
                column: "MembroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Louvor_MembroId",
                table: "Louvor",
                column: "MembroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JovemAdolescente_MembroId",
                table: "JovemAdolescente",
                column: "MembroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Homens_MembroId",
                table: "Homens",
                column: "MembroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diaconato_MembroId",
                table: "Diaconato",
                column: "MembroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Danca_MembroId",
                table: "Danca",
                column: "MembroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Crianca_MembroId",
                table: "Crianca",
                column: "MembroId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Crianca_Membro_MembroId",
                table: "Crianca",
                column: "MembroId",
                principalTable: "Membro",
                principalColumn: "MembroId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Danca_Membro_MembroId",
                table: "Danca",
                column: "MembroId",
                principalTable: "Membro",
                principalColumn: "MembroId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diaconato_Membro_MembroId",
                table: "Diaconato",
                column: "MembroId",
                principalTable: "Membro",
                principalColumn: "MembroId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Homens_Membro_MembroId",
                table: "Homens",
                column: "MembroId",
                principalTable: "Membro",
                principalColumn: "MembroId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JovemAdolescente_Membro_MembroId",
                table: "JovemAdolescente",
                column: "MembroId",
                principalTable: "Membro",
                principalColumn: "MembroId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Louvor_Membro_MembroId",
                table: "Louvor",
                column: "MembroId",
                principalTable: "Membro",
                principalColumn: "MembroId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Midia_Membro_MembroId",
                table: "Midia",
                column: "MembroId",
                principalTable: "Membro",
                principalColumn: "MembroId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mulheres_Membro_MembroId",
                table: "Mulheres",
                column: "MembroId",
                principalTable: "Membro",
                principalColumn: "MembroId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teatro_Membro_MembroId",
                table: "Teatro",
                column: "MembroId",
                principalTable: "Membro",
                principalColumn: "MembroId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crianca_Membro_MembroId",
                table: "Crianca");

            migrationBuilder.DropForeignKey(
                name: "FK_Danca_Membro_MembroId",
                table: "Danca");

            migrationBuilder.DropForeignKey(
                name: "FK_Diaconato_Membro_MembroId",
                table: "Diaconato");

            migrationBuilder.DropForeignKey(
                name: "FK_Homens_Membro_MembroId",
                table: "Homens");

            migrationBuilder.DropForeignKey(
                name: "FK_JovemAdolescente_Membro_MembroId",
                table: "JovemAdolescente");

            migrationBuilder.DropForeignKey(
                name: "FK_Louvor_Membro_MembroId",
                table: "Louvor");

            migrationBuilder.DropForeignKey(
                name: "FK_Midia_Membro_MembroId",
                table: "Midia");

            migrationBuilder.DropForeignKey(
                name: "FK_Mulheres_Membro_MembroId",
                table: "Mulheres");

            migrationBuilder.DropForeignKey(
                name: "FK_Teatro_Membro_MembroId",
                table: "Teatro");

            migrationBuilder.DropIndex(
                name: "IX_Teatro_MembroId",
                table: "Teatro");

            migrationBuilder.DropIndex(
                name: "IX_Mulheres_MembroId",
                table: "Mulheres");

            migrationBuilder.DropIndex(
                name: "IX_Midia_MembroId",
                table: "Midia");

            migrationBuilder.DropIndex(
                name: "IX_Louvor_MembroId",
                table: "Louvor");

            migrationBuilder.DropIndex(
                name: "IX_JovemAdolescente_MembroId",
                table: "JovemAdolescente");

            migrationBuilder.DropIndex(
                name: "IX_Homens_MembroId",
                table: "Homens");

            migrationBuilder.DropIndex(
                name: "IX_Diaconato_MembroId",
                table: "Diaconato");

            migrationBuilder.DropIndex(
                name: "IX_Danca_MembroId",
                table: "Danca");

            migrationBuilder.DropIndex(
                name: "IX_Crianca_MembroId",
                table: "Crianca");

            migrationBuilder.DropColumn(
                name: "MembroId",
                table: "Teatro");

            migrationBuilder.DropColumn(
                name: "MembroId",
                table: "Mulheres");

            migrationBuilder.DropColumn(
                name: "MembroId",
                table: "Midia");

            migrationBuilder.DropColumn(
                name: "MembroId",
                table: "Louvor");

            migrationBuilder.DropColumn(
                name: "MembroId",
                table: "JovemAdolescente");

            migrationBuilder.DropColumn(
                name: "MembroId",
                table: "Homens");

            migrationBuilder.DropColumn(
                name: "MembroId",
                table: "Diaconato");

            migrationBuilder.DropColumn(
                name: "MembroId",
                table: "Danca");

            migrationBuilder.DropColumn(
                name: "MembroId",
                table: "Crianca");

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
    }
}
