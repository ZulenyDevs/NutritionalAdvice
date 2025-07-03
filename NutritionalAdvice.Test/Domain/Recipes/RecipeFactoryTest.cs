using NutritionalAdvice.Domain.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalAdvice.Test.Domain.Recipes
{
	public class RecipeFactoryTest
	{
		[Fact]
		public void validateRecipe()
		{
			// arrange
			string name = "Arroz con huevo";
			string description = "Receta para una comida economica y muy yomi yomi!";
			int portions = 2;

			// act
			IRecipeFactory recipeFactory = new RecipeFactory();
			Recipe recipe = recipeFactory.Create(name, description, portions);

			// assert
			Assert.Equal(name, recipe.Name);
			Assert.Equal(description, recipe.Description);
			Assert.Equal(portions, recipe.Portions);
		}

		[Fact]
		public void Create_ShouldThrowArgumentException_WhenAllParametersAreLessThanOne()
		{
			// Arrange
			var factory = new RecipeFactory();
			string name = "Test Recipe";
			string description = "This is a test recipe.";
			int portions = 0; // portions menor que 1

			// Act & Assert
			var exception = Assert.Throws<ArgumentException>(() => factory.Create(name, description, portions));
			Assert.Equal("portions must be greater than 0", exception.Message);
		}
	}
}
