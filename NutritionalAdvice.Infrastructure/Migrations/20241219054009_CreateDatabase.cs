using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Diagnostics.CodeAnalysis;

namespace NutritionalAdvice.Infrastructure.Migrations
{
	[ExcludeFromCodeCoverage]
	public partial class CreateDatabase : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterDatabase()
				.Annotation("MySql:CharSet", "utf8mb4");

			migrationBuilder.CreateTable(
				name: "ingredient",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
					Name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
						.Annotation("MySql:CharSet", "utf8mb4"),
					Variety = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
						.Annotation("MySql:CharSet", "utf8mb4"),
					Benefits = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
						.Annotation("MySql:CharSet", "utf8mb4"),
					DishCategory = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
						.Annotation("MySql:CharSet", "utf8mb4")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ingredient", x => x.Id);
				})
				.Annotation("MySql:CharSet", "utf8mb4");

			migrationBuilder.CreateTable(
				name: "mealplan",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
					Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
						.Annotation("MySql:CharSet", "utf8mb4"),
					Description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
						.Annotation("MySql:CharSet", "utf8mb4"),
					Goal = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
						.Annotation("MySql:CharSet", "utf8mb4"),
					DailyCalories = table.Column<int>(type: "int", nullable: false),
					DailyProtein = table.Column<double>(type: "double", nullable: false),
					DailyCarbohydrates = table.Column<double>(type: "double", nullable: false),
					DailyFats = table.Column<double>(type: "double", nullable: false),
					NutritionistId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
					PatientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_mealplan", x => x.Id);
				})
				.Annotation("MySql:CharSet", "utf8mb4");

			migrationBuilder.CreateTable(
				name: "recipe",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
					Name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
						.Annotation("MySql:CharSet", "utf8mb4"),
					Description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
						.Annotation("MySql:CharSet", "utf8mb4"),
					PreparationTime = table.Column<int>(type: "int", nullable: false),
					CookingTime = table.Column<int>(type: "int", nullable: false),
					Portions = table.Column<int>(type: "int", nullable: false),
					Instructions = table.Column<string>(type: "longtext", nullable: true)
						.Annotation("MySql:CharSet", "utf8mb4")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_recipe", x => x.Id);
				})
				.Annotation("MySql:CharSet", "utf8mb4");

			migrationBuilder.CreateTable(
				name: "mealtime",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
					Number = table.Column<int>(type: "int", nullable: false),
					Type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
						.Annotation("MySql:CharSet", "utf8mb4"),
					MealPlanId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
					RecipeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
					MealPlanStoredModelId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_mealtime", x => x.Id);
					table.ForeignKey(
						name: "FK_mealtime_mealplan_MealPlanStoredModelId",
						column: x => x.MealPlanStoredModelId,
						principalTable: "mealplan",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				})
				.Annotation("MySql:CharSet", "utf8mb4");

			migrationBuilder.CreateTable(
				name: "recipeingredient",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
					Quantity = table.Column<double>(type: "double", nullable: false),
					UnitOfMeasure = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
						.Annotation("MySql:CharSet", "utf8mb4"),
					RecipeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
					IngredientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
					RecipeStoredModelId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_recipeingredient", x => x.Id);
					table.ForeignKey(
						name: "FK_recipeingredient_recipe_RecipeStoredModelId",
						column: x => x.RecipeStoredModelId,
						principalTable: "recipe",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				})
				.Annotation("MySql:CharSet", "utf8mb4");

			migrationBuilder.CreateIndex(
				name: "IX_mealtime_MealPlanStoredModelId",
				table: "mealtime",
				column: "MealPlanStoredModelId");

			migrationBuilder.CreateIndex(
				name: "IX_recipeingredient_RecipeStoredModelId",
				table: "recipeingredient",
				column: "RecipeStoredModelId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "ingredient");

			migrationBuilder.DropTable(
				name: "mealtime");

			migrationBuilder.DropTable(
				name: "recipeingredient");

			migrationBuilder.DropTable(
				name: "mealplan");

			migrationBuilder.DropTable(
				name: "recipe");
		}
	}
}
