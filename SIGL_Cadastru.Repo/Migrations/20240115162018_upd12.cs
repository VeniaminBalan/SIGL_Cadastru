using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGL_Cadastru.Repo.Migrations
{
    /// <inheritdoc />
    public partial class upd12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cereri_Persoane_ClientId",
                table: "Cereri");

            migrationBuilder.AddColumn<int>(
                name: "CerereNr_Index",
                table: "Cereri",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CerereNr_Year",
                table: "Cereri",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("20ba7528-9e72-46fe-946a-99efba3d4a49"),
                columns: new[] { "DataNasterii", "Domiciliu", "Email", "IDNP", "Prenume", "Rol", "Telefon" },
                values: new object[] { new DateOnly(2002, 8, 13), "or. Drochia", "", "2002500081628", "Veniamin", 0, "079900846" });

            migrationBuilder.UpdateData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("3453d494-75e5-46b1-96ff-2a3790f2d7a5"),
                columns: new[] { "DataNasterii", "Domiciliu", "Email", "IDNP", "Prenume", "Rol", "Telefon" },
                values: new object[] { new DateOnly(1977, 7, 16), "sat. Gribova", "geoproiectgrup@mail.ru", "124353452341", "Octavian", 2, "079900218" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cereri_Persoane_ClientId",
                table: "Cereri",
                column: "ClientId",
                principalTable: "Persoane",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cereri_Persoane_ClientId",
                table: "Cereri");

            migrationBuilder.DropColumn(
                name: "CerereNr_Index",
                table: "Cereri");

            migrationBuilder.DropColumn(
                name: "CerereNr_Year",
                table: "Cereri");

            migrationBuilder.UpdateData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("20ba7528-9e72-46fe-946a-99efba3d4a49"),
                columns: new[] { "DataNasterii", "Domiciliu", "Email", "IDNP", "Prenume", "Rol", "Telefon" },
                values: new object[] { new DateOnly(1977, 7, 16), "sat. Gribova", "geoproiectgrup@mail.ru", "124353452341", "Octavian", 2, "079900218" });

            migrationBuilder.UpdateData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("3453d494-75e5-46b1-96ff-2a3790f2d7a5"),
                columns: new[] { "DataNasterii", "Domiciliu", "Email", "IDNP", "Prenume", "Rol", "Telefon" },
                values: new object[] { new DateOnly(2002, 8, 13), "or. Drochia", "", "2002500081628", "Veniamin", 0, "079900846" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cereri_Persoane_ClientId",
                table: "Cereri",
                column: "ClientId",
                principalTable: "Persoane",
                principalColumn: "Id");
        }
    }
}
