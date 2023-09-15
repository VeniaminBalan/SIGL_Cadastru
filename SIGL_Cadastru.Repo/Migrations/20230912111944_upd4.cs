using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIGL_Cadastru.Repo.Migrations
{
    /// <inheritdoc />
    public partial class upd4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("0a7d429f-8651-4964-8f5a-1b4342869e45"));

            migrationBuilder.DeleteData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("eba3d242-c5bd-4402-ac00-cc2320c54ab0"));

            migrationBuilder.AlterColumn<string>(
                name: "Portofoliu",
                table: "Cereri",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.InsertData(
                table: "Persoane",
                columns: new[] { "Id", "DataNasterii", "Domiciliu", "Email", "IDNP", "Nume", "Prenume", "Rol", "Telefon" },
                values: new object[,]
                {
                    { new Guid("5676c1a1-baf5-4fd7-b159-2456ef9f3efd"), new DateOnly(1977, 7, 16), "sat. Gribova", "geoproiectgrup@mail.ru", "124353452341", "Balan", "Octavian", 2, "079900218" },
                    { new Guid("5fdb4ade-5692-4d43-8000-ad30cdc72fb8"), new DateOnly(2002, 8, 13), "or. Drochia", "", "2002500081628", "Balan", "Veniamin", 0, "079900846" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("5676c1a1-baf5-4fd7-b159-2456ef9f3efd"));

            migrationBuilder.DeleteData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("5fdb4ade-5692-4d43-8000-ad30cdc72fb8"));

            migrationBuilder.AlterColumn<string>(
                name: "Portofoliu",
                table: "Cereri",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Persoane",
                columns: new[] { "Id", "DataNasterii", "Domiciliu", "Email", "IDNP", "Nume", "Prenume", "Rol", "Telefon" },
                values: new object[,]
                {
                    { new Guid("0a7d429f-8651-4964-8f5a-1b4342869e45"), new DateOnly(1977, 7, 16), "sat. Gribova", "geoproiectgrup@mail.ru", "124353452341", "Balan", "Octavian", 2, "079900218" },
                    { new Guid("eba3d242-c5bd-4402-ac00-cc2320c54ab0"), new DateOnly(2002, 8, 13), "or. Drochia", "", "2002500081628", "Balan", "Veniamin", 0, "079900846" }
                });
        }
    }
}
