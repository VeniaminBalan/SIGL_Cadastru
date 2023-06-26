using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGL_Cadastru.Repo.Migrations
{
    /// <inheritdoc />
    public partial class upd5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CerereId",
                table: "Lucrari",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Lucrari_CerereId",
                table: "Lucrari",
                column: "CerereId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lucrari_Cereri_CerereId",
                table: "Lucrari",
                column: "CerereId",
                principalTable: "Cereri",
                principalColumn: "CerereId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lucrari_Cereri_CerereId",
                table: "Lucrari");

            migrationBuilder.DropIndex(
                name: "IX_Lucrari_CerereId",
                table: "Lucrari");

            migrationBuilder.DropColumn(
                name: "CerereId",
                table: "Lucrari");
        }
    }
}
