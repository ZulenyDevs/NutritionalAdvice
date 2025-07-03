using NutritionalAdvice.Domain.MealPlans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalAdvice.Test.Domain.MealPlans
{
	public class MealTimeTest
	{
		[Fact]
		public void validateMealTime()
		{
			// arrange
			int number = 1;
			string type = "Horario cena";
			DateTime date = DateTime.Now;
			Guid mealPlanId = new Guid();
			Guid recipeId = new Guid();

			// act
			MealTime mealTime = new MealTime(number, type, date, mealPlanId, recipeId);

			// assert
			Assert.Equal(number, mealTime.Number);
			Assert.Equal(type, mealTime.Type);
			Assert.Equal(date, mealTime.Date);
			Assert.Equal(mealPlanId, mealTime.MealPlanId);
			Assert.Equal(recipeId, mealTime.RecipeId);
		}
	}
}
