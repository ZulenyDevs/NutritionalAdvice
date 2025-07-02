using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Domain.MealPlans
{
	public class MealPlanFactory : IMealPlanFactory
	{
		public MealPlan Create(string name, string description, string goal, int dailyCalories, double dailyProtein, double dailyCarbohydrates, double dailyFats, Guid nutritionistId, Guid patientId, Guid diagnosticId, List<(int number, string type, DateTimeOffset date, Guid recipeId)> mealTimes)
		{
			if (nutritionistId == Guid.Empty || patientId == Guid.Empty || diagnosticId == Guid.Empty)
			{
				throw new ArgumentException("nutritionistId, patientId and diagnosticId are required");
			}

			MealPlan mealPlan = new MealPlan(name, description, goal, dailyCalories, nutritionistId, patientId, diagnosticId);

			foreach (var mealTime in mealTimes)
			{
				mealPlan.AddMealTime(mealTime.number, mealTime.type, mealTime.date, mealTime.recipeId);
			}

			return mealPlan;
		}
	}
}
