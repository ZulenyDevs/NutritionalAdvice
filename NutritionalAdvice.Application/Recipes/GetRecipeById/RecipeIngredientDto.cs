using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Application.Recipes.GetRecipeById
{
	public class RecipeIngredientDto
	{
		public Guid Id { get; set; }
		public double Quantity { get; set; }
		public string UnitOfMeasure { get; set; }
		public Guid RecipeId { get; set; }
		public Guid IngredientId { get; set; }
	}
}
