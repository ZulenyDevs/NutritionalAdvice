using NutritionalAdvice.Domain.MealPlans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalAdvice.Test.Domain.MealPlans
{
    public class MealPlansTest
    {
        [Fact]
        public void validateMealPlan()
        {
            // arrange
            string name = "Dieta Equilibrada"; 
            string description = "Plan alimenticio para mantener peso (enfocado en una dieta equilibrada)";
            string goal = "Mantener peso";
            int dailyCalories = 20;
            Guid nutritionistId = new Guid();
            Guid patientId = new Guid();

            // act
            MealPlan mealPlan = new MealPlan(name, description, goal, dailyCalories, nutritionistId, patientId);

            // assert
            Assert.Equal(name, mealPlan.Name);
            Assert.Equal(description , mealPlan.Description);
            Assert.Equal(goal , mealPlan.Goal);
            Assert.Equal(dailyCalories , mealPlan.DailyCalories);
            Assert.Equal(nutritionistId , mealPlan.NutritionistId);
            Assert.Equal(patientId, mealPlan.PatientId);
        }
    }
}
