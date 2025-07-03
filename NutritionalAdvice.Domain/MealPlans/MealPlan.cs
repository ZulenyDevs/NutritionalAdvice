using NutritionalAdvice.Domain.Abstractions;
using NutritionalAdvice.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Domain.MealPlans
{
	public class MealPlan : AggregateRoot
	{
		public string Name { get; private set; }
		public string Description { get; private set; }
		public string Goal { get; private set; }
		public int DailyCalories { get; private set; }
		public QuantityValue DailyProtein { get; private set; }
		public QuantityValue DailyCarbohydrates { get; private set; }
		public QuantityValue DailyFats { get; private set; }
		public Guid NutritionistId { get; private set; }
		public Guid PatientId { get; private set; }
		public Guid DiagnosticId { get; set; }
		private List<MealTime> _mealTimes;
		public ICollection<MealTime> MealTimes
		{
			get
			{
				return _mealTimes;
			}
		}

		public MealPlan(string name, string description, string goal, int dailyCalories, Guid nutritionistId, Guid patientId, Guid diagnosticId) : base(Guid.NewGuid())
		{
			Name = name;
			Description = description;
			Goal = goal;
			DailyCalories = dailyCalories;
			DailyProtein = 0;
			DailyCarbohydrates = 0;
			DailyFats = 0;
			NutritionistId = nutritionistId;
			PatientId = patientId;
			DiagnosticId = diagnosticId;
			_mealTimes = new List<MealTime>();
		}


		public void AddMealTime(int number, string type, DateTimeOffset date, Guid recipeId)
		{
			MealTime mealTime = new MealTime(number, type, date, Id, recipeId);
			_mealTimes.Add(mealTime);
		}

		public void updateMealTime(Guid id, int number, string type, DateTime date, Guid recipeId)
		{
			MealTime mealTime = _mealTimes.FirstOrDefault(i => i.Id == id);
			if (mealTime == null)
			{
				throw new InvalidOperationException("MealTime not found in MealPlan");
			}

			mealTime.Update(number, type, date, recipeId);
		}

		public void RemoveMealTime(Guid id)
		{
			MealTime mealTime = _mealTimes.FirstOrDefault(i => i.Id == id);
			if (mealTime == null)
			{
				throw new InvalidOperationException("MealTime not found in MealPlan");
			}
			_mealTimes.Remove(mealTime);
		}
	}
}
