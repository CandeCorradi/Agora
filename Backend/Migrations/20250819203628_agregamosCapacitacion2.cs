using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class agregamosCapacitacion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Capacitaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Detalle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ponente = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaHora = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Cupo = table.Column<int>(type: "int", nullable: false),
                    InscripcionAbierta = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capacitaciones", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Capacitaciones",
                columns: new[] { "Id", "Cupo", "Detalle", "FechaHora", "InscripcionAbierta", "IsDeleted", "Nombre", "Ponente" },
                values: new object[,]
                {
                    { 1, 30, "Aprende los conceptos básicos de programación.", new DateTime(2025, 8, 29, 17, 36, 27, 453, DateTimeKind.Local).AddTicks(9348), true, false, "Introducción a la Programación", "Carlos Gómez" },
                    { 2, 25, "Crea aplicaciones web modernas con ASP.NET Core.", new DateTime(2025, 9, 8, 17, 36, 27, 453, DateTimeKind.Local).AddTicks(9371), true, false, "Desarrollo Web con ASP.NET Core", "Ana Martínez" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Capacitaciones");
        }
    }
}
