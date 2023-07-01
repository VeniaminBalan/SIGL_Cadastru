using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGL_Cadastru.Repo.Migrations
{
    /// <inheritdoc />
    public partial class upd10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Persoane",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "Persoane",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cereri",
                keyColumn: "CerereId",
                keyValue: new Guid("f5bb1dbe-a8cc-4d8b-89aa-3f5a595a7546"),
                column: "StareaCererii",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("6eed1456-1b25-4195-9eda-e240a9ef09fd"),
                columns: new[] { "Email", "Telefon" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("d8f68da7-402b-411f-b6ea-a16beaf005e3"),
                columns: new[] { "Email", "Telefon" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Persoane");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "Persoane");

            migrationBuilder.UpdateData(
                table: "Cereri",
                keyColumn: "CerereId",
                keyValue: new Guid("f5bb1dbe-a8cc-4d8b-89aa-3f5a595a7546"),
                column: "StareaCererii",
                value: null);
        }
    }
}
