using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGL_Cadastru.Repo.Migrations
{
    /// <inheritdoc />
    public partial class upd4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cereri_Persoane_ClientId",
                table: "Cereri");

            migrationBuilder.DropForeignKey(
                name: "FK_Cereri_Persoane_ExecutantId",
                table: "Cereri");

            migrationBuilder.DropForeignKey(
                name: "FK_Cereri_Persoane_ResponsabilId",
                table: "Cereri");

            migrationBuilder.DropTable(
                name: "Dosare");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Persoane");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Persoane");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Lucrari");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Lucrari");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Cereri");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Cereri");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cereri",
                newName: "CerereId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ResponsabilId",
                table: "Cereri",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ExecutantId",
                table: "Cereri",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "Cereri",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cereri_Persoane_ClientId",
                table: "Cereri",
                column: "ClientId",
                principalTable: "Persoane",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cereri_Persoane_ExecutantId",
                table: "Cereri",
                column: "ExecutantId",
                principalTable: "Persoane",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cereri_Persoane_ResponsabilId",
                table: "Cereri",
                column: "ResponsabilId",
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

            migrationBuilder.DropForeignKey(
                name: "FK_Cereri_Persoane_ExecutantId",
                table: "Cereri");

            migrationBuilder.DropForeignKey(
                name: "FK_Cereri_Persoane_ResponsabilId",
                table: "Cereri");

            migrationBuilder.RenameColumn(
                name: "CerereId",
                table: "Cereri",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Persoane",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Persoane",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Lucrari",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Lucrari",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ResponsabilId",
                table: "Cereri",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ExecutantId",
                table: "Cereri",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Cereri",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Cereri",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Cereri",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Dosare",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosare", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cereri_Persoane_ClientId",
                table: "Cereri",
                column: "ClientId",
                principalTable: "Persoane",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cereri_Persoane_ExecutantId",
                table: "Cereri",
                column: "ExecutantId",
                principalTable: "Persoane",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cereri_Persoane_ResponsabilId",
                table: "Cereri",
                column: "ResponsabilId",
                principalTable: "Persoane",
                principalColumn: "Id");
        }
    }
}
