using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Migrations
{
    /// <inheritdoc />
    public partial class Casal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuario_Email",
                table: "Usuario");

            migrationBuilder.AlterColumn<string>(
                name: "SenhaHash",
                table: "Usuario",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuario",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.CreateTable(
                name: "Casals",
                columns: table => new
                {
                    CasalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IgrejaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegiaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PastorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SuperintendenteEstadualId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SuperintendenteRegionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoLocal = table.Column<int>(type: "int", nullable: false),
                    CargoRegional = table.Column<int>(type: "int", nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataMinisterio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataBatismo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TempoAcumuladoEmMeses = table.Column<int>(type: "int", nullable: false),
                    DataReativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataInativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casals", x => x.CasalId);
                    table.ForeignKey(
                        name: "FK_Casals_Igreja_IgrejaId",
                        column: x => x.IgrejaId,
                        principalTable: "Igreja",
                        principalColumn: "IgrejaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Casals_Pastores_PastorId",
                        column: x => x.PastorId,
                        principalTable: "Pastores",
                        principalColumn: "PastorId");
                    table.ForeignKey(
                        name: "FK_Casals_Regiao_RegiaoId",
                        column: x => x.RegiaoId,
                        principalTable: "Regiao",
                        principalColumn: "RegiaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Casals_SuperintendenteEstadual_SuperintendenteEstadualId",
                        column: x => x.SuperintendenteEstadualId,
                        principalTable: "SuperintendenteEstadual",
                        principalColumn: "SuperintendenteEstadualId");
                    table.ForeignKey(
                        name: "FK_Casals_SuperintendenteRegional_SuperintendenteRegionalId",
                        column: x => x.SuperintendenteRegionalId,
                        principalTable: "SuperintendenteRegional",
                        principalColumn: "SuperintendenteRegionalId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Casals_IgrejaId",
                table: "Casals",
                column: "IgrejaId");

            migrationBuilder.CreateIndex(
                name: "IX_Casals_PastorId",
                table: "Casals",
                column: "PastorId");

            migrationBuilder.CreateIndex(
                name: "IX_Casals_RegiaoId",
                table: "Casals",
                column: "RegiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Casals_SuperintendenteEstadualId",
                table: "Casals",
                column: "SuperintendenteEstadualId");

            migrationBuilder.CreateIndex(
                name: "IX_Casals_SuperintendenteRegionalId",
                table: "Casals",
                column: "SuperintendenteRegionalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Casals");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_Email",
                table: "Usuario");

            migrationBuilder.AlterColumn<string>(
                name: "SenhaHash",
                table: "Usuario",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuario",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);
        }
    }
}
