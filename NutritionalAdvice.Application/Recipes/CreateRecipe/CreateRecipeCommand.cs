﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Application.Recipes.CreateRecipe
{
	public record CreateRecipeCommand(string name, string description, int portions) : IRequest<Guid>;
}
