using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodApp.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangedfieldnameinFoodItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GramsOfProteinPerWeightInGrams",
                table: "FoodItems",
                newName: "ProteinPerWeightInGrams");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProteinPerWeightInGrams",
                table: "FoodItems",
                newName: "GramsOfProteinPerWeightInGrams");
        }
    }
}
