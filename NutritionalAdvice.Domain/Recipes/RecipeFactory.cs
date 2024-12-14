using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Domain.Recipes
{
    public class RecipeFactory : IRecipeFactory
    {
        public Recipe Create(string name, string description, int preparationTime, int cookingTime, int portions, List<string> instructions)
        {
            if(preparationTime < 1 || cookingTime < 1 || portions < 1)
            {
                throw new ArgumentException("preparationTime, cookingTime and portions must be greater than 0");
            }
            Recipe recipe = new Recipe(name, description, preparationTime, cookingTime, portions, instructions);
            return recipe;
        }
    }
}
