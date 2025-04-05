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
			Assert.Equal(description, mealPlan.Description);
			Assert.Equal(goal, mealPlan.Goal);
			Assert.Equal(dailyCalories, mealPlan.DailyCalories);
			Assert.Equal(nutritionistId, mealPlan.NutritionistId);
			Assert.Equal(patientId, mealPlan.PatientId);
		}

		[Fact]
		public void AddMealTime_ShouldAddMealTimeToMealPlan()
		{
			// Arrange
			var mealPlan = new MealPlan("Test Meal Plan", "This is a test meal plan.", "Lose weight", 2000, Guid.NewGuid(), Guid.NewGuid());
			int number = 1;
			string type = "Breakfast";
			Guid mealPlanId = mealPlan.Id;
			Guid recipeId = Guid.NewGuid();

			// Act
			mealPlan.AddMealTime(number, type, mealPlanId, recipeId);

			// Assert
			var mealTimes = GetMealTimesFromMealPlan(mealPlan);
			var addedMealTime = mealTimes.FirstOrDefault(mt => mt.MealPlanId == mealPlanId && mt.RecipeId == recipeId);
			Assert.NotNull(addedMealTime);
			Assert.Equal(number, addedMealTime.Number);
			Assert.Equal(type, addedMealTime.Type);
		}

		[Fact]
		public void UpdateMealTime_ShouldUpdateExistingMealTime()
		{
			// Arrange
			var mealPlan = new MealPlan("Test Meal Plan", "This is a test meal plan.", "Lose weight", 2000, Guid.NewGuid(), Guid.NewGuid());
			int initialNumber = 1;
			string initialType = "Breakfast";
			Guid mealPlanId = mealPlan.Id;
			Guid recipeId = Guid.NewGuid();
			mealPlan.AddMealTime(initialNumber, initialType, mealPlanId, recipeId);

			var mealTimes = GetMealTimesFromMealPlan(mealPlan);
			var mealTime = mealTimes.First();

			int updatedNumber = 2;
			string updatedType = "Lunch";
			Guid updatedRecipeId = Guid.NewGuid();

			// Act
			mealPlan.updateMealTime(mealTime.Id, updatedNumber, updatedType, updatedRecipeId);

			// Assert
			Assert.Equal(updatedNumber, mealTime.Number);
			Assert.Equal(updatedType, mealTime.Type);
			Assert.Equal(updatedRecipeId, mealTime.RecipeId);
		}

		[Fact]
		public void UpdateMealTime_ShouldThrowException_WhenMealTimeNotFound()
		{
			// Arrange
			var mealPlan = new MealPlan("Test Meal Plan", "This is a test meal plan.", "Lose weight", 2000, Guid.NewGuid(), Guid.NewGuid());
			var nonExistentId = Guid.NewGuid();

			// Act & Assert
			Assert.Throws<InvalidOperationException>(() => mealPlan.updateMealTime(nonExistentId, 1, "Breakfast", Guid.NewGuid()));
		}

		[Fact]
		public void RemoveMealTime_ShouldRemoveMealTimeFromMealPlan()
		{
			// Arrange
			var mealPlan = new MealPlan("Test Meal Plan", "This is a test meal plan.", "Lose weight", 2000, Guid.NewGuid(), Guid.NewGuid());
			int number = 1;
			string type = "Breakfast";
			Guid mealPlanId = mealPlan.Id;
			Guid recipeId = Guid.NewGuid();
			mealPlan.AddMealTime(number, type, mealPlanId, recipeId);

			var mealTimes = GetMealTimesFromMealPlan(mealPlan);
			var mealTime = mealTimes.First();

			// Act
			mealPlan.RemoveMealTime(mealTime.Id);

			// Assert
			Assert.DoesNotContain(mealTime, mealTimes);
		}

		[Fact]
		public void RemoveMealTime_ShouldThrowException_WhenMealTimeNotFound()
		{
			// Arrange
			var mealPlan = new MealPlan("Test Meal Plan", "This is a test meal plan.", "Lose weight", 2000, Guid.NewGuid(), Guid.NewGuid());
			var nonExistentId = Guid.NewGuid();

			// Act & Assert
			Assert.Throws<InvalidOperationException>(() => mealPlan.RemoveMealTime(nonExistentId));
		}

		// Método auxiliar para acceder a la lista interna _mealTimes (usando reflexión para fines de prueba)
		private List<MealTime> GetMealTimesFromMealPlan(MealPlan mealPlan)
		{
			var fieldInfo = typeof(MealPlan).GetField("_mealTimes", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
			return (List<MealTime>)fieldInfo.GetValue(mealPlan);
		}

	}
}
