using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Application.MealPlans.GetMealPlans
{
	public class MealPlanDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Goal { get; set; }
		public int DailyCalories { get; set; }
		public double DailyProtein { get; set; }
		public double DailyCarbohydrates { get; set; }
		public double DailyFats { get; set; }
		public Guid NutritionistId { get; set; }
		public Guid PatientId { get; set; }
		public List<MealTimeDto> MealTime { get; set; }

	}
}
