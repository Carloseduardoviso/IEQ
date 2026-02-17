using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Migrations
{
    /// <inheritdoc />
    public partial class Membro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Casals_Igreja_IgrejaId",
                table: "Casals");

            migrationBuilder.DropForeignKey(
                name: "FK_Casals_Pastores_PastorId",
                table: "Casals");

            migrationBuilder.DropForeignKey(
                name: "FK_Casals_Regiao_RegiaoId",
                table: "Casals");

            migrationBuilder.DropForeignKey(
                name: "FK_Casals_SuperintendenteEstadual_SuperintendenteEstadualId",
                table: "Casals");

            migrationBuilder.DropForeignKey(
                name: "FK_Casals_SuperintendenteRegional_SuperintendenteRegionalId",
                table: "Casals");

            migrationBuilder.DropForeignKey(
                name: "FK_Membro_Igreja_IgrejaId",
                table: "Membro");

            migrationBuilder.DropIndex(
                name: "IX_Membro_CPF",
                table: "Membro");

            migrationBuilder.DropIndex(
                name: "IX_Membro_NomeCompleto",
                table: "Membro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Casals",
                table: "Casals");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Membro");

            migrationBuilder.RenameTable(
                name: "Casals",
                newName: "Casal");

            migrationBuilder.RenameIndex(
                name: "IX_Casals_SuperintendenteRegionalId",
                table: "Casal",
                newName: "IX_Casal_SuperintendenteRegionalId");

            migrationBuilder.RenameIndex(
                name: "IX_Casals_SuperintendenteEstadualId",
                table: "Casal",
                newName: "IX_Casal_SuperintendenteEstadualId");

            migrationBuilder.RenameIndex(
                name: "IX_Casals_RegiaoId",
                table: "Casal",
                newName: "IX_Casal_RegiaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Casals_PastorId",
                table: "Casal",
                newName: "IX_Casal_PastorId");

            migrationBuilder.RenameIndex(
                name: "IX_Casals_IgrejaId",
                table: "Casal",
                newName: "IX_Casal_IgrejaId");

            migrationBuilder.AlterColumn<string>(
                name: "NomeCompleto",
                table: "Membro",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Membro",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Membro",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contato",
                table: "Membro",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInativacao",
                table: "Membro",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataMinisterio",
                table: "Membro",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataReativacao",
                table: "Membro",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PastorId",
                table: "Membro",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RegiaoId",
                table: "Membro",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SuperintendenteEstadualId",
                table: "Membro",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SuperintendenteRegionalId",
                table: "Membro",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TempoAcumuladoEmMeses",
                table: "Membro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "NomeCompleto",
                table: "Casal",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Casal",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Casal",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Casal",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Casal",
                table: "Casal",
                column: "CasalId");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_PastorId",
                table: "Membro",
                column: "PastorId");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_RegiaoId",
                table: "Membro",
                column: "RegiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_SuperintendenteEstadualId",
                table: "Membro",
                column: "SuperintendenteEstadualId");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_SuperintendenteRegionalId",
                table: "Membro",
                column: "SuperintendenteRegionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Casal_Igreja_IgrejaId",
                table: "Casal",
                column: "IgrejaId",
                principalTable: "Igreja",
                principalColumn: "IgrejaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Casal_Pastores_PastorId",
                table: "Casal",
                column: "PastorId",
                principalTable: "Pastores",
                principalColumn: "PastorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Casal_Regiao_RegiaoId",
                table: "Casal",
                column: "RegiaoId",
                principalTable: "Regiao",
                principalColumn: "RegiaoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Casal_SuperintendenteEstadual_SuperintendenteEstadualId",
                table: "Casal",
                column: "SuperintendenteEstadualId",
                principalTable: "SuperintendenteEstadual",
                principalColumn: "SuperintendenteEstadualId");

            migrationBuilder.AddForeignKey(
                name: "FK_Casal_SuperintendenteRegional_SuperintendenteRegionalId",
                table: "Casal",
                column: "SuperintendenteRegionalId",
                principalTable: "SuperintendenteRegional",
                principalColumn: "SuperintendenteRegionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membro_Igreja_IgrejaId",
                table: "Membro",
                column: "IgrejaId",
                principalTable: "Igreja",
                principalColumn: "IgrejaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Membro_Pastores_PastorId",
                table: "Membro",
                column: "PastorId",
                principalTable: "Pastores",
                principalColumn: "PastorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membro_Regiao_RegiaoId",
                table: "Membro",
                column: "RegiaoId",
                principalTable: "Regiao",
                principalColumn: "RegiaoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Membro_SuperintendenteEstadual_SuperintendenteEstadualId",
                table: "Membro",
                column: "SuperintendenteEstadualId",
                principalTable: "SuperintendenteEstadual",
                principalColumn: "SuperintendenteEstadualId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membro_SuperintendenteRegional_SuperintendenteRegionalId",
                table: "Membro",
                column: "SuperintendenteRegionalId",
                principalTable: "SuperintendenteRegional",
                principalColumn: "SuperintendenteRegionalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Casal_Igreja_IgrejaId",
                table: "Casal");

            migrationBuilder.DropForeignKey(
                name: "FK_Casal_Pastores_PastorId",
                table: "Casal");

            migrationBuilder.DropForeignKey(
                name: "FK_Casal_Regiao_RegiaoId",
                table: "Casal");

            migrationBuilder.DropForeignKey(
                name: "FK_Casal_SuperintendenteEstadual_SuperintendenteEstadualId",
                table: "Casal");

            migrationBuilder.DropForeignKey(
                name: "FK_Casal_SuperintendenteRegional_SuperintendenteRegionalId",
                table: "Casal");

            migrationBuilder.DropForeignKey(
                name: "FK_Membro_Igreja_IgrejaId",
                table: "Membro");

            migrationBuilder.DropForeignKey(
                name: "FK_Membro_Pastores_PastorId",
                table: "Membro");

            migrationBuilder.DropForeignKey(
                name: "FK_Membro_Regiao_RegiaoId",
                table: "Membro");

            migrationBuilder.DropForeignKey(
                name: "FK_Membro_SuperintendenteEstadual_SuperintendenteEstadualId",
                table: "Membro");

            migrationBuilder.DropForeignKey(
                name: "FK_Membro_SuperintendenteRegional_SuperintendenteRegionalId",
                table: "Membro");

            migrationBuilder.DropIndex(
                name: "IX_Membro_PastorId",
                table: "Membro");

            migrationBuilder.DropIndex(
                name: "IX_Membro_RegiaoId",
                table: "Membro");

            migrationBuilder.DropIndex(
                name: "IX_Membro_SuperintendenteEstadualId",
                table: "Membro");

            migrationBuilder.DropIndex(
                name: "IX_Membro_SuperintendenteRegionalId",
                table: "Membro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Casal",
                table: "Casal");

            migrationBuilder.DropColumn(
                name: "Contato",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "DataInativacao",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "DataMinisterio",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "DataReativacao",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "PastorId",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "RegiaoId",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "SuperintendenteEstadualId",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "SuperintendenteRegionalId",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "TempoAcumuladoEmMeses",
                table: "Membro");

            migrationBuilder.RenameTable(
                name: "Casal",
                newName: "Casals");

            migrationBuilder.RenameIndex(
                name: "IX_Casal_SuperintendenteRegionalId",
                table: "Casals",
                newName: "IX_Casals_SuperintendenteRegionalId");

            migrationBuilder.RenameIndex(
                name: "IX_Casal_SuperintendenteEstadualId",
                table: "Casals",
                newName: "IX_Casals_SuperintendenteEstadualId");

            migrationBuilder.RenameIndex(
                name: "IX_Casal_RegiaoId",
                table: "Casals",
                newName: "IX_Casals_RegiaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Casal_PastorId",
                table: "Casals",
                newName: "IX_Casals_PastorId");

            migrationBuilder.RenameIndex(
                name: "IX_Casal_IgrejaId",
                table: "Casals",
                newName: "IX_Casals_IgrejaId");

            migrationBuilder.AlterColumn<string>(
                name: "NomeCompleto",
                table: "Membro",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Membro",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Membro",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Membro",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Membro",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Membro",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeCompleto",
                table: "Casals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Casals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Casals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Casals",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Casals",
                table: "Casals",
                column: "CasalId");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_CPF",
                table: "Membro",
                column: "CPF",
                unique: true,
                filter: "[CPF] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_NomeCompleto",
                table: "Membro",
                column: "NomeCompleto");

            migrationBuilder.AddForeignKey(
                name: "FK_Casals_Igreja_IgrejaId",
                table: "Casals",
                column: "IgrejaId",
                principalTable: "Igreja",
                principalColumn: "IgrejaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Casals_Pastores_PastorId",
                table: "Casals",
                column: "PastorId",
                principalTable: "Pastores",
                principalColumn: "PastorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Casals_Regiao_RegiaoId",
                table: "Casals",
                column: "RegiaoId",
                principalTable: "Regiao",
                principalColumn: "RegiaoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Casals_SuperintendenteEstadual_SuperintendenteEstadualId",
                table: "Casals",
                column: "SuperintendenteEstadualId",
                principalTable: "SuperintendenteEstadual",
                principalColumn: "SuperintendenteEstadualId");

            migrationBuilder.AddForeignKey(
                name: "FK_Casals_SuperintendenteRegional_SuperintendenteRegionalId",
                table: "Casals",
                column: "SuperintendenteRegionalId",
                principalTable: "SuperintendenteRegional",
                principalColumn: "SuperintendenteRegionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membro_Igreja_IgrejaId",
                table: "Membro",
                column: "IgrejaId",
                principalTable: "Igreja",
                principalColumn: "IgrejaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
