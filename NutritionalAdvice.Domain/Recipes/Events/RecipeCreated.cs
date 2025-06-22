using NutritionalAdvice.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Domain.Recipes.Events
{
	public record RecipeCreated(Guid RecipeId, string Name, string Description) : DomainEvent
	{
		public RecipeCreated() : this(Guid.Empty, string.Empty, string.Empty)
		{
		}
	}
}
