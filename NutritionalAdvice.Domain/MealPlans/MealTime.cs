using NutritionalAdvice.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Domain.MealPlans
{
	public class MealTime : Entity
	{

		public int Number { get; private set; }
		public string Type { get; private set; }
		public DateTimeOffset Date { get; private set; }
		public Guid MealPlanId { get; private set; }
		public Guid RecipeId { get; private set; }

		public MealTime(int number, string type, DateTimeOffset date, Guid mealPlanId, Guid recipeId) : base(Guid.NewGuid())
		{
			Number = number;
			Type = type;
			Date = date;
			MealPlanId = mealPlanId;
			RecipeId = recipeId;
		}

		internal void Update(int number, string type, DateTime date, Guid recipeId)
		{
			Number = number;
			Type = type;
			Date = date;
			RecipeId = recipeId;
		}
	}
}
