using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Domain.Ingredients
{
    public interface IIngredientFactory
    {
        Ingredient Create(string name, string variety, string benefits, string dishCategory);
    }
}
