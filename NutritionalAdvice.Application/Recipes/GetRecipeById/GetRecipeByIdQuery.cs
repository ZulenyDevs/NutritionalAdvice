using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Application.Recipes.GetRecipeById
{
    public record GetRecipeByIdQuery(Guid Id) : IRequest<RecipeDto>;
}
