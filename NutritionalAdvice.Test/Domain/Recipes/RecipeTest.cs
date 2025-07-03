﻿using NutritionalAdvice.Domain.Recipes;
using NutritionalAdvice.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalAdvice.Test.Domain.Recipes
{
	public class RecipeTest
	{
		[Fact]
		public void RecipeCreationIsValid()
		{
			// arrange 
			string name = "Espaguetis a la Carbonara";
			string description = "Un plato clásico italiano hecho con huevos, queso, panceta y pimienta.";
			int portions = 4;

			// act
			Recipe recipe = new Recipe(name, description, portions);

			// assert
			Assert.Equal(name, recipe.Name);
			Assert.Equal(description, recipe.Description);
			Assert.Equal(portions, recipe.Portions);
		}

		[Fact]
		public void ShouldAddRecipeIngredientToList()
		{
			// arrange 
			string name = "Espaguetis a la Carbonara";
			string description = "Un plato clásico italiano hecho con huevos, queso, panceta y pimienta.";
			int portions = 4;

			Recipe recipe = new Recipe(name, description, portions);

			QuantityValue quantity = 10;
			string unitOfMeasure = "gramos";
			Guid ingredientId = Guid.NewGuid();

			// act
			recipe.AddRecipeIngredient(quantity, unitOfMeasure, recipe.Id, ingredientId);

			// assert
			Assert.Single(recipe.RecipeIngredients);
			var addedIngredient = recipe.RecipeIngredients.First();
			Assert.Equal(quantity, addedIngredient.Quantity);
			Assert.Equal(unitOfMeasure, addedIngredient.UnitOfMeasure);
			Assert.Equal(recipe.Id, addedIngredient.RecipeId);
			Assert.Equal(ingredientId, addedIngredient.IngredientId);
		}

		[Fact]
		public void ShouldUpdateExistingIngredient()
		{
			// Arrange

			string name = "Espaguetis a la Carbonara";
			string description = "Un plato clásico italiano hecho con huevos, queso, panceta y pimienta.";
			int portions = 4;

			double initialQuantity = 1.5;
			string initialUnitOfMeasure = "kg";
			Guid initialIngredientId = Guid.NewGuid();

			double updatedQuantity = 2.0;
			string updatedUnitOfMeasure = "lt";
			Guid updatedIngredientId = Guid.NewGuid();

			Recipe recipe = new Recipe(name, description, portions);

			var recipeIngredient = new RecipeIngredient(initialUnitOfMeasure, recipe.Id, initialIngredientId);

			recipe.RecipeIngredients.Add(recipeIngredient);

			// Act
			recipe.UpdateRecipeIngredient(recipeIngredient.Id, updatedQuantity, updatedUnitOfMeasure, updatedIngredientId);

			// Assert
			var updatedIngredient = recipe.RecipeIngredients.First(i => i.Id == recipeIngredient.Id);
			Assert.Equal(updatedQuantity, (double)updatedIngredient.Quantity);
			Assert.Equal(updatedUnitOfMeasure, updatedIngredient.UnitOfMeasure);
			Assert.Equal(updatedIngredientId, updatedIngredient.IngredientId);
		}

		[Fact]
		public void RemoveRecipeIngredientIsValid()
		{
			// Arrange
			string name = "Espaguetis a la Carbonara";
			string description = "Un plato clásico italiano hecho con huevos, queso, panceta y pimienta.";
			int portions = 4;

			Recipe recipe = new Recipe(name, description, portions);
			var recipeIngredient = new RecipeIngredient("kg", recipe.Id, Guid.NewGuid());

			recipe.RecipeIngredients.Add(recipeIngredient);

			// Act
			recipe.RemoveRecipeIngredient(recipeIngredient.Id);

			// Assert
			Assert.Empty(recipe.RecipeIngredients);
		}

		[Fact]
		public void UpdateRecipeIngredient_ShouldThrowInvalidOperationException_WhenIngredientNotFound()
		{
			// Arrange
			string name = "Espaguetis a la Carbonara";
			string description = "Un plato clásico italiano hecho con huevos, queso, panceta y pimienta.";
			int portions = 4;
			
			Recipe recipe = new Recipe(name, description, portions);
			double updatedQuantity = 2.0;
			string updatedUnitOfMeasure = "lt";
			Guid updatedIngredientId = Guid.NewGuid();


			var nonExistentId = Guid.NewGuid();

			// Act & Assert
			var exception = Assert.Throws<InvalidOperationException>(() =>
				recipe.UpdateRecipeIngredient(nonExistentId, updatedQuantity, updatedUnitOfMeasure, updatedIngredientId));

			Assert.Equal("RecipeIngredient not found in Recipe", exception.Message);


		}

		[Fact]
		public void RemoveRecipeIngredient_ShouldThrowInvalidOperationException_WhenIngredientNotFound()
		{
			// Arrange
			string name = "Espaguetis a la Carbonara";
			string description = "Un plato clásico italiano hecho con huevos, queso, panceta y pimienta.";
			int portions = 4;
			
			Recipe recipe = new Recipe(name, description, portions);
			double updatedQuantity = 2.0;
			string updatedUnitOfMeasure = "lt";
			Guid updatedIngredientId = Guid.NewGuid();
			var nonExistentId = Guid.NewGuid();

			// Act & Assert
			var exception = Assert.Throws<InvalidOperationException>(() =>
				recipe.RemoveRecipeIngredient(nonExistentId));

			Assert.Equal("RecipeIngredient not found in Recipe", exception.Message);
		}
	}
}
