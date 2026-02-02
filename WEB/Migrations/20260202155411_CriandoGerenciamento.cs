using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Migrations
{
    /// <inheritdoc />
    public partial class CriandoGerenciamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Igreja",
                table: "Diaconato");

            migrationBuilder.DropColumn(
                name: "NomePastor",
                table: "Diaconato");

            migrationBuilder.DropColumn(
                name: "NomeSuperintendenteEstadual",
                table: "Diaconato");

            migrationBuilder.DropColumn(
                name: "NomeSuperintendenteRegional",
                table: "Diaconato");

            migrationBuilder.DropColumn(
                name: "Regiao",
                table: "Diaconato");

            migrationBuilder.AlterColumn<string>(
                name: "NomeCompleto",
                table: "Diaconato",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Diaconato",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Diaconato",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataMinisterio",
                table: "Diaconato",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Contato",
                table: "Diaconato",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Diaconato",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cargo",
                table: "Diaconato",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Diaconato",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<Guid>(
                name: "IgrejaId",
                table: "Diaconato",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PastorId",
                table: "Diaconato",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RegiaoId",
                table: "Diaconato",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "SuperintendenteEstadual",
                columns: table => new
                {
                    SuperintendenteEstadualId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperintendenteEstadual", x => x.SuperintendenteEstadualId);
                });

            migrationBuilder.CreateTable(
                name: "SuperintendenteRegional",
                columns: table => new
                {
                    SuperintendenteRegionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperintendenteRegional", x => x.SuperintendenteRegionalId);
                });

            migrationBuilder.CreateTable(
                name: "Regiao",
                columns: table => new
                {
                    RegiaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SuperintendenteRegionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SuperintendenteEstadualId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiao", x => x.RegiaoId);
                    table.ForeignKey(
                        name: "FK_Regiao_SuperintendenteEstadual_SuperintendenteEstadualId",
                        column: x => x.SuperintendenteEstadualId,
                        principalTable: "SuperintendenteEstadual",
                        principalColumn: "SuperintendenteEstadualId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Regiao_SuperintendenteRegional_SuperintendenteRegionalId",
                        column: x => x.SuperintendenteRegionalId,
                        principalTable: "SuperintendenteRegional",
                        principalColumn: "SuperintendenteRegionalId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Igreja",
                columns: table => new
                {
                    IgrejaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RegiaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Igreja", x => x.IgrejaId);
                    table.ForeignKey(
                        name: "FK_Igreja_Regiao_RegiaoId",
                        column: x => x.RegiaoId,
                        principalTable: "Regiao",
                        principalColumn: "RegiaoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Membro",
                columns: table => new
                {
                    MembroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataBatismo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IgrejaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membro", x => x.MembroId);
                    table.ForeignKey(
                        name: "FK_Membro_Igreja_IgrejaId",
                        column: x => x.IgrejaId,
                        principalTable: "Igreja",
                        principalColumn: "IgrejaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pastores",
                columns: table => new
                {
                    PastorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IgrejaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pastores", x => x.PastorId);
                    table.ForeignKey(
                        name: "FK_Pastores_Igreja_IgrejaId",
                        column: x => x.IgrejaId,
                        principalTable: "Igreja",
                        principalColumn: "IgrejaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diaconato_IgrejaId",
                table: "Diaconato",
                column: "IgrejaId");

            migrationBuilder.CreateIndex(
                name: "IX_Diaconato_PastorId",
                table: "Diaconato",
                column: "PastorId");

            migrationBuilder.CreateIndex(
                name: "IX_Diaconato_RegiaoId",
                table: "Diaconato",
                column: "RegiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Igreja_RegiaoId",
                table: "Igreja",
                column: "RegiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_CPF",
                table: "Membro",
                column: "CPF",
                unique: true,
                filter: "[CPF] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_IgrejaId",
                table: "Membro",
                column: "IgrejaId");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_NomeCompleto",
                table: "Membro",
                column: "NomeCompleto");

            migrationBuilder.CreateIndex(
                name: "IX_Pastores_IgrejaId",
                table: "Pastores",
                column: "IgrejaId");

            migrationBuilder.CreateIndex(
                name: "IX_Regiao_SuperintendenteEstadualId",
                table: "Regiao",
                column: "SuperintendenteEstadualId");

            migrationBuilder.CreateIndex(
                name: "IX_Regiao_SuperintendenteRegionalId",
                table: "Regiao",
                column: "SuperintendenteRegionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diaconato_Igreja_IgrejaId",
                table: "Diaconato",
                column: "IgrejaId",
                principalTable: "Igreja",
                principalColumn: "IgrejaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diaconato_Pastores_PastorId",
                table: "Diaconato",
                column: "PastorId",
                principalTable: "Pastores",
                principalColumn: "PastorId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Diaconato_Regiao_RegiaoId",
                table: "Diaconato",
                column: "RegiaoId",
                principalTable: "Regiao",
                principalColumn: "RegiaoId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diaconato_Igreja_IgrejaId",
                table: "Diaconato");

            migrationBuilder.DropForeignKey(
                name: "FK_Diaconato_Pastores_PastorId",
                table: "Diaconato");

            migrationBuilder.DropForeignKey(
                name: "FK_Diaconato_Regiao_RegiaoId",
                table: "Diaconato");

            migrationBuilder.DropTable(
                name: "Membro");

            migrationBuilder.DropTable(
                name: "Pastores");

            migrationBuilder.DropTable(
                name: "Igreja");

            migrationBuilder.DropTable(
                name: "Regiao");

            migrationBuilder.DropTable(
                name: "SuperintendenteEstadual");

            migrationBuilder.DropTable(
                name: "SuperintendenteRegional");

            migrationBuilder.DropIndex(
                name: "IX_Diaconato_IgrejaId",
                table: "Diaconato");

            migrationBuilder.DropIndex(
                name: "IX_Diaconato_PastorId",
                table: "Diaconato");

            migrationBuilder.DropIndex(
                name: "IX_Diaconato_RegiaoId",
                table: "Diaconato");

            migrationBuilder.DropColumn(
                name: "IgrejaId",
                table: "Diaconato");

            migrationBuilder.DropColumn(
                name: "PastorId",
                table: "Diaconato");

            migrationBuilder.DropColumn(
                name: "RegiaoId",
                table: "Diaconato");

            migrationBuilder.AlterColumn<string>(
                name: "NomeCompleto",
                table: "Diaconato",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Diaconato",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Diaconato",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataMinisterio",
                table: "Diaconato",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Contato",
                table: "Diaconato",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Diaconato",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Cargo",
                table: "Diaconato",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Diaconato",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Igreja",
                table: "Diaconato",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomePastor",
                table: "Diaconato",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeSuperintendenteEstadual",
                table: "Diaconato",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeSuperintendenteRegional",
                table: "Diaconato",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Regiao",
                table: "Diaconato",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
