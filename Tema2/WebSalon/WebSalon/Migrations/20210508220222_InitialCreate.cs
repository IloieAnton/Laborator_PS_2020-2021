using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSalon.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Programare",
                columns: table => new
                {
                    ProgramareId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeClient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataOra = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programare", x => x.ProgramareId);
                });

            migrationBuilder.CreateTable(
                name: "Serviciu",
                columns: table => new
                {
                    ServiciuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeServiciu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pret = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serviciu", x => x.ServiciuId);
                });

            migrationBuilder.CreateTable(
                name: "ProgramareServiciu",
                columns: table => new
                {
                    ProgramareId = table.Column<int>(type: "int", nullable: false),
                    ServiciuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramareServiciu", x => new { x.ProgramareId, x.ServiciuId });
                    table.ForeignKey(
                        name: "FK_ProgramareServiciu_Programare_ProgramareId",
                        column: x => x.ProgramareId,
                        principalTable: "Programare",
                        principalColumn: "ProgramareId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramareServiciu_Serviciu_ServiciuId",
                        column: x => x.ServiciuId,
                        principalTable: "Serviciu",
                        principalColumn: "ServiciuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramareServiciu_ServiciuId",
                table: "ProgramareServiciu",
                column: "ServiciuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramareServiciu");

            migrationBuilder.DropTable(
                name: "Programare");

            migrationBuilder.DropTable(
                name: "Serviciu");
        }
    }
}
