using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutritionalAdvice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "outbox");

            migrationBuilder.CreateTable(
                name: "ingredient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Variety = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Benefits = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    DishCategory = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mealplan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Goal = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    DailyCalories = table.Column<int>(type: "integer", nullable: false),
                    DailyProtein = table.Column<double>(type: "double precision", nullable: false),
                    DailyCarbohydrates = table.Column<double>(type: "double precision", nullable: false),
                    DailyFats = table.Column<double>(type: "double precision", nullable: false),
                    NutritionistId = table.Column<Guid>(type: "uuid", nullable: false),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mealplan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "outboxMessage",
                schema: "outbox",
                columns: table => new
                {
                    outboxId = table.Column<Guid>(type: "uuid", nullable: false),
                    content = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    processed = table.Column<bool>(type: "boolean", nullable: false),
                    processedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    correlationId = table.Column<string>(type: "text", nullable: true),
                    traceId = table.Column<string>(type: "text", nullable: true),
                    spanId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_outboxMessage", x => x.outboxId);
                });

            migrationBuilder.CreateTable(
                name: "recipe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    PreparationTime = table.Column<int>(type: "integer", nullable: false),
                    CookingTime = table.Column<int>(type: "integer", nullable: false),
                    Portions = table.Column<int>(type: "integer", nullable: false),
                    Instructions = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mealtime",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MealPlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uuid", nullable: false),
                    MealPlanStoredModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mealtime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mealtime_mealplan_MealPlanStoredModelId",
                        column: x => x.MealPlanStoredModelId,
                        principalTable: "mealplan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "recipeingredient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<double>(type: "double precision", nullable: false),
                    UnitOfMeasure = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    RecipeId = table.Column<Guid>(type: "uuid", nullable: false),
                    IngredientId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipeStoredModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipeingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_recipeingredient_recipe_RecipeStoredModelId",
                        column: x => x.RecipeStoredModelId,
                        principalTable: "recipe",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_mealtime_MealPlanStoredModelId",
                table: "mealtime",
                column: "MealPlanStoredModelId");

            migrationBuilder.CreateIndex(
                name: "IX_recipeingredient_RecipeStoredModelId",
                table: "recipeingredient",
                column: "RecipeStoredModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ingredient");

            migrationBuilder.DropTable(
                name: "mealtime");

            migrationBuilder.DropTable(
                name: "outboxMessage",
                schema: "outbox");

            migrationBuilder.DropTable(
                name: "recipeingredient");

            migrationBuilder.DropTable(
                name: "mealplan");

            migrationBuilder.DropTable(
                name: "recipe");
        }
    }
}
