using NutritionalAdvice.Domain.Recipes;
using NutritionalAdvice.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalAdvice.Test.Domain.Recipes
{
    public class RecipeIngredientTest
    {
        [Fact]
        public void RecipeIngredientCreationIsValid()
        {
            // arrange 
            QuantityValue quantity = 10;
            string unitOfMeasure = "gramos";
            Guid recipeId = Guid.NewGuid();
            Guid ingredientId = Guid.NewGuid();

            // act
            RecipeIngredient recipeIngredient = new RecipeIngredient(unitOfMeasure, recipeId, ingredientId);

            // assert
            Assert.Equal(quantity, recipeIngredient.Quantity);
            Assert.Equal(unitOfMeasure, recipeIngredient.UnitOfMeasure);
            Assert.Equal(recipeId, recipeIngredient.RecipeId);
            Assert.Equal(ingredientId, recipeIngredient.IngredientId);

        }

        [Fact]
        public void UpdateIsValid()
        {
            // arrange 
            QuantityValue quantity = 10;
            string unitOfMeasure = "gramos";
            Guid recipeId = Guid.NewGuid();
            Guid ingredientId = Guid.NewGuid();
            RecipeIngredient recipeIngredient = new RecipeIngredient(unitOfMeasure, recipeId, ingredientId);

            // act
            recipeIngredient.Update(quantity, unitOfMeasure, ingredientId);

            // assert
            Assert.Equal(quantity, recipeIngredient.Quantity);
            Assert.Equal(unitOfMeasure, recipeIngredient.UnitOfMeasure);
            Assert.Equal(ingredientId, recipeIngredient.IngredientId);

        }

        [Theory]
        [InlineData(0, "kg", 0, "kg")]
        public void UpdateWithValues(double quantity, string unitOfMeasure, double expectedQuantity, string expectedUnitOfMeasure)
        {
            // arrange 
            Guid recipeId = Guid.NewGuid();
            Guid ingredientId = Guid.NewGuid();
            RecipeIngredient recipeIngredient = new RecipeIngredient(unitOfMeasure, recipeId, ingredientId);

            // act
            recipeIngredient.Update(quantity, unitOfMeasure, ingredientId);

            // assert
            Assert.Equal(expectedQuantity, (double)recipeIngredient.Quantity);
            Assert.Equal(expectedUnitOfMeasure, recipeIngredient.UnitOfMeasure);
            Assert.Equal(ingredientId, recipeIngredient.IngredientId);

        }
    }
}
