using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Application.Ingredients.GetIngredients
{
	public class IngredientDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Variety { get; set; }
		public string Benefits { get; set; }
		public string DishCategory { get; set; }
	}
}
