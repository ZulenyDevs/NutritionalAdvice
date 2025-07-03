using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NutritionalAdvice.Application.Recipes.GetRecipeById;
using NutritionalAdvice.Infrastructure.Handlers.Recipe;
using NutritionalAdvice.Infrastructure.StoredModel;
using NutritionalAdvice.Infrastructure.StoredModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalAdvice.Test.Infrastructure.Handlers.Recipe
{
	public class GetRecipeByIdHandlerTest
	{
		private readonly Mock<StoredDbContext> _dbContext;

		public GetRecipeByIdHandlerTest()
		{
			var options = new DbContextOptions<StoredDbContext>();
			_dbContext = new Mock<StoredDbContext>(options);
		}

		[Fact]
		public async Task HandleIsValid()
		{

			// Arrange
			var recipeId = Guid.NewGuid();
			var recipe = new RecipeStoredModel {
				Id = recipeId,
				Name = "Spaghetti Bolognese",
				Description = "Classic Italian pasta dish",
				Portions = 4,
				RecipeIngredients = new List<RecipeIngredientStoredModel>
				{
					new RecipeIngredientStoredModel { Id = Guid.NewGuid(), Quantity = 200, UnitOfMeasure = "g", RecipeId = Guid.NewGuid(), IngredientId = Guid.NewGuid() },
					new RecipeIngredientStoredModel { Id = Guid.NewGuid(), Quantity = 100, UnitOfMeasure = "ml", RecipeId = Guid.NewGuid(), IngredientId = Guid.NewGuid() }
				}
			};

			_dbContext.Setup(x => x.Recipe).ReturnsDbSet(new List<RecipeStoredModel> { recipe });

			var handler = new GetRecipeByIdHandler(_dbContext.Object);

			// Act
			var result = await handler.Handle(new GetRecipeByIdQuery(recipeId), CancellationToken.None);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(recipeId, result.Id);
			Assert.Equal("Spaghetti Bolognese", result.Name);
			Assert.Equal(2, result.RecipeIngredients.Count);
		}

		[Fact]
		public async Task Handle_ReturnsRecipeNotFound_WhenRecipeDoesNotExist()
		{
			// Arrange
			var recipeId = Guid.NewGuid(); // ID de una receta que no existe en la base de datos

			// Simulamos que la base de datos no contiene ninguna receta
			_dbContext.Setup(x => x.Recipe).ReturnsDbSet(new List<RecipeStoredModel>());

			var handler = new GetRecipeByIdHandler(_dbContext.Object);

			// Act
			var result = await handler.Handle(new GetRecipeByIdQuery(recipeId), CancellationToken.None);

			// Assert
			Assert.NotNull(result);
			Assert.NotNull(result.Name);
			Assert.Equal("Recipe Not Found", result.Name); // Verificar que el nombre sea "Recipe Not Found"


		}
	}
}
