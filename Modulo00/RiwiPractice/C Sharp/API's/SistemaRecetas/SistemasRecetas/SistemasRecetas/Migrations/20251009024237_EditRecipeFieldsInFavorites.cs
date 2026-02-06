using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemasRecetas.Migrations
{
    /// <inheritdoc />
    public partial class EditRecipeFieldsInFavorites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IngredientsText",
                table: "Favorites",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "InstructionsText",
                table: "Favorites",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IngredientsText",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "InstructionsText",
                table: "Favorites");
        }
    }
}
