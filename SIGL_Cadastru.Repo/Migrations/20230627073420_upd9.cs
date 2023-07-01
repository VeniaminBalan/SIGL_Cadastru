using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGL_Cadastru.Repo.Migrations
{
    /// <inheritdoc />
    public partial class upd9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Cereri",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "Cereri",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cereri",
                keyColumn: "CerereId",
                keyValue: new Guid("f5bb1dbe-a8cc-4d8b-89aa-3f5a595a7546"),
                columns: new[] { "Email", "NrCadastral", "Telefon" },
                values: new object[] { null, "36011010001", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Cereri");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "Cereri");

            migrationBuilder.UpdateData(
                table: "Cereri",
                keyColumn: "CerereId",
                keyValue: new Guid("f5bb1dbe-a8cc-4d8b-89aa-3f5a595a7546"),
                column: "NrCadastral",
                value: "12121212");
        }
    }
}
