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
            migrationBuilder.InsertData(
                table: "Persoane",
                columns: new[] { "Id", "DataNasterii", "Domiciliu", "IDNP", "Nume", "Prenume", "Rol" },
                values: new object[,]
                {
                    { new Guid("6eed1456-1b25-4195-9eda-e240a9ef09fd"), new DateOnly(1977, 7, 16), "sat. Pierduta", "2000818332", "Gutu", "Ion", 0 },
                    { new Guid("d8f68da7-402b-411f-b6ea-a16beaf005e3"), new DateOnly(1977, 7, 16), "sat. Gribova", "2000818343", "Balan", "Octavian", 2 }
                });

            migrationBuilder.InsertData(
                table: "Cereri",
                columns: new[] { "CerereId", "ClientId", "CostTotal", "Eliberat", "ExecutantId", "LaReceptie", "NrCadastral", "Prelungit", "Respins", "ResponsabilId", "StareaCererii", "ValabilDeLa", "ValabilPanaLa" },
                values: new object[] { new Guid("f5bb1dbe-a8cc-4d8b-89aa-3f5a595a7546"), new Guid("6eed1456-1b25-4195-9eda-e240a9ef09fd"), 9999, null, new Guid("d8f68da7-402b-411f-b6ea-a16beaf005e3"), null, "12121212", null, null, new Guid("d8f68da7-402b-411f-b6ea-a16beaf005e3"), null, new DateOnly(2023, 6, 26), new DateOnly(2023, 7, 7) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cereri",
                keyColumn: "CerereId",
                keyValue: new Guid("f5bb1dbe-a8cc-4d8b-89aa-3f5a595a7546"));

            migrationBuilder.DeleteData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("6eed1456-1b25-4195-9eda-e240a9ef09fd"));

            migrationBuilder.DeleteData(
                table: "Persoane",
                keyColumn: "Id",
                keyValue: new Guid("d8f68da7-402b-411f-b6ea-a16beaf005e3"));
        }
    }
}
