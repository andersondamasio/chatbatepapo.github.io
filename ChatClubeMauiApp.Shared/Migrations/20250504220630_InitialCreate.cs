using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChatClubeMauiApp.Shared.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UsuariosOnline = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visitantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mensagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Usuario = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Conteudo = table.Column<string>(type: "text", nullable: false),
                    DataHora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SalaId = table.Column<int>(type: "integer", nullable: false),
                    SalasId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensagens_Salas_SalasId",
                        column: x => x.SalasId,
                        principalTable: "Salas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    NomeCompleto = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Apelido = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    FotoUrl = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    ProviderId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AuthProvider = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Online = table.Column<bool>(type: "boolean", nullable: false),
                    SalasId = table.Column<int>(type: "integer", nullable: true),
                    SalaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SalasUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SalasId = table.Column<int>(type: "integer", nullable: false),
                    SalaId = table.Column<int>(type: "integer", nullable: true),
                    UsuariosId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: true),
                    Entrada = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UltimaAtividade = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalasUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalasUsuarios_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalasUsuarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mensagens_SalasId",
                table: "Mensagens",
                column: "SalasId");

            migrationBuilder.CreateIndex(
                name: "IX_SalasUsuarios_SalaId",
                table: "SalasUsuarios",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_SalasUsuarios_UsuarioId",
                table: "SalasUsuarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_SalaId",
                table: "Usuarios",
                column: "SalaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mensagens");

            migrationBuilder.DropTable(
                name: "SalasUsuarios");

            migrationBuilder.DropTable(
                name: "Visitantes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Salas");
        }
    }
}
