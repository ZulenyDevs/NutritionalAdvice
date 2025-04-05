using NutritionalAdvice.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Domain.MealPlans
{
	public interface IMealPlanRepository : IRepository<MealPlan>
	{
		Task UpdateAsync(MealPlan mealPlan);
		Task DeleteAsync(Guid id);
	}
}
