using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SuperintendenteEstadual",
                columns: table => new
                {
                    SuperintendenteEstadualId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
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
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
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
                    SuperintendenteRegionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    RegiaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
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
                    IgrejaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegiaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IgrejaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SenhaHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimoLogin = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_Igreja_IgrejaId",
                        column: x => x.IgrejaId,
                        principalTable: "Igreja",
                        principalColumn: "IgrejaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Regiao_RegiaoId",
                        column: x => x.RegiaoId,
                        principalTable: "Regiao",
                        principalColumn: "RegiaoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diaconato",
                columns: table => new
                {
                    DiaconatoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IgrejaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegiaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PastorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataMinisterio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataBatismo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TempoAcumuladoEmMeses = table.Column<int>(type: "int", nullable: false),
                    DataReativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataInativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoUrlConsagracao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoUrl5Anos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoUrl10Anos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoUrl15Anos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoUrl20Anos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoUrl25Anos = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diaconato", x => x.DiaconatoId);
                    table.ForeignKey(
                        name: "FK_Diaconato_Igreja_IgrejaId",
                        column: x => x.IgrejaId,
                        principalTable: "Igreja",
                        principalColumn: "IgrejaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diaconato_Pastores_PastorId",
                        column: x => x.PastorId,
                        principalTable: "Pastores",
                        principalColumn: "PastorId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Diaconato_Regiao_RegiaoId",
                        column: x => x.RegiaoId,
                        principalTable: "Regiao",
                        principalColumn: "RegiaoId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IgrejaId",
                table: "Usuario",
                column: "IgrejaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RegiaoId",
                table: "Usuario",
                column: "RegiaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diaconato");

            migrationBuilder.DropTable(
                name: "Membro");

            migrationBuilder.DropTable(
                name: "Usuario");

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
        }
    }
}
