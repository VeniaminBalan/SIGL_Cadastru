using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGL_Cadastru.Repo.Migrations
{
    /// <inheritdoc />
    public partial class upd2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Dosare",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Dosare");
        }
    }
}
