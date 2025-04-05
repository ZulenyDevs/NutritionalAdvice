using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Application.Ingredients.CreateIngredient
{
	public record CreateIngredientCommand(string name, string variety, string benefits, string dishCategory) : IRequest<Guid>;
}
