using NutritionalAdvice.Domain.Abstractions;
using NutritionalAdvice.Domain.MealPlans;
using NutritionalAdvice.Domain.Recipes.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Domain.Recipes
{
	public class Recipe : AggregateRoot
	{
		public string Name { get; private set; }
		public string Description { get; private set; }
		public int Portions { get; private set; }

		private List<RecipeIngredient> _recipeIngredients;

		private List<MealTime> _mealTimes;

		public ICollection<RecipeIngredient> RecipeIngredients
		{
			get
			{
				return _recipeIngredients;
			}
		}

		public ICollection<MealTime> MealTimes
		{
			get
			{
				return _mealTimes;
			}
		}

		public Recipe(string name, string description, int portions) : base(Guid.NewGuid())
		{
			Name = name;
			Description = description;
			Portions = portions;			
			_recipeIngredients = new List<RecipeIngredient>();
			_mealTimes = new List<MealTime>();

			AddDomainEvent(new RecipeCreated(Id, Name, Description));
		}

		public void AddRecipeIngredient(double quantity, string unitOfMeasure, Guid recipeId, Guid ingredientId)
		{
			RecipeIngredient recipeIngredient = new RecipeIngredient(unitOfMeasure, recipeId, ingredientId);
			_recipeIngredients.Add(recipeIngredient);
		}

		public void UpdateRecipeIngredient(Guid id, double quantity, string unitOfMeasure, Guid ingredientId)
		{
			RecipeIngredient recipeIngredient = _recipeIngredients.FirstOrDefault(i => i.Id == id);
			if (recipeIngredient == null)
			{
				throw new InvalidOperationException("RecipeIngredient not found in Recipe");
			}

			recipeIngredient.Update(quantity, unitOfMeasure, ingredientId);
		}

		public void RemoveRecipeIngredient(Guid id)
		{
			RecipeIngredient recipeIngredient = _recipeIngredients.FirstOrDefault(i => i.Id == id);
			if (recipeIngredient == null)
			{
				throw new InvalidOperationException("RecipeIngredient not found in Recipe");
			}
			_recipeIngredients.Remove(recipeIngredient);
		}
	}
}
