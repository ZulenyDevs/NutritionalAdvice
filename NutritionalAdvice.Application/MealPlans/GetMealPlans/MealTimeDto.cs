using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Application.MealPlans.GetMealPlans
{
	public class MealTimeDto
	{
		public Guid Id { get; set; }
		public int Number { get; set; }
		public string Type { get; set; }
		public Guid MealPlanId { get; set; }
		public Guid RecipeId { get; set; }
	}
}
