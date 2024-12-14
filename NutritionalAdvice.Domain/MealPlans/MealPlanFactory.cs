using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Domain.MealPlans
{
    public class MealPlanFactory : IMealPlanFactory
    {
        public MealPlan Create(string name, string description, string goal, int dailyCalories, int dailyProtein, int dailyCarbohydrates, int dailyFats, Guid nutritionistId, Guid patientId)
        {
            if (nutritionistId == Guid.Empty || patientId == Guid.Empty)
            {
                throw new ArgumentException("nutritionistId and patientId are required");
            }
            MealPlan mealPlan = new MealPlan(name, description, goal, dailyCalories, dailyProtein, dailyCarbohydrates, dailyFats, nutritionistId, patientId);
            return mealPlan;
        }
    }
}
