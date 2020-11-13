using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Cedula = table.Column<string>(nullable: false),
                    TipoDocumento = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    InstitucionEducativa = table.Column<string>(nullable: true),
                    NombreAcudiente = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "Vacunas",
                columns: table => new
                {
                    NombreVacuna = table.Column<string>(nullable: false),
                    FechaVacuna = table.Column<DateTime>(nullable: false),
                    EdadAplicacion = table.Column<int>(nullable: false),
                    CedulaPersona = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacunas", x => x.NombreVacuna);
                    table.ForeignKey(
                        name: "FK_Vacunas_Personas_CedulaPersona",
                        column: x => x.CedulaPersona,
                        principalTable: "Personas",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vacunas_CedulaPersona",
                table: "Vacunas",
                column: "CedulaPersona");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacunas");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
