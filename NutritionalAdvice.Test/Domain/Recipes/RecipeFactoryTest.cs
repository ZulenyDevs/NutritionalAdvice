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
            int preparationTime = 30;
            int cookingTime = 20;
            int portions = 2;
            List<string> instructions = new List<string> {
                "1. Colocar aceite a la sarten",
                "2. Colocar 1/2 taza de arroz y tostar en la sarten hasta que los granos esten dorados",
                "3. Colocar 2 tazas de agua hervida y esperar a que hierva el arroz",
                "3. Colocar a la sarten un Huevo estrellado y dejar cocer",
                "3. Sal y pimienta al gusto"
            };

            // act
            IRecipeFactory recipeFactory = new RecipeFactory();
            Recipe recipe = recipeFactory.Create(name, description, preparationTime, cookingTime, portions, instructions);

            // assert
            Assert.Equal(name, recipe.Name);
            Assert.Equal(description, recipe.Description);
            Assert.Equal(preparationTime, recipe.PreparationTime);
            Assert.Equal(cookingTime, recipe.CookingTime);
            Assert.Equal(portions, recipe.Portions);
            Assert.Equal(instructions, recipe.Instructions);
        }
    }
}
