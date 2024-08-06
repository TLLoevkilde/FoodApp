using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodApp.API.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedFoodItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CaloriesPerHundredGrams",
                table: "FoodItems",
                newName: "PricePerHundredGramsOfProtein");

            migrationBuilder.AddColumn<double>(
                name: "CalPerHundredGrams",
                table: "FoodItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CalPerHundredGramsOfProtein",
                table: "FoodItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GramsOfProteinPerWeightInGrams",
                table: "FoodItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalPerHundredGrams",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "CalPerHundredGramsOfProtein",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "GramsOfProteinPerWeightInGrams",
                table: "FoodItems");

            migrationBuilder.RenameColumn(
                name: "PricePerHundredGramsOfProtein",
                table: "FoodItems",
                newName: "CaloriesPerHundredGrams");
        }
    }
}
