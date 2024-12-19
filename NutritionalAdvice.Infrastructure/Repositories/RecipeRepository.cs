using NutritionalAdvice.Domain.Recipes;
using NutritionalAdvice.Infrastructure.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Infrastructure.Repositories
{
    internal class RecipeRepository : IRecipeRepository
    {
        private readonly DomainDbContext _dbContext;

        public RecipeRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Recipe entity)
        {
            await _dbContext.Recipe.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            _dbContext.Recipe.Remove(obj);
        }

        public async Task<Recipe> GetByIdAsync(Guid id)
        {
            return await _dbContext.Recipe.FindAsync(id);
        }

        public Task<Recipe> GetByIdAsync(Guid id, bool readOnly = false)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Recipe recipe)
        {
            _dbContext.Recipe.Update(recipe);

            return Task.CompletedTask;
        }
    }
}
