using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIGL_Cadastru.Repo.Migrations
{
    /// <inheritdoc />
    public partial class upd7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cereri_Persoane_ClientId",
                table: "Cereri");

            migrationBuilder.DeleteData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("58536fb2-9944-4a56-b499-77e5dd308d10"));

            migrationBuilder.DeleteData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("d8ca11fb-812c-4de8-9e99-cc87355f18f3"));

            migrationBuilder.InsertData(
                table: "Persoane",
                columns: new[] { "Id", "DataNasterii", "Domiciliu", "Email", "IDNP", "Nume", "Prenume", "Rol", "Telefon" },
                values: new object[,]
                {
                    { new Guid("6aa5d3f3-7b4d-4f3b-a03b-35fc83dccc0f"), new DateOnly(2002, 8, 13), "or. Drochia", "", "2002500081628", "Balan", "Veniamin", 0, "079900846" },
                    { new Guid("ff2c8d96-8f95-403e-90c2-40369a875cfb"), new DateOnly(1977, 7, 16), "sat. Gribova", "geoproiectgrup@mail.ru", "124353452341", "Balan", "Octavian", 2, "079900218" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cereri_Persoane_ClientId",
                table: "Cereri",
                column: "ClientId",
                principalTable: "Persoane",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cereri_Persoane_ClientId",
                table: "Cereri");

            migrationBuilder.DeleteData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("6aa5d3f3-7b4d-4f3b-a03b-35fc83dccc0f"));

            migrationBuilder.DeleteData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("ff2c8d96-8f95-403e-90c2-40369a875cfb"));

            migrationBuilder.InsertData(
                table: "Persoane",
                columns: new[] { "Id", "DataNasterii", "Domiciliu", "Email", "IDNP", "Nume", "Prenume", "Rol", "Telefon" },
                values: new object[,]
                {
                    { new Guid("58536fb2-9944-4a56-b499-77e5dd308d10"), new DateOnly(1977, 7, 16), "sat. Gribova", "geoproiectgrup@mail.ru", "124353452341", "Balan", "Octavian", 2, "079900218" },
                    { new Guid("d8ca11fb-812c-4de8-9e99-cc87355f18f3"), new DateOnly(2002, 8, 13), "or. Drochia", "", "2002500081628", "Balan", "Veniamin", 0, "079900846" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cereri_Persoane_ClientId",
                table: "Cereri",
                column: "ClientId",
                principalTable: "Persoane",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
