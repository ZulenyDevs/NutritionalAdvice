using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionalAdvice.Application.MealPlans.GetMealPlans;
using NutritionalAdvice.Infrastructure.StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NutritionalAdvice.Infrastructure.Handlers.MealPlan
{
	public class GetMealPlansHandler : IRequestHandler<GetMealPlansQuery, IEnumerable<MealPlanDto>>
	{
		private readonly StoredDbContext _dbContext;

		public GetMealPlansHandler(StoredDbContext dbContext)
		{
			_dbContext = dbContext;
		}


		public async Task<IEnumerable<MealPlanDto>> Handle(GetMealPlansQuery request, CancellationToken cancellationToken)
		{
			return await _dbContext.MealPlan.AsNoTracking().
			Select(i => new MealPlanDto() {
				Id = i.Id,
				Name = i.Name,
				Description = i.Description,
				Goal = i.Goal,
				DailyCalories = i.DailyCalories,
				DailyProtein = i.DailyProtein,
				DailyCarbohydrates = i.DailyCarbohydrates,
				DailyFats = i.DailyFats,
				NutritionistId = i.NutritionistId,
				PatientId = i.PatientId,
				DiagnosticId = i.DiagnosticId,
				MealTime = i.MealTime.Select(m => new MealTimeDto {
					Id = m.Id,
					Number = m.Number,
					Type = m.Type,
					RecipeId = m.RecipeId
				}).ToList()

			}).
			ToListAsync(cancellationToken);
		}

	}
}
