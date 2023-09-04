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
            migrationBuilder.DropIndex(
                name: "IX_Persoane_Email",
                table: "Persoane");

            migrationBuilder.DropIndex(
                name: "IX_Persoane_IDNP",
                table: "Persoane");

            migrationBuilder.DeleteData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("599ad2aa-5529-45c2-b0fb-74e5824f0878"));

            migrationBuilder.DeleteData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("89f12875-5cff-4d84-8dd3-fa9b1371a92f"));

            migrationBuilder.InsertData(
                table: "Persoane",
                columns: new[] { "Id", "DataNasterii", "Domiciliu", "Email", "IDNP", "Nume", "Prenume", "Rol", "Telefon" },
                values: new object[,]
                {
                    { new Guid("2ade478b-809e-4969-b72e-36c6702c38ce"), new DateOnly(1977, 7, 16), "sat. Gribova", "geoproiectgrup@mail.ru", "124353452341", "Balan", "Octavian", 2, "079900218" },
                    { new Guid("e7d78657-228d-4d09-b409-e5c5f1742cf1"), new DateOnly(2002, 8, 13), "or. Drochia", "", "2002500081628", "Balan", "Veniamin", 0, "079900846" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("2ade478b-809e-4969-b72e-36c6702c38ce"));

            migrationBuilder.DeleteData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("e7d78657-228d-4d09-b409-e5c5f1742cf1"));

            migrationBuilder.InsertData(
                table: "Persoane",
                columns: new[] { "Id", "DataNasterii", "Domiciliu", "Email", "IDNP", "Nume", "Prenume", "Rol", "Telefon" },
                values: new object[,]
                {
                    { new Guid("599ad2aa-5529-45c2-b0fb-74e5824f0878"), new DateOnly(2002, 8, 13), "or. Drochia", "", "2002500081628", "Balan", "Veniamin", 2, "079900846" },
                    { new Guid("89f12875-5cff-4d84-8dd3-fa9b1371a92f"), new DateOnly(1977, 7, 16), "sat. Gribova", "geoproiectgrup@mail.ru", "124353452341", "Balan", "Octavian", 2, "079900218" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persoane_Email",
                table: "Persoane",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persoane_IDNP",
                table: "Persoane",
                column: "IDNP",
                unique: true);
        }
    }
}
