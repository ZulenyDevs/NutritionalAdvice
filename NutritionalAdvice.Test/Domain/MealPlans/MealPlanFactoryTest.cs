using NutritionalAdvice.Domain.MealPlans;
using NutritionalAdvice.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalAdvice.Test.Domain.MealPlans
{
    public class MealPlanFactoryTest
    {
        [Fact]
        public void validateMealPlanFactory()
        {
            // arrange
            string name = "Plan adelagazamiento";
            string description = "descripcion de plan adelagazamiento";
            string goal = "Bajar peso";
            int dailyCalories = 20;
            QuantityValue dailyProtein = 0;
            QuantityValue dailyCarbohydrates = 0;
            QuantityValue dailyFats = 0;
            Guid nutritionistId = Guid.NewGuid();
            Guid patientId = Guid.NewGuid();

            // act
            IMealPlanFactory mealPlanFactory = new MealPlanFactory();
            MealPlan mealPlanSaved = mealPlanFactory.Create(name, description, goal, dailyCalories,
                dailyProtein, dailyCarbohydrates, dailyFats, nutritionistId, patientId);

            // assert
            Assert.Equal(name, mealPlanSaved.Name);
            Assert.Equal(description, mealPlanSaved.Description);
            Assert.Equal(goal, mealPlanSaved.Goal);
            Assert.Equal(dailyCalories, mealPlanSaved.DailyCalories);
            Assert.Equal(dailyProtein, mealPlanSaved.DailyProtein);
            Assert.Equal(dailyCarbohydrates, mealPlanSaved.DailyCarbohydrates);
            Assert.Equal(dailyFats, mealPlanSaved.DailyFats);
            Assert.Equal(nutritionistId, mealPlanSaved.NutritionistId);
            Assert.Equal(patientId, mealPlanSaved.PatientId);
        }
    }
}
