using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Domain.Recipes
{
    public interface IRecipeFactory
    {
        Recipe Create(string name, string description, int preparationTime, int cookingTime, int portions, List<string> instructions);
    }
}
