using Joseco.Communication.External.Contracts.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Integration.MealPlan
{
	public record MealPlanCreated : IntegrationMessage
	{
		public Guid MealPlanId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; } = string.Empty;
		public string Goal { get; set; } = string.Empty;
		public int DailyCalories { get; set; } = 0;
		public double DailyProtein { get; set; } = 0;
		public double DailyCarbohydrates { get; set; } = 0;
		public double DailyFats { get; set; } = 0;
		public Guid NutritionistId { get; set; }
		public Guid PatientId { get; set; }
		public Guid DiagnosticId { get; set; }
		public ICollection<MealTime> MealTimes { get; set; }

		public MealPlanCreated(Guid id, string name, string description, string goal, int dailyCalories, double dailyProtein, double dailyCarbohydrates, double dailyFats, Guid nutritionistId, Guid patientId, Guid diagnosticId, ICollection<MealTime> mealTimes, string? correlationId = null, string? source = null)
			: base(correlationId, source)
		{
			MealPlanId = id;
			Name = name;
			Description = description;
			Goal = goal;
			DailyCalories = dailyCalories;
			DailyProtein = dailyProtein;
			DailyCarbohydrates = dailyCarbohydrates;
			DailyFats = dailyFats;
			NutritionistId = nutritionistId;
			PatientId = patientId;
			DiagnosticId = diagnosticId;
			MealTimes = mealTimes;
		}
	}

	public record MealTime
	{
		public int Number { get; set; }
		public string Type { get; set; } = string.Empty;
		public DateTimeOffset Date { get; set; }
		public Guid MealPlanId { get; set; }
		public Guid RecipeId { get; set; }
	}
}
