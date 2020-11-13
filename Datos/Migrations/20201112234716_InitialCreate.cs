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
                name: "Vacuna",
                columns: table => new
                {
                    NombreVacuna = table.Column<string>(nullable: false),
                    FechaVacuna = table.Column<DateTime>(nullable: false),
                    EdadAplicacion = table.Column<int>(nullable: false),
                    PersonaCedula = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacuna", x => x.NombreVacuna);
                    table.ForeignKey(
                        name: "FK_Vacuna_Personas_PersonaCedula",
                        column: x => x.PersonaCedula,
                        principalTable: "Personas",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vacuna_PersonaCedula",
                table: "Vacuna",
                column: "PersonaCedula");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacuna");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
