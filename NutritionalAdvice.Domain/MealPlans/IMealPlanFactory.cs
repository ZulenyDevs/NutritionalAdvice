using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Domain.MealPlans
{
    public interface IMealPlanFactory
    {
        MealPlan Create(string name, string description, string goal, int dailyCalories, int dailyProtein, int dailyCarbohydrates, int dailyFats, Guid nutritionistId, Guid patientId);
    }
}
