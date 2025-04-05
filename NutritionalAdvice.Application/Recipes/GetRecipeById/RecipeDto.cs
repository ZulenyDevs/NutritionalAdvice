using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Application.Recipes.GetRecipeById
{
	public class RecipeDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int PreparationTime { get; set; }
		public int CookingTime { get; set; }
		public int Portions { get; set; }
		public List<string> Instructions { get; set; }

		public List<RecipeIngredientDto> RecipeIngredients;
	}
}
