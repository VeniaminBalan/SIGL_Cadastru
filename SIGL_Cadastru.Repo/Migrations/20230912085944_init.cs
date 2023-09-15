using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIGL_Cadastru.Repo.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persoane",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nume = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Prenume = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IDNP = table.Column<string>(type: "TEXT", nullable: false),
                    DataNasterii = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Domiciliu = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Telefon = table.Column<string>(type: "TEXT", nullable: true),
                    Rol = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persoane", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cereri",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExecutantId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ResponsabilId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nr = table.Column<string>(type: "TEXT", nullable: false),
                    ValabilDeLa = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    ValabilPanaLa = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    NrCadastral = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Adaos = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cereri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cereri_Persoane_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Persoane",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cereri_Persoane_ExecutantId",
                        column: x => x.ExecutantId,
                        principalTable: "Persoane",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cereri_Persoane_ResponsabilId",
                        column: x => x.ResponsabilId,
                        principalTable: "Persoane",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lucrari",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CerereId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TipLucrare = table.Column<string>(type: "TEXT", nullable: false),
                    Pret = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lucrari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lucrari_Cereri_CerereId",
                        column: x => x.CerereId,
                        principalTable: "Cereri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stari",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CerereId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Starea = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stari_Cereri_CerereId",
                        column: x => x.CerereId,
                        principalTable: "Cereri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Persoane",
                columns: new[] { "Id", "DataNasterii", "Domiciliu", "Email", "IDNP", "Nume", "Prenume", "Rol", "Telefon" },
                values: new object[,]
                {
                    { new Guid("80bf23ed-90e7-4673-bc04-6235fc857481"), new DateOnly(2002, 8, 13), "or. Drochia", "", "2002500081628", "Balan", "Veniamin", 0, "079900846" },
                    { new Guid("c5879fa5-ec06-4ba9-8da2-393ea522f4cd"), new DateOnly(1977, 7, 16), "sat. Gribova", "geoproiectgrup@mail.ru", "124353452341", "Balan", "Octavian", 2, "079900218" }
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
                name: "IX_Cereri_Nr",
                table: "Cereri",
                column: "Nr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cereri_ResponsabilId",
                table: "Cereri",
                column: "ResponsabilId");

            migrationBuilder.CreateIndex(
                name: "IX_Lucrari_CerereId",
                table: "Lucrari",
                column: "CerereId");

            migrationBuilder.CreateIndex(
                name: "IX_Stari_CerereId",
                table: "Stari",
                column: "CerereId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lucrari");

            migrationBuilder.DropTable(
                name: "Stari");

            migrationBuilder.DropTable(
                name: "Cereri");

            migrationBuilder.DropTable(
                name: "Persoane");
        }
    }
}
