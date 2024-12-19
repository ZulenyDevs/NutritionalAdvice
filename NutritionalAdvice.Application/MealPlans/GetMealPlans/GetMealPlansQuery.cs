using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Application.MealPlans.GetMealPlans
{
    public record GetMealPlansQuery(string SearchTerm) : IRequest<IEnumerable<MealPlanDto>>;
}
