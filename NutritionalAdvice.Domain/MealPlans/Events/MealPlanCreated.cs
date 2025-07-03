using NutritionalAdvice.Domain.Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Domain.MealPlans.Events
{
	public record MealPlanCreated(Guid Id, string Name, string Description, string Goal, int DailyCalories, double DailyProtein, double DailyCarbohydrates, double DailyFats, Guid NutritionistId, Guid PatientId, Guid DiagnosticId, ICollection<MealTime> MealTimes) : DomainEvent
	{
		public MealPlanCreated() : this(Guid.Empty, string.Empty, string.Empty, string.Empty, 0, 0, 0, 0, Guid.Empty, Guid.Empty, Guid.Empty, [])
		{
		}

	}
}
