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
                keyValue: new Guid("2ade478b-809e-4969-b72e-36c6702c38ce"));

            migrationBuilder.DeleteData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("e7d78657-228d-4d09-b409-e5c5f1742cf1"));

            migrationBuilder.AddColumn<string>(
                name: "Nr",
                table: "Cereri",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Persoane",
                columns: new[] { "Id", "DataNasterii", "Domiciliu", "Email", "IDNP", "Nume", "Prenume", "Rol", "Telefon" },
                values: new object[,]
                {
                    { new Guid("d961f6ca-5ed0-4e40-b34e-059649fcc818"), new DateOnly(2002, 8, 13), "or. Drochia", "", "2002500081628", "Balan", "Veniamin", 0, "079900846" },
                    { new Guid("fcc03fac-4c18-4a15-a146-54651b2a6bca"), new DateOnly(1977, 7, 16), "sat. Gribova", "geoproiectgrup@mail.ru", "124353452341", "Balan", "Octavian", 2, "079900218" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cereri_Nr",
                table: "Cereri",
                column: "Nr");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cereri_Nr",
                table: "Cereri");

            migrationBuilder.DeleteData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("d961f6ca-5ed0-4e40-b34e-059649fcc818"));

            migrationBuilder.DeleteData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("fcc03fac-4c18-4a15-a146-54651b2a6bca"));

            migrationBuilder.DropColumn(
                name: "Nr",
                table: "Cereri");

            migrationBuilder.InsertData(
                table: "Persoane",
                columns: new[] { "Id", "DataNasterii", "Domiciliu", "Email", "IDNP", "Nume", "Prenume", "Rol", "Telefon" },
                values: new object[,]
                {
                    { new Guid("2ade478b-809e-4969-b72e-36c6702c38ce"), new DateOnly(1977, 7, 16), "sat. Gribova", "geoproiectgrup@mail.ru", "124353452341", "Balan", "Octavian", 2, "079900218" },
                    { new Guid("e7d78657-228d-4d09-b409-e5c5f1742cf1"), new DateOnly(2002, 8, 13), "or. Drochia", "", "2002500081628", "Balan", "Veniamin", 0, "079900846" }
                });
        }
    }
}
