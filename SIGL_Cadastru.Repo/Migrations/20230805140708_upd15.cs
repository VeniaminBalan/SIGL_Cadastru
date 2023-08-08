using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGL_Cadastru.Repo.Migrations
{
    /// <inheritdoc />
    public partial class upd15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Eliberat",
                table: "Cereri");

            migrationBuilder.DropColumn(
                name: "LaReceptie",
                table: "Cereri");

            migrationBuilder.DropColumn(
                name: "Prelungit",
                table: "Cereri");

            migrationBuilder.DropColumn(
                name: "Respins",
                table: "Cereri");

            migrationBuilder.DropColumn(
                name: "StareaCererii",
                table: "Cereri");

            migrationBuilder.CreateTable(
                name: "Stari",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Starea = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    CerereId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stari_Cereri_CerereId",
                        column: x => x.CerereId,
                        principalTable: "Cereri",
                        principalColumn: "CerereId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stari_CerereId",
                table: "Stari",
                column: "CerereId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stari");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Eliberat",
                table: "Cereri",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "LaReceptie",
                table: "Cereri",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Prelungit",
                table: "Cereri",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Respins",
                table: "Cereri",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StareaCererii",
                table: "Cereri",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cereri",
                keyColumn: "CerereId",
                keyValue: new Guid("f5bb1dbe-a8cc-4d8b-89aa-3f5a595a7546"),
                columns: new[] { "Eliberat", "LaReceptie", "Prelungit", "Respins", "StareaCererii" },
                values: new object[] { null, null, null, null, 0 });
        }
    }
}
