using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Migrations
{
    /// <inheritdoc />
    public partial class tj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diaconato_Pastores_PastorId",
                table: "Diaconato");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataMinisterio",
                table: "Diaconato",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "SuperintendenteEstadualId",
                table: "Diaconato",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SuperintendenteRegionalId",
                table: "Diaconato",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diaconato_SuperintendenteEstadualId",
                table: "Diaconato",
                column: "SuperintendenteEstadualId");

            migrationBuilder.CreateIndex(
                name: "IX_Diaconato_SuperintendenteRegionalId",
                table: "Diaconato",
                column: "SuperintendenteRegionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diaconato_Pastores_PastorId",
                table: "Diaconato",
                column: "PastorId",
                principalTable: "Pastores",
                principalColumn: "PastorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diaconato_SuperintendenteEstadual_SuperintendenteEstadualId",
                table: "Diaconato",
                column: "SuperintendenteEstadualId",
                principalTable: "SuperintendenteEstadual",
                principalColumn: "SuperintendenteEstadualId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diaconato_SuperintendenteRegional_SuperintendenteRegionalId",
                table: "Diaconato",
                column: "SuperintendenteRegionalId",
                principalTable: "SuperintendenteRegional",
                principalColumn: "SuperintendenteRegionalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diaconato_Pastores_PastorId",
                table: "Diaconato");

            migrationBuilder.DropForeignKey(
                name: "FK_Diaconato_SuperintendenteEstadual_SuperintendenteEstadualId",
                table: "Diaconato");

            migrationBuilder.DropForeignKey(
                name: "FK_Diaconato_SuperintendenteRegional_SuperintendenteRegionalId",
                table: "Diaconato");

            migrationBuilder.DropIndex(
                name: "IX_Diaconato_SuperintendenteEstadualId",
                table: "Diaconato");

            migrationBuilder.DropIndex(
                name: "IX_Diaconato_SuperintendenteRegionalId",
                table: "Diaconato");

            migrationBuilder.DropColumn(
                name: "SuperintendenteEstadualId",
                table: "Diaconato");

            migrationBuilder.DropColumn(
                name: "SuperintendenteRegionalId",
                table: "Diaconato");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataMinisterio",
                table: "Diaconato",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Diaconato_Pastores_PastorId",
                table: "Diaconato",
                column: "PastorId",
                principalTable: "Pastores",
                principalColumn: "PastorId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
