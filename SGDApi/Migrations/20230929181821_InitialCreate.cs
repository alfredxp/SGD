using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGDApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoNombre = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    EstadoCodigo = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioLogin = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    UsuarioContrasena = table.Column<string>(type: "VARCHAR", nullable: false),
                    UsuarioNombre = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    UsuarioApellido = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    UsuarioCorreo = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    UsuarioTelefono = table.Column<string>(type: "VARCHAR(12)", maxLength: 12, nullable: false),
                    UsuarioCedula = table.Column<string>(type: "VARCHAR(13)", maxLength: 13, nullable: false),
                    UsuarioTwoFactor = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    UsuarioLlaveQR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioFechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogActividades",
                columns: table => new
                {
                    LogActividadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogActividadFecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LogActividadAccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogActividades", x => x.LogActividadId);
                    table.ForeignKey(
                        name: "FK_LogActividades_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogActividades_UsuarioId",
                table: "LogActividades",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EstadosEstadoId",
                table: "Usuarios",
                column: "EstadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogActividades");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
