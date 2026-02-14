using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Migrations
{
    /// <inheritdoc />
    public partial class Danca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.RenameColumn(
            //    name: "LouvorId",
            //    table: "Crianca",
            //    newName: "CriancaId");

            migrationBuilder.CreateTable(
                name: "Danca",
                columns: table => new
                {
                    DancaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Danca", x => x.DancaId);
                    table.ForeignKey(
                        name: "FK_Danca_Igreja_IgrejaId",
                        column: x => x.IgrejaId,
                        principalTable: "Igreja",
                        principalColumn: "IgrejaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Danca_Pastores_PastorId",
                        column: x => x.PastorId,
                        principalTable: "Pastores",
                        principalColumn: "PastorId");
                    table.ForeignKey(
                        name: "FK_Danca_Regiao_RegiaoId",
                        column: x => x.RegiaoId,
                        principalTable: "Regiao",
                        principalColumn: "RegiaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Danca_SuperintendenteEstadual_SuperintendenteEstadualId",
                        column: x => x.SuperintendenteEstadualId,
                        principalTable: "SuperintendenteEstadual",
                        principalColumn: "SuperintendenteEstadualId");
                    table.ForeignKey(
                        name: "FK_Danca_SuperintendenteRegional_SuperintendenteRegionalId",
                        column: x => x.SuperintendenteRegionalId,
                        principalTable: "SuperintendenteRegional",
                        principalColumn: "SuperintendenteRegionalId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Danca_IgrejaId",
                table: "Danca",
                column: "IgrejaId");

            migrationBuilder.CreateIndex(
                name: "IX_Danca_PastorId",
                table: "Danca",
                column: "PastorId");

            migrationBuilder.CreateIndex(
                name: "IX_Danca_RegiaoId",
                table: "Danca",
                column: "RegiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Danca_SuperintendenteEstadualId",
                table: "Danca",
                column: "SuperintendenteEstadualId");

            migrationBuilder.CreateIndex(
                name: "IX_Danca_SuperintendenteRegionalId",
                table: "Danca",
                column: "SuperintendenteRegionalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Danca");

            migrationBuilder.RenameColumn(
                name: "CriancaId",
                table: "Crianca",
                newName: "LouvorId");
        }
    }
}
