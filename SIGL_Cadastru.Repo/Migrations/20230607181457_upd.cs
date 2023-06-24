using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGL_Cadastru.Repo.Migrations
{
    /// <inheritdoc />
    public partial class upd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lucrari",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    TipLucrare = table.Column<string>(type: "TEXT", nullable: false),
                    Pret = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lucrari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persoane",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Nume = table.Column<string>(type: "TEXT", nullable: false),
                    Prenume = table.Column<string>(type: "TEXT", nullable: false),
                    IDNP = table.Column<string>(type: "TEXT", nullable: false),
                    DataNasterii = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Domiciliu = table.Column<string>(type: "TEXT", nullable: false),
                    Rol = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persoane", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cereri",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ClientId = table.Column<string>(type: "TEXT", nullable: true),
                    ExecutantId = table.Column<string>(type: "TEXT", nullable: true),
                    ResponsabilId = table.Column<string>(type: "TEXT", nullable: true),
                    NrCadastral = table.Column<string>(type: "TEXT", nullable: false),
                    ValabilDeLa = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    ValabilPanaLa = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Prelungit = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    CostTotal = table.Column<int>(type: "INTEGER", nullable: false),
                    StareaCererii = table.Column<int>(type: "INTEGER", nullable: false),
                    LaReceptie = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Eliberat = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Respins = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cereri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cereri_Persoane_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Persoane",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cereri_Persoane_ExecutantId",
                        column: x => x.ExecutantId,
                        principalTable: "Persoane",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cereri_Persoane_ResponsabilId",
                        column: x => x.ResponsabilId,
                        principalTable: "Persoane",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cereri_ClientId",
                table: "Cereri",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Cereri_ExecutantId",
                table: "Cereri",
                column: "ExecutantId");

            migrationBuilder.CreateIndex(
                name: "IX_Cereri_ResponsabilId",
                table: "Cereri",
                column: "ResponsabilId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cereri");

            migrationBuilder.DropTable(
                name: "Lucrari");

            migrationBuilder.DropTable(
                name: "Persoane");
        }
    }
}
