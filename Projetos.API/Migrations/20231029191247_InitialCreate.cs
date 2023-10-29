using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projetos.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCliente = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    InformacaoContato = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    IdProjeto = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataConclusaoPrevista = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    ClienteIdCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    IdEquipe = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.IdProjeto);
                    table.ForeignKey(
                        name: "FK_Projetos_Clientes_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    IdEquipe = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeEquipe = table.Column<string>(type: "TEXT", nullable: false),
                    IdProjeto = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.IdEquipe);
                    table.ForeignKey(
                        name: "FK_Equipes_Projetos_IdProjeto",
                        column: x => x.IdProjeto,
                        principalTable: "Projetos",
                        principalColumn: "IdProjeto");
                });

            migrationBuilder.CreateTable(
                name: "Sprints",
                columns: table => new
                {
                    IdSprint = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdProjeto = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjetoIdProjeto = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprints", x => x.IdSprint);
                    table.ForeignKey(
                        name: "FK_Sprints_Projetos_ProjetoIdProjeto",
                        column: x => x.ProjetoIdProjeto,
                        principalTable: "Projetos",
                        principalColumn: "IdProjeto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Membros",
                columns: table => new
                {
                    IdMembro = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeMembro = table.Column<string>(type: "TEXT", nullable: false),
                    Papel = table.Column<string>(type: "TEXT", nullable: false),
                    IdEquipe = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membros", x => x.IdMembro);
                    table.ForeignKey(
                        name: "FK_Membros_Equipes_IdEquipe",
                        column: x => x.IdEquipe,
                        principalTable: "Equipes",
                        principalColumn: "IdEquipe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    IdTarefa = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    IdResponsavel = table.Column<int>(type: "INTEGER", nullable: false),
                    ResponsavelIdEquipe = table.Column<int>(type: "INTEGER", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IdProjeto = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjetoIdProjeto = table.Column<int>(type: "INTEGER", nullable: false),
                    SprintModelIdSprint = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.IdTarefa);
                    table.ForeignKey(
                        name: "FK_Tarefas_Equipes_ResponsavelIdEquipe",
                        column: x => x.ResponsavelIdEquipe,
                        principalTable: "Equipes",
                        principalColumn: "IdEquipe",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarefas_Projetos_ProjetoIdProjeto",
                        column: x => x.ProjetoIdProjeto,
                        principalTable: "Projetos",
                        principalColumn: "IdProjeto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarefas_Sprints_SprintModelIdSprint",
                        column: x => x.SprintModelIdSprint,
                        principalTable: "Sprints",
                        principalColumn: "IdSprint");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipes_IdProjeto",
                table: "Equipes",
                column: "IdProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_Membros_IdEquipe",
                table: "Membros",
                column: "IdEquipe");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_ClienteIdCliente",
                table: "Projetos",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Sprints_ProjetoIdProjeto",
                table: "Sprints",
                column: "ProjetoIdProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ProjetoIdProjeto",
                table: "Tarefas",
                column: "ProjetoIdProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ResponsavelIdEquipe",
                table: "Tarefas",
                column: "ResponsavelIdEquipe");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_SprintModelIdSprint",
                table: "Tarefas",
                column: "SprintModelIdSprint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Membros");

            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.DropTable(
                name: "Equipes");

            migrationBuilder.DropTable(
                name: "Sprints");

            migrationBuilder.DropTable(
                name: "Projetos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
