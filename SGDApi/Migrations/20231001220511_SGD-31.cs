using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGDApi.Migrations
{
    /// <inheritdoc />
    public partial class SGD31 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogActividades_Usuarios_UsuarioId",
                table: "LogActividades");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Estados_EstadoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_EstadosEstadoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "UsuarioFechaModificacion",
                table: "Usuarios",
                newName: "FechaUltimaRevision");

            migrationBuilder.RenameColumn(
                name: "UsuarioFechaCreacion",
                table: "Usuarios",
                newName: "FechaOrigen");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioTelefono",
                table: "Usuarios",
                type: "VARCHAR(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioNombre",
                table: "Usuarios",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioLlaveQR",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioCorreo",
                table: "Usuarios",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioCedula",
                table: "Usuarios",
                type: "VARCHAR(13)",
                maxLength: 13,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(13)",
                oldMaxLength: 13);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioApellido",
                table: "Usuarios",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "LogActividades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "LogActividadAccion",
                table: "LogActividades",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "LogActividades",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EstadoNombre",
                table: "Estados",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "EstadoCodigo",
                table: "Estados",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Estados",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCreador",
                table: "Estados",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioModificacion",
                table: "Estados",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuariosCreadorUsuarioId",
                table: "Estados",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuariosModificacionUsuarioId",
                table: "Estados",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    AreaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaUltimaRevision = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaOrigen = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    UsuarioCreador = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.AreaId);
                    table.ForeignKey(
                        name: "FK_Areas_Usuarios_UsuarioCreador",
                        column: x => x.UsuarioCreador,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                    table.ForeignKey(
                        name: "FK_Areas_Usuarios_UsuarioModificacion",
                        column: x => x.UsuarioModificacion,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    DocumentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    UsuarioCreador = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.DocumentoId);
                    table.ForeignKey(
                        name: "FK_Documentos_Usuarios_UsuarioCreador",
                        column: x => x.UsuarioCreador,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                    table.ForeignKey(
                        name: "FK_Documentos_Usuarios_UsuarioModificacion",
                        column: x => x.UsuarioModificacion,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaUltimaRevision = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaOrigen = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    DocumentoId = table.Column<int>(type: "int", nullable: false),
                    UsuariosId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    UsuarioCreador = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Documentos_DocumentoId",
                        column: x => x.DocumentoId,
                        principalTable: "Documentos",
                        principalColumn: "DocumentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Usuarios_UsuarioCreador",
                        column: x => x.UsuarioCreador,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                    table.ForeignKey(
                        name: "FK_Tasks_Usuarios_UsuarioModificacion",
                        column: x => x.UsuarioModificacion,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                    table.ForeignKey(
                        name: "FK_Tasks_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    ComentarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskId = table.Column<int>(type: "int", nullable: true),
                    FechaUltimaRevision = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaOrigen = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<int>(type: "int", nullable: true),
                    UsuarioCreador = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.ComentarioId);
                    table.ForeignKey(
                        name: "FK_Comentarios_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId");
                    table.ForeignKey(
                        name: "FK_Comentarios_Usuarios_UsuarioCreador",
                        column: x => x.UsuarioCreador,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                    table.ForeignKey(
                        name: "FK_Comentarios_Usuarios_UsuarioModificacion",
                        column: x => x.UsuarioModificacion,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogActividades_TaskId",
                table: "LogActividades",
                column: "TaskId");


            migrationBuilder.CreateIndex(
                name: "IX_Estados_TaskId",
                table: "Estados",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_UsuariosCreadorUsuarioId",
                table: "Estados",
                column: "UsuariosCreadorUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_UsuariosModificacionUsuarioId",
                table: "Estados",
                column: "UsuariosModificacionUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_UsuarioCreador",
                table: "Areas",
                column: "UsuarioCreador");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_UsuarioModificacion",
                table: "Areas",
                column: "UsuarioModificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_TaskId",
                table: "Comentarios",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_UsuarioCreador",
                table: "Comentarios",
                column: "UsuarioCreador");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_UsuarioModificacion",
                table: "Comentarios",
                column: "UsuarioModificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_UsuarioCreador",
                table: "Documentos",
                column: "UsuarioCreador");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_UsuarioModificacion",
                table: "Documentos",
                column: "UsuarioModificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AreaId",
                table: "Tasks",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_DocumentoId",
                table: "Tasks",
                column: "DocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UsuarioCreador",
                table: "Tasks",
                column: "UsuarioCreador");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UsuarioModificacion",
                table: "Tasks",
                column: "UsuarioModificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UsuariosId",
                table: "Tasks",
                column: "UsuariosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estados_Tasks_TaskId",
                table: "Estados",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estados_Usuarios_UsuariosCreadorUsuarioId",
                table: "Estados",
                column: "UsuariosCreadorUsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estados_Usuarios_UsuariosModificacionUsuarioId",
                table: "Estados",
                column: "UsuariosModificacionUsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_LogActividades_Tasks_TaskId",
                table: "LogActividades",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_LogActividades_Usuarios_UsuarioId",
                table: "LogActividades",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogActividades_Usuarios_UsuariosUsuarioId",
                table: "LogActividades",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estados_Tasks_TaskId",
                table: "Estados");

            migrationBuilder.DropForeignKey(
                name: "FK_Estados_Usuarios_UsuariosCreadorUsuarioId",
                table: "Estados");

            migrationBuilder.DropForeignKey(
                name: "FK_Estados_Usuarios_UsuariosModificacionUsuarioId",
                table: "Estados");

            migrationBuilder.DropForeignKey(
                name: "FK_LogActividades_Tasks_TaskId",
                table: "LogActividades");

            migrationBuilder.DropForeignKey(
                name: "FK_LogActividades_Usuarios_UsuarioId",
                table: "LogActividades");

            migrationBuilder.DropForeignKey(
                name: "FK_LogActividades_Usuarios_UsuarioId",
                table: "LogActividades");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropIndex(
                name: "IX_LogActividades_TaskId",
                table: "LogActividades");

            migrationBuilder.DropIndex(
                name: "IX_LogActividades_UsuarioId",
                table: "LogActividades");

            migrationBuilder.DropIndex(
                name: "IX_Estados_TaskId",
                table: "Estados");

            migrationBuilder.DropIndex(
                name: "IX_Estados_UsuariosCreadorUsuarioId",
                table: "Estados");

            migrationBuilder.DropIndex(
                name: "IX_Estados_UsuariosModificacionUsuarioId",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "LogActividades");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "UsuarioCreador",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "UsuarioModificacion",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "UsuariosCreadorUsuarioId",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "UsuariosModificacionUsuarioId",
                table: "Estados");

            migrationBuilder.RenameColumn(
                name: "FechaUltimaRevision",
                table: "Usuarios",
                newName: "UsuarioFechaModificacion");

            migrationBuilder.RenameColumn(
                name: "FechaOrigen",
                table: "Usuarios",
                newName: "UsuarioFechaCreacion");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioTelefono",
                table: "Usuarios",
                type: "VARCHAR(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(12)",
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioNombre",
                table: "Usuarios",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioLlaveQR",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioCorreo",
                table: "Usuarios",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioCedula",
                table: "Usuarios",
                type: "VARCHAR(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(13)",
                oldMaxLength: 13,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioApellido",
                table: "Usuarios",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadosEstadoId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UsuariosUsuarioId",
                table: "LogActividades",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LogActividadAccion",
                table: "LogActividades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EstadoNombre",
                table: "Estados",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EstadoCodigo",
                table: "Estados",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EstadosEstadoId",
                table: "Usuarios",
                column: "EstadosEstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_LogActividades_Usuarios_UsuariosUsuarioId",
                table: "LogActividades",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Estados_EstadosEstadoId",
                table: "Usuarios",
                column: "EstadosEstadoId",
                principalTable: "Estados",
                principalColumn: "EstadoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
