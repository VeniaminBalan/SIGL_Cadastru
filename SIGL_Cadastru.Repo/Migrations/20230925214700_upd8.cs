using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIGL_Cadastru.Repo.Migrations
{
    /// <inheritdoc />
    public partial class upd8 : Migration
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
                    { new Guid("012be37b-464c-4eec-8fb3-53f13e5f5db3"), new DateOnly(1977, 7, 16), "sat. Gribova", "geoproiectgrup@mail.ru", "124353452341", "Balan", "Octavian", 2, "079900218" },
                    { new Guid("ceee0a5d-d828-4f45-99d3-37a3922a2e48"), new DateOnly(2002, 8, 13), "or. Drochia", "", "2002500081628", "Balan", "Veniamin", 0, "079900846" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cereri_Persoane_ClientId",
                table: "Cereri",
                column: "ClientId",
                principalTable: "Persoane",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
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
                keyValue: new Guid("012be37b-464c-4eec-8fb3-53f13e5f5db3"));

            migrationBuilder.DeleteData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("ceee0a5d-d828-4f45-99d3-37a3922a2e48"));

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
    }
}
