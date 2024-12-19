using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Application.MealPlans.CreateMealPlan
{
    public record CreateMealPlanCommand(string name, string description, string goal, int dailyCalories, double dailyProtein, double dailyCarbohydrates, double dailyFats, Guid nutritionistId, Guid patientId) : IRequest<Guid>;
}
