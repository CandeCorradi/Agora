using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class agregamosInscripciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Apellido = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dni = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoInscripcionId = table.Column<int>(type: "int", nullable: false),
                    CapacitacionId = table.Column<int>(type: "int", nullable: false),
                    Acreditado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Importe = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Pagado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UsuarioCobroId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Capacitaciones_CapacitacionId",
                        column: x => x.CapacitacionId,
                        principalTable: "Capacitaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripciones_TipoInscripciones_TipoInscripcionId",
                        column: x => x.TipoInscripcionId,
                        principalTable: "TipoInscripciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Usuarios_UsuarioCobroId",
                        column: x => x.UsuarioCobroId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Capacitaciones",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaHora",
                value: new DateTime(2025, 8, 29, 18, 30, 3, 794, DateTimeKind.Local).AddTicks(3578));

            migrationBuilder.UpdateData(
                table: "Capacitaciones",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaHora",
                value: new DateTime(2025, 9, 8, 18, 30, 3, 794, DateTimeKind.Local).AddTicks(3603));

            migrationBuilder.InsertData(
                table: "Inscripciones",
                columns: new[] { "Id", "Acreditado", "Apellido", "CapacitacionId", "Dni", "Email", "Importe", "IsDeleted", "Nombre", "Pagado", "TipoInscripcionId", "UsuarioCobroId" },
                values: new object[,]
                {
                    { 1, false, "Gómez", 1, "12345678", "carlos.gomez@gmail.com", 10000m, false, "Carlos", false, 1, null },
                    { 2, false, "Martínez", 1, "87654321", "ana.martinez@gmail.com", 5000m, false, "Ana", false, 2, null },
                    { 3, false, "Pérez", 2, "11223344", "juan.perez@gmail.com", 4000m, false, "Juan", false, 3, null },
                    { 4, false, "Lopez", 2, "44332211", "maria.lopez@gmail.com", 3000m, false, "Maria", false, 4, null },
                    { 5, false, "Fernandez", 2, "55667788", "luis.fernandez@gmail.com", 12000m, false, "Luis", false, 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_CapacitacionId",
                table: "Inscripciones",
                column: "CapacitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_TipoInscripcionId",
                table: "Inscripciones",
                column: "TipoInscripcionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_UsuarioCobroId",
                table: "Inscripciones",
                column: "UsuarioCobroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.UpdateData(
                table: "Capacitaciones",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaHora",
                value: new DateTime(2025, 8, 29, 18, 4, 35, 763, DateTimeKind.Local).AddTicks(3824));

            migrationBuilder.UpdateData(
                table: "Capacitaciones",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaHora",
                value: new DateTime(2025, 9, 8, 18, 4, 35, 763, DateTimeKind.Local).AddTicks(3857));
        }
    }
}
