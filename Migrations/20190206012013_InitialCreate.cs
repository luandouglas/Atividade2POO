using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atividade1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bancos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agencia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BancoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agencia_Bancos_BancoId",
                        column: x => x.BancoId,
                        principalTable: "Bancos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContasCorrentes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titular = table.Column<string>(nullable: true),
                    Saldo = table.Column<decimal>(nullable: false),
                    AgenciaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasCorrentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasCorrentes_Agencia_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "Agencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContasPoupanca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Juros = table.Column<decimal>(nullable: false),
                    DataAniversario = table.Column<DateTime>(nullable: false),
                    Saldo = table.Column<decimal>(nullable: false),
                    Titular = table.Column<string>(nullable: true),
                    AgenciaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasPoupanca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasPoupanca_Agencia_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "Agencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Solicitacoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AgenciaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitacoes_Agencia_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "Agencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agencia_BancoId",
                table: "Agencia",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasCorrentes_AgenciaId",
                table: "ContasCorrentes",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasPoupanca_AgenciaId",
                table: "ContasPoupanca",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacoes_AgenciaId",
                table: "Solicitacoes",
                column: "AgenciaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "ContasCorrentes");

            migrationBuilder.DropTable(
                name: "ContasPoupanca");

            migrationBuilder.DropTable(
                name: "Solicitacoes");

            migrationBuilder.DropTable(
                name: "Agencia");

            migrationBuilder.DropTable(
                name: "Bancos");
        }
    }
}
