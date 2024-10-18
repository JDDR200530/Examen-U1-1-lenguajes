using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXAMEN_U1_1_Lenguajes.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administraitors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_of_Admission = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administraitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameEmployee = table.Column<string>(name: "Name Employee", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostEmployee = table.Column<string>(name: "Post Employee", type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Date_of_Admission = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Employed = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name_Employed = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    type_of_permit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpleadoEntityid_empleado = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Empleados_EmpleadoEntityid_empleado",
                        column: x => x.EmpleadoEntityid_empleado,
                        principalTable: "Empleados",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_EmpleadoEntityid_empleado",
                table: "Permissions",
                column: "EmpleadoEntityid_empleado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administraitors");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}
