using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ludotek.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AjoutColonneIsTermine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTermine",
                table: "Items",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTermine",
                table: "Items");
        }
    }
}
