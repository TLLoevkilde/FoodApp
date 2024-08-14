﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodApp.API.Migrations
{
    /// <inheritdoc />
    public partial class CalPerHundredGramsOProteinisint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CalPerHundredGramsOfProtein",
                table: "FoodItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "CalPerHundredGramsOfProtein",
                table: "FoodItems",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
