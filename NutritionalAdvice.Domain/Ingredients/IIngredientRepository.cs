using NutritionalAdvice.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Domain.Ingredients
{
	public interface IIngredientRepository : IRepository<Ingredient>
	{
		Task UpdateAsync(Ingredient ingredient);
		Task DeleteAsync(Guid id);
	}
}
