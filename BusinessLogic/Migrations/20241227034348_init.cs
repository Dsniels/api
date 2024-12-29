using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessLogic.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrera", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarreraMateria",
                columns: table => new
                {
                    CarrerasId = table.Column<int>(type: "int", nullable: false),
                    MateriasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarreraMateria", x => new { x.CarrerasId, x.MateriasId });
                    table.ForeignKey(
                        name: "FK_CarreraMateria_Carrera_CarrerasId",
                        column: x => x.CarrerasId,
                        principalTable: "Carrera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarreraMateria_Materia_MateriasId",
                        column: x => x.MateriasId,
                        principalTable: "Materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarreraProfesor",
                columns: table => new
                {
                    CarrerasId = table.Column<int>(type: "int", nullable: false),
                    ProfesoresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarreraProfesor", x => new { x.CarrerasId, x.ProfesoresId });
                    table.ForeignKey(
                        name: "FK_CarreraProfesor_Carrera_CarrerasId",
                        column: x => x.CarrerasId,
                        principalTable: "Carrera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarreraProfesor_Profesor_ProfesoresId",
                        column: x => x.ProfesoresId,
                        principalTable: "Profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MateriaProfesor",
                columns: table => new
                {
                    MateriasId = table.Column<int>(type: "int", nullable: false),
                    ProfesoresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaProfesor", x => new { x.MateriasId, x.ProfesoresId });
                    table.ForeignKey(
                        name: "FK_MateriaProfesor_Materia_MateriasId",
                        column: x => x.MateriasId,
                        principalTable: "Materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MateriaProfesor_Profesor_ProfesoresId",
                        column: x => x.ProfesoresId,
                        principalTable: "Profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarreraMateria_MateriasId",
                table: "CarreraMateria",
                column: "MateriasId");

            migrationBuilder.CreateIndex(
                name: "IX_CarreraProfesor_ProfesoresId",
                table: "CarreraProfesor",
                column: "ProfesoresId");

            migrationBuilder.CreateIndex(
                name: "IX_MateriaProfesor_ProfesoresId",
                table: "MateriaProfesor",
                column: "ProfesoresId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarreraMateria");

            migrationBuilder.DropTable(
                name: "CarreraProfesor");

            migrationBuilder.DropTable(
                name: "MateriaProfesor");

            migrationBuilder.DropTable(
                name: "Carrera");

            migrationBuilder.DropTable(
                name: "Materia");

            migrationBuilder.DropTable(
                name: "Profesor");
        }
    }
}
