using NutritionalAdvice.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Domain.Recipes
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task UpdateAsync(Recipe recipe);
        Task DeleteAsync(Guid id);
    }
}
