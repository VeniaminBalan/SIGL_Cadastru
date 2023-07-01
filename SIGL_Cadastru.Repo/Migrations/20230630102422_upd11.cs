using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGL_Cadastru.Repo.Migrations
{
    /// <inheritdoc />
    public partial class upd11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Cereri");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "Cereri");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "Email", "Telefon" },
                values: new object[] { null, null });
        }
    }
}
