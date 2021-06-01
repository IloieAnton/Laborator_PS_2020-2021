using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSalon.Migrations
{
    public partial class WebSalonMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Programare",
                columns: table => new
                {
                    ProgramareId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    numeClient = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefon = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dataOra = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    username = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programare", x => x.ProgramareId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Serviciu",
                columns: table => new
                {
                    ServiciuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    numeServiciu = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pret = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serviciu", x => x.ServiciuId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
