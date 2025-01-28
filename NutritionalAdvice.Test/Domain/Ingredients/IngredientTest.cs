using NutritionalAdvice.Domain.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalAdvice.Test.Domain.Ingredients
{
    public class IngredientTest
    {
        [Fact]
        public void IngredientCreationIsValid()
        {
            // arrange 
            string name = "Tomate";
            string variety = "Chery";
            string benefits = "Posee propiedades diuréticas, antiinflamatorias, antioxidantes, anticancerígenas, digestivas, entre otras";
            string dishCategory = "ensaladas";

            // act
            Ingredient ingredient = new Ingredient(name, variety, benefits, dishCategory);

            // assert
            Assert.Equal(name, ingredient.Name);
            Assert.Equal(variety, ingredient.Variety);
            Assert.Equal(benefits, ingredient.Benefits);
            Assert.Equal(dishCategory, ingredient.DishCategory);

        }

    }
}
