using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Domain.MealPlans
{
	public interface IMealPlanFactory
	{
		MealPlan Create(string name, string description, string goal, int dailyCalories, double dailyProtein, double dailyCarbohydrates, double dailyFats, Guid nutritionistId, Guid patientId, Guid diagnosticId, List<(int number, string type, DateTimeOffset date, Guid recipeId)> mealTimes);
	}
}
