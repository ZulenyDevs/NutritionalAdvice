using NutritionalAdvice.Domain.Ingredients;
using NutritionalAdvice.Infrastructure.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Infrastructure.Repositories
{
	internal class IngredientRepository : IIngredientRepository
	{
		private readonly DomainDbContext _dbContext;

		public IngredientRepository(DomainDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddAsync(Ingredient entity)
		{
			await _dbContext.Ingredient.AddAsync(entity);
		}

		public async Task DeleteAsync(Guid id)
		{
			var obj = await GetByIdAsync(id);
			_dbContext.Ingredient.Remove(obj);
		}

		public async Task<Ingredient> GetByIdAsync(Guid id)
		{
			return await _dbContext.Ingredient.FindAsync(id);
		}

		public Task<Ingredient> GetByIdAsync(Guid id, bool readOnly = false)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(Ingredient ingredient)
		{
			_dbContext.Ingredient.Update(ingredient);

			return Task.CompletedTask;
		}
	}
}
