using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Domain.Recipes
{
	public class RecipeFactory : IRecipeFactory
	{
		public Recipe Create(string name, string description, int portions)
		{
			if (portions < 1)
			{
				throw new ArgumentException("portions must be greater than 0");
			}

			Recipe recipe = new Recipe(name, description, portions);
			return recipe;
		}
	}
}
