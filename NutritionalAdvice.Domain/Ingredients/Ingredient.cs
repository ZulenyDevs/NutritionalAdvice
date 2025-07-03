using NutritionalAdvice.Domain.Abstractions;
using NutritionalAdvice.Domain.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Domain.Ingredients
{
	public class Ingredient : AggregateRoot
	{
		public string Name { get; private set; }
		public string Variety { get; private set; }
		public string Benefits { get; private set; }
		public string DishCategory { get; private set; }
		private List<RecipeIngredient> _recipeIngredients;

		public ICollection<RecipeIngredient> RecipeIngredients
		{
			get
			{
				return _recipeIngredients;
			}
		}

		public Ingredient(string name, string variety, string benefits, string dishCategory) : base(Guid.NewGuid())
		{
			Name = name;
			Variety = variety;
			Benefits = benefits;
			DishCategory = dishCategory;
			_recipeIngredients = new List<RecipeIngredient>();
		}
	}
}
