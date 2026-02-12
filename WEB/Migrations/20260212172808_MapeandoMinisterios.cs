using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Migrations
{
    /// <inheritdoc />
    public partial class MapeandoMinisterios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diaconato_Igreja_IgrejaId",
                table: "Diaconato");

            migrationBuilder.DropForeignKey(
                name: "FK_Diaconato_Regiao_RegiaoId",
                table: "Diaconato");

            migrationBuilder.DropColumn(
                name: "Cargos",
                table: "Diaconato");

            migrationBuilder.AlterColumn<string>(
                name: "Contato",
                table: "Diaconato",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "CargoLocal",
                table: "Diaconato",
                type: "int",
                maxLength: 80,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CargoRegional",
                table: "Diaconato",
                type: "int",
                maxLength: 80,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Crianca",
                columns: table => new
                {
                    CriancaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IgrejaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegiaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PastorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SuperintendenteEstadualId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SuperintendenteRegionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NomeCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CargoLocal = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    CargoRegional = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataMinisterio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataBatismo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TempoAcumuladoEmMeses = table.Column<int>(type: "int", nullable: false),
                    DataReativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataInativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crianca", x => x.CriancaId);
                    table.ForeignKey(
                        name: "FK_Crianca_Igreja_IgrejaId",
                        column: x => x.IgrejaId,
                        principalTable: "Igreja",
                        principalColumn: "IgrejaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Crianca_Pastores_PastorId",
                        column: x => x.PastorId,
                        principalTable: "Pastores",
                        principalColumn: "PastorId");
                    table.ForeignKey(
                        name: "FK_Crianca_Regiao_RegiaoId",
                        column: x => x.RegiaoId,
                        principalTable: "Regiao",
                        principalColumn: "RegiaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Crianca_SuperintendenteEstadual_SuperintendenteEstadualId",
                        column: x => x.SuperintendenteEstadualId,
                        principalTable: "SuperintendenteEstadual",
                        principalColumn: "SuperintendenteEstadualId");
                    table.ForeignKey(
                        name: "FK_Crianca_SuperintendenteRegional_SuperintendenteRegionalId",
                        column: x => x.SuperintendenteRegionalId,
                        principalTable: "SuperintendenteRegional",
                        principalColumn: "SuperintendenteRegionalId");
                });

            migrationBuilder.CreateTable(
                name: "Homens",
                columns: table => new
                {
                    HomensId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IgrejaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegiaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PastorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SuperintendenteEstadualId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SuperintendenteRegionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NomeCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CargoLocal = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    CargoRegional = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataMinisterio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataBatismo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TempoAcumuladoEmMeses = table.Column<int>(type: "int", nullable: false),
                    DataReativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataInativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homens", x => x.HomensId);
                    table.ForeignKey(
                        name: "FK_Homens_Igreja_IgrejaId",
                        column: x => x.IgrejaId,
                        principalTable: "Igreja",
                        principalColumn: "IgrejaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Homens_Pastores_PastorId",
                        column: x => x.PastorId,
                        principalTable: "Pastores",
                        principalColumn: "PastorId");
                    table.ForeignKey(
                        name: "FK_Homens_Regiao_RegiaoId",
                        column: x => x.RegiaoId,
                        principalTable: "Regiao",
                        principalColumn: "RegiaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Homens_SuperintendenteEstadual_SuperintendenteEstadualId",
                        column: x => x.SuperintendenteEstadualId,
                        principalTable: "SuperintendenteEstadual",
                        principalColumn: "SuperintendenteEstadualId");
                    table.ForeignKey(
                        name: "FK_Homens_SuperintendenteRegional_SuperintendenteRegionalId",
                        column: x => x.SuperintendenteRegionalId,
                        principalTable: "SuperintendenteRegional",
                        principalColumn: "SuperintendenteRegionalId");
                });

            migrationBuilder.CreateTable(
                name: "JovemAdolescente",
                columns: table => new
                {
                    JovemAdolecenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IgrejaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegiaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PastorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SuperintendenteEstadualId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SuperintendenteRegionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NomeCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CargoLocal = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    CargoRegional = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataMinisterio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataBatismo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TempoAcumuladoEmMeses = table.Column<int>(type: "int", nullable: false),
                    DataReativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataInativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JovemAdolescente", x => x.JovemAdolecenteId);
                    table.ForeignKey(
                        name: "FK_JovemAdolescente_Igreja_IgrejaId",
                        column: x => x.IgrejaId,
                        principalTable: "Igreja",
                        principalColumn: "IgrejaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JovemAdolescente_Pastores_PastorId",
                        column: x => x.PastorId,
                        principalTable: "Pastores",
                        principalColumn: "PastorId");
                    table.ForeignKey(
                        name: "FK_JovemAdolescente_Regiao_RegiaoId",
                        column: x => x.RegiaoId,
                        principalTable: "Regiao",
                        principalColumn: "RegiaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JovemAdolescente_SuperintendenteEstadual_SuperintendenteEstadualId",
                        column: x => x.SuperintendenteEstadualId,
                        principalTable: "SuperintendenteEstadual",
                        principalColumn: "SuperintendenteEstadualId");
                    table.ForeignKey(
                        name: "FK_JovemAdolescente_SuperintendenteRegional_SuperintendenteRegionalId",
                        column: x => x.SuperintendenteRegionalId,
                        principalTable: "SuperintendenteRegional",
                        principalColumn: "SuperintendenteRegionalId");
                });

            migrationBuilder.CreateTable(
                name: "Louvor",
                columns: table => new
                {
                    CriancaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IgrejaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegiaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PastorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SuperintendenteEstadualId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SuperintendenteRegionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NomeCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CargoLocal = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    CargoRegional = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataMinisterio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataBatismo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TempoAcumuladoEmMeses = table.Column<int>(type: "int", nullable: false),
                    DataReativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataInativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Louvor", x => x.CriancaId);
                    table.ForeignKey(
                        name: "FK_Louvor_Igreja_IgrejaId",
                        column: x => x.IgrejaId,
                        principalTable: "Igreja",
                        principalColumn: "IgrejaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Louvor_Pastores_PastorId",
                        column: x => x.PastorId,
                        principalTable: "Pastores",
                        principalColumn: "PastorId");
                    table.ForeignKey(
                        name: "FK_Louvor_Regiao_RegiaoId",
                        column: x => x.RegiaoId,
                        principalTable: "Regiao",
                        principalColumn: "RegiaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Louvor_SuperintendenteEstadual_SuperintendenteEstadualId",
                        column: x => x.SuperintendenteEstadualId,
                        principalTable: "SuperintendenteEstadual",
                        principalColumn: "SuperintendenteEstadualId");
                    table.ForeignKey(
                        name: "FK_Louvor_SuperintendenteRegional_SuperintendenteRegionalId",
                        column: x => x.SuperintendenteRegionalId,
                        principalTable: "SuperintendenteRegional",
                        principalColumn: "SuperintendenteRegionalId");
                });

            migrationBuilder.CreateTable(
                name: "Midia",
                columns: table => new
                {
                    MidiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IgrejaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegiaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PastorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SuperintendenteEstadualId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SuperintendenteRegionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NomeCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CargoLocal = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    CargoRegional = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataMinisterio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataBatismo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TempoAcumuladoEmMeses = table.Column<int>(type: "int", nullable: false),
                    DataReativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataInativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Midia", x => x.MidiaId);
                    table.ForeignKey(
                        name: "FK_Midia_Igreja_IgrejaId",
                        column: x => x.IgrejaId,
                        principalTable: "Igreja",
                        principalColumn: "IgrejaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Midia_Pastores_PastorId",
                        column: x => x.PastorId,
                        principalTable: "Pastores",
                        principalColumn: "PastorId");
                    table.ForeignKey(
                        name: "FK_Midia_Regiao_RegiaoId",
                        column: x => x.RegiaoId,
                        principalTable: "Regiao",
                        principalColumn: "RegiaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Midia_SuperintendenteEstadual_SuperintendenteEstadualId",
                        column: x => x.SuperintendenteEstadualId,
                        principalTable: "SuperintendenteEstadual",
                        principalColumn: "SuperintendenteEstadualId");
                    table.ForeignKey(
                        name: "FK_Midia_SuperintendenteRegional_SuperintendenteRegionalId",
                        column: x => x.SuperintendenteRegionalId,
                        principalTable: "SuperintendenteRegional",
                        principalColumn: "SuperintendenteRegionalId");
                });

            migrationBuilder.CreateTable(
                name: "Mulheres",
                columns: table => new
                {
                    MulheresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IgrejaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegiaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PastorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SuperintendenteEstadualId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SuperintendenteRegionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NomeCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CargoLocal = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    CargoRegional = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataMinisterio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataBatismo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TempoAcumuladoEmMeses = table.Column<int>(type: "int", nullable: false),
                    DataReativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataInativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mulheres", x => x.MulheresId);
                    table.ForeignKey(
                        name: "FK_Mulheres_Igreja_IgrejaId",
                        column: x => x.IgrejaId,
                        principalTable: "Igreja",
                        principalColumn: "IgrejaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mulheres_Pastores_PastorId",
                        column: x => x.PastorId,
                        principalTable: "Pastores",
                        principalColumn: "PastorId");
                    table.ForeignKey(
                        name: "FK_Mulheres_Regiao_RegiaoId",
                        column: x => x.RegiaoId,
                        principalTable: "Regiao",
                        principalColumn: "RegiaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mulheres_SuperintendenteEstadual_SuperintendenteEstadualId",
                        column: x => x.SuperintendenteEstadualId,
                        principalTable: "SuperintendenteEstadual",
                        principalColumn: "SuperintendenteEstadualId");
                    table.ForeignKey(
                        name: "FK_Mulheres_SuperintendenteRegional_SuperintendenteRegionalId",
                        column: x => x.SuperintendenteRegionalId,
                        principalTable: "SuperintendenteRegional",
                        principalColumn: "SuperintendenteRegionalId");
                });

            migrationBuilder.CreateTable(
                name: "Teatro",
                columns: table => new
                {
                    TeatroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IgrejaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegiaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PastorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SuperintendenteEstadualId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SuperintendenteRegionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NomeCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CargoLocal = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    CargoRegional = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataMinisterio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataBatismo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TempoAcumuladoEmMeses = table.Column<int>(type: "int", nullable: false),
                    DataReativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataInativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teatro", x => x.TeatroId);
                    table.ForeignKey(
                        name: "FK_Teatro_Igreja_IgrejaId",
                        column: x => x.IgrejaId,
                        principalTable: "Igreja",
                        principalColumn: "IgrejaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teatro_Pastores_PastorId",
                        column: x => x.PastorId,
                        principalTable: "Pastores",
                        principalColumn: "PastorId");
                    table.ForeignKey(
                        name: "FK_Teatro_Regiao_RegiaoId",
                        column: x => x.RegiaoId,
                        principalTable: "Regiao",
                        principalColumn: "RegiaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teatro_SuperintendenteEstadual_SuperintendenteEstadualId",
                        column: x => x.SuperintendenteEstadualId,
                        principalTable: "SuperintendenteEstadual",
                        principalColumn: "SuperintendenteEstadualId");
                    table.ForeignKey(
                        name: "FK_Teatro_SuperintendenteRegional_SuperintendenteRegionalId",
                        column: x => x.SuperintendenteRegionalId,
                        principalTable: "SuperintendenteRegional",
                        principalColumn: "SuperintendenteRegionalId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crianca_IgrejaId",
                table: "Crianca",
                column: "IgrejaId");

            migrationBuilder.CreateIndex(
                name: "IX_Crianca_PastorId",
                table: "Crianca",
                column: "PastorId");

            migrationBuilder.CreateIndex(
                name: "IX_Crianca_RegiaoId",
                table: "Crianca",
                column: "RegiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Crianca_SuperintendenteEstadualId",
                table: "Crianca",
                column: "SuperintendenteEstadualId");

            migrationBuilder.CreateIndex(
                name: "IX_Crianca_SuperintendenteRegionalId",
                table: "Crianca",
                column: "SuperintendenteRegionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Homens_IgrejaId",
                table: "Homens",
                column: "IgrejaId");

            migrationBuilder.CreateIndex(
                name: "IX_Homens_PastorId",
                table: "Homens",
                column: "PastorId");

            migrationBuilder.CreateIndex(
                name: "IX_Homens_RegiaoId",
                table: "Homens",
                column: "RegiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Homens_SuperintendenteEstadualId",
                table: "Homens",
                column: "SuperintendenteEstadualId");

            migrationBuilder.CreateIndex(
                name: "IX_Homens_SuperintendenteRegionalId",
                table: "Homens",
                column: "SuperintendenteRegionalId");

            migrationBuilder.CreateIndex(
                name: "IX_JovemAdolescente_IgrejaId",
                table: "JovemAdolescente",
                column: "IgrejaId");

            migrationBuilder.CreateIndex(
                name: "IX_JovemAdolescente_PastorId",
                table: "JovemAdolescente",
                column: "PastorId");

            migrationBuilder.CreateIndex(
                name: "IX_JovemAdolescente_RegiaoId",
                table: "JovemAdolescente",
                column: "RegiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_JovemAdolescente_SuperintendenteEstadualId",
                table: "JovemAdolescente",
                column: "SuperintendenteEstadualId");

            migrationBuilder.CreateIndex(
                name: "IX_JovemAdolescente_SuperintendenteRegionalId",
                table: "JovemAdolescente",
                column: "SuperintendenteRegionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Louvor_IgrejaId",
                table: "Louvor",
                column: "IgrejaId");

            migrationBuilder.CreateIndex(
                name: "IX_Louvor_PastorId",
                table: "Louvor",
                column: "PastorId");

            migrationBuilder.CreateIndex(
                name: "IX_Louvor_RegiaoId",
                table: "Louvor",
                column: "RegiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Louvor_SuperintendenteEstadualId",
                table: "Louvor",
                column: "SuperintendenteEstadualId");

            migrationBuilder.CreateIndex(
                name: "IX_Louvor_SuperintendenteRegionalId",
                table: "Louvor",
                column: "SuperintendenteRegionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Midia_IgrejaId",
                table: "Midia",
                column: "IgrejaId");

            migrationBuilder.CreateIndex(
                name: "IX_Midia_PastorId",
                table: "Midia",
                column: "PastorId");

            migrationBuilder.CreateIndex(
                name: "IX_Midia_RegiaoId",
                table: "Midia",
                column: "RegiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Midia_SuperintendenteEstadualId",
                table: "Midia",
                column: "SuperintendenteEstadualId");

            migrationBuilder.CreateIndex(
                name: "IX_Midia_SuperintendenteRegionalId",
                table: "Midia",
                column: "SuperintendenteRegionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Mulheres_IgrejaId",
                table: "Mulheres",
                column: "IgrejaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mulheres_PastorId",
                table: "Mulheres",
                column: "PastorId");

            migrationBuilder.CreateIndex(
                name: "IX_Mulheres_RegiaoId",
                table: "Mulheres",
                column: "RegiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mulheres_SuperintendenteEstadualId",
                table: "Mulheres",
                column: "SuperintendenteEstadualId");

            migrationBuilder.CreateIndex(
                name: "IX_Mulheres_SuperintendenteRegionalId",
                table: "Mulheres",
                column: "SuperintendenteRegionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Teatro_IgrejaId",
                table: "Teatro",
                column: "IgrejaId");

            migrationBuilder.CreateIndex(
                name: "IX_Teatro_PastorId",
                table: "Teatro",
                column: "PastorId");

            migrationBuilder.CreateIndex(
                name: "IX_Teatro_RegiaoId",
                table: "Teatro",
                column: "RegiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Teatro_SuperintendenteEstadualId",
                table: "Teatro",
                column: "SuperintendenteEstadualId");

            migrationBuilder.CreateIndex(
                name: "IX_Teatro_SuperintendenteRegionalId",
                table: "Teatro",
                column: "SuperintendenteRegionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diaconato_Igreja_IgrejaId",
                table: "Diaconato",
                column: "IgrejaId",
                principalTable: "Igreja",
                principalColumn: "IgrejaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Diaconato_Regiao_RegiaoId",
                table: "Diaconato",
                column: "RegiaoId",
                principalTable: "Regiao",
                principalColumn: "RegiaoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diaconato_Igreja_IgrejaId",
                table: "Diaconato");

            migrationBuilder.DropForeignKey(
                name: "FK_Diaconato_Regiao_RegiaoId",
                table: "Diaconato");

            migrationBuilder.DropTable(
                name: "Crianca");

            migrationBuilder.DropTable(
                name: "Homens");

            migrationBuilder.DropTable(
                name: "JovemAdolescente");

            migrationBuilder.DropTable(
                name: "Louvor");

            migrationBuilder.DropTable(
                name: "Midia");

            migrationBuilder.DropTable(
                name: "Mulheres");

            migrationBuilder.DropTable(
                name: "Teatro");

            migrationBuilder.DropColumn(
                name: "CargoLocal",
                table: "Diaconato");

            migrationBuilder.DropColumn(
                name: "CargoRegional",
                table: "Diaconato");

            migrationBuilder.AlterColumn<string>(
                name: "Contato",
                table: "Diaconato",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cargos",
                table: "Diaconato",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Diaconato_Igreja_IgrejaId",
                table: "Diaconato",
                column: "IgrejaId",
                principalTable: "Igreja",
                principalColumn: "IgrejaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diaconato_Regiao_RegiaoId",
                table: "Diaconato",
                column: "RegiaoId",
                principalTable: "Regiao",
                principalColumn: "RegiaoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
