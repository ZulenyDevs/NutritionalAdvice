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
			Guid diagnosticId = Guid.NewGuid();

			// act
			IMealPlanFactory mealPlanFactory = new MealPlanFactory();
			MealPlan mealPlanSaved = mealPlanFactory.Create(name, description, goal, dailyCalories,
				dailyProtein, dailyCarbohydrates, dailyFats, nutritionistId, patientId, diagnosticId);

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
			Assert.Equal(diagnosticId, mealPlanSaved.DiagnosticId);
		}

		[Fact]
		public void Create_ShouldThrowArgumentException_WhenBothNutritionistIdAndPatientIdAreEmpty()
		{
			// Arrange
			var factory = new MealPlanFactory();
			string name = "Test Meal Plan";
			string description = "This is a test meal plan.";
			string goal = "Lose weight";
			int dailyCalories = 2000;
			double dailyProtein = 50;
			double dailyCarbohydrates = 200;
			double dailyFats = 70;
			Guid nutritionistId = Guid.Empty; // NutritionistId vacío
			Guid patientId = Guid.Empty; // PatientId vacío
			Guid diagnosticId = Guid.Empty; // PatientId vacío

			// Act & Assert
			var exception = Assert.Throws<ArgumentException>(() => factory.Create(name, description, goal, dailyCalories, dailyProtein, dailyCarbohydrates, dailyFats, nutritionistId, patientId, diagnosticId));
			Assert.Equal("nutritionistId, patientId and diagnosticId are required", exception.Message);
		}
	}
}
