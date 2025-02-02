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
    public class RecipeTest
    {
        [Fact]
        public void RecipeCreationIsValid()
        {
            // arrange 
            string name = "Espaguetis a la Carbonara";
            string description = "Un plato clásico italiano hecho con huevos, queso, panceta y pimienta.";
            int preparationTime = 15;
            int cookingTime = 20;
            int portions = 4;
            List<string> instructions = new()
                                        {
                                            "1. Hervir los espaguetis.",
                                            "2. Cocinar la panceta hasta que esté crujiente.",
                                            "3. Mezclar los huevos y el queso en un bol.",
                                            "4. Combinar los espaguetis con la panceta y la mezcla de huevo.",
                                            "5. Servir con una pizca de pimienta."
                                        };

            // act
            Recipe recipe = new Recipe(name, description, preparationTime, cookingTime, portions, instructions);

            // assert
            Assert.Equal(name, recipe.Name);
            Assert.Equal(description, recipe.Description);
            Assert.Equal(preparationTime, recipe.PreparationTime);
            Assert.Equal(cookingTime, recipe.CookingTime);
            Assert.Equal(portions, recipe.Portions);
            Assert.Equal(instructions, recipe.Instructions);
        }

        [Fact]
        public void ShouldAddRecipeIngredientToList()
        {
            // arrange 
            string name = "Espaguetis a la Carbonara";
            string description = "Un plato clásico italiano hecho con huevos, queso, panceta y pimienta.";
            int preparationTime = 15;
            int cookingTime = 20;
            int portions = 4;
            List<string> instructions = new()
            {
                "1. Hervir los espaguetis.",
                "2. Cocinar la panceta hasta que esté crujiente.",
                "3. Mezclar los huevos y el queso en un bol.",
                "4. Combinar los espaguetis con la panceta y la mezcla de huevo.",
                "5. Servir con una pizca de pimienta."
            };

            Recipe recipe = new Recipe(name, description, preparationTime, cookingTime, portions, instructions);

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
            int preparationTime = 15;
            int cookingTime = 20;
            int portions = 4;
            List<string> instructions = new()
            {
                "1. Hervir los espaguetis.",
                "2. Cocinar la panceta hasta que esté crujiente.",
                "3. Mezclar los huevos y el queso en un bol.",
                "4. Combinar los espaguetis con la panceta y la mezcla de huevo.",
                "5. Servir con una pizca de pimienta."
            };

            double initialQuantity = 1.5;
            string initialUnitOfMeasure = "kg";
            Guid initialIngredientId = Guid.NewGuid();

            double updatedQuantity = 2.0;
            string updatedUnitOfMeasure = "lt";
            Guid updatedIngredientId = Guid.NewGuid();

            Recipe recipe = new Recipe(name, description, preparationTime, cookingTime, portions, instructions);

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
            int preparationTime = 15;
            int cookingTime = 20;
            int portions = 4;
            List<string> instructions = new()
            {
                "1. Hervir los espaguetis.",
                "2. Cocinar la panceta hasta que esté crujiente.",
                "3. Mezclar los huevos y el queso en un bol.",
                "4. Combinar los espaguetis con la panceta y la mezcla de huevo.",
                "5. Servir con una pizca de pimienta."
            };

            Recipe recipe = new Recipe(name, description, preparationTime, cookingTime, portions, instructions);
            var recipeIngredient = new RecipeIngredient("kg", recipe.Id, Guid.NewGuid());
            
            recipe.RecipeIngredients.Add(recipeIngredient);

            // Act
            recipe.RemoveRecipeIngredient(recipeIngredient.Id);

            // Assert
            Assert.Empty(recipe.RecipeIngredients);
        }
    }
}
