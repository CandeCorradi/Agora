using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class agregamosTiposIncripcionesCapacitaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposInscripcionesCapacitaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CapacitacionId = table.Column<int>(type: "int", nullable: false),
                    TipoInscripcionId = table.Column<int>(type: "int", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposInscripcionesCapacitaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiposInscripcionesCapacitaciones_Capacitaciones_Capacitacion~",
                        column: x => x.CapacitacionId,
                        principalTable: "Capacitaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TiposInscripcionesCapacitaciones_TipoInscripciones_TipoInscr~",
                        column: x => x.TipoInscripcionId,
                        principalTable: "TipoInscripciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.InsertData(
                table: "TiposInscripcionesCapacitaciones",
                columns: new[] { "Id", "CapacitacionId", "Costo", "IsDeleted", "TipoInscripcionId" },
                values: new object[,]
                {
                    { 1, 1, 10000m, false, 1 },
                    { 2, 1, 5000m, false, 2 },
                    { 3, 1, 3000m, false, 3 },
                    { 4, 1, 2000m, false, 4 },
                    { 5, 2, 12000m, false, 1 },
                    { 6, 2, 6000m, false, 2 },
                    { 7, 2, 4000m, false, 3 },
                    { 8, 2, 3000m, false, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TiposInscripcionesCapacitaciones_CapacitacionId",
                table: "TiposInscripcionesCapacitaciones",
                column: "CapacitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposInscripcionesCapacitaciones_TipoInscripcionId",
                table: "TiposInscripcionesCapacitaciones",
                column: "TipoInscripcionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TiposInscripcionesCapacitaciones");

            migrationBuilder.UpdateData(
                table: "Capacitaciones",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaHora",
                value: new DateTime(2025, 8, 29, 17, 36, 27, 453, DateTimeKind.Local).AddTicks(9348));

            migrationBuilder.UpdateData(
                table: "Capacitaciones",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaHora",
                value: new DateTime(2025, 9, 8, 17, 36, 27, 453, DateTimeKind.Local).AddTicks(9371));
        }
    }
}
