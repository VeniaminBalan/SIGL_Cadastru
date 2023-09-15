using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIGL_Cadastru.Repo.Migrations
{
    /// <inheritdoc />
    public partial class upd3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("20061c56-246d-420a-b4bd-ded337e0268e"));

            migrationBuilder.DeleteData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("6271a87e-1fce-49cc-90c2-602c429d9504"));

            migrationBuilder.AddColumn<string>(
                name: "Portofoliu",
                table: "Cereri",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Persoane",
                columns: new[] { "Id", "DataNasterii", "Domiciliu", "Email", "IDNP", "Nume", "Prenume", "Rol", "Telefon" },
                values: new object[,]
                {
                    { new Guid("0a7d429f-8651-4964-8f5a-1b4342869e45"), new DateOnly(1977, 7, 16), "sat. Gribova", "geoproiectgrup@mail.ru", "124353452341", "Balan", "Octavian", 2, "079900218" },
                    { new Guid("eba3d242-c5bd-4402-ac00-cc2320c54ab0"), new DateOnly(2002, 8, 13), "or. Drochia", "", "2002500081628", "Balan", "Veniamin", 0, "079900846" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("0a7d429f-8651-4964-8f5a-1b4342869e45"));

            migrationBuilder.DeleteData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("eba3d242-c5bd-4402-ac00-cc2320c54ab0"));

            migrationBuilder.DropColumn(
                name: "Portofoliu",
                table: "Cereri");

            migrationBuilder.InsertData(
                table: "Persoane",
                columns: new[] { "Id", "DataNasterii", "Domiciliu", "Email", "IDNP", "Nume", "Prenume", "Rol", "Telefon" },
                values: new object[,]
                {
                    { new Guid("20061c56-246d-420a-b4bd-ded337e0268e"), new DateOnly(2002, 8, 13), "or. Drochia", "", "2002500081628", "Balan", "Veniamin", 0, "079900846" },
                    { new Guid("6271a87e-1fce-49cc-90c2-602c429d9504"), new DateOnly(1977, 7, 16), "sat. Gribova", "geoproiectgrup@mail.ru", "124353452341", "Balan", "Octavian", 2, "079900218" }
                });
        }
    }
}
