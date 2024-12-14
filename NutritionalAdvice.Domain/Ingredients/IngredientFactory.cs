using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Domain.Ingredients
{
    public class IngredientFactory : IIngredientFactory
    {
        public Ingredient Create(string name, string variety, string benefits, string dishCategory)
        {
            Ingredient ingredient = new Ingredient(name, variety, benefits, dishCategory);
            return ingredient;
        }
    }
}
