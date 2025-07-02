using MediatR;
using System;
using System.Collections.Generic;

namespace NutritionalAdvice.Application.MealPlans.CreateMealPlan
{
	public record CreateMealTimeCommand(int number, string type, DateTimeOffset date, Guid recipeId) : IRequest<Guid>;

	public record CreateMealPlanCommand(string name, string description, string goal, int dailyCalories, double dailyProtein, double dailyCarbohydrates, double dailyFats, Guid nutritionistId, Guid patientId, Guid diagnosticId, ICollection<CreateMealTimeCommand> mealTimes) : IRequest<Guid>;
}
