using NutritionalAdvice.Domain.MealPlans;
using NutritionalAdvice.Infrastructure.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Infrastructure.Repositories
{
    internal class MealPlanRepository : IMealPlanRepository
    {
        private readonly DomainDbContext _dbContext;

        public MealPlanRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(MealPlan entity)
        {
            await _dbContext.MealPlan.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            _dbContext.MealPlan.Remove(obj);
        }

        public async Task<MealPlan> GetByIdAsync(Guid id)
        {
            return await _dbContext.MealPlan.FindAsync(id);
        }

        public Task<MealPlan> GetByIdAsync(Guid id, bool readOnly = false)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(MealPlan mealplan)
        {
            _dbContext.MealPlan.Update(mealplan);

            return Task.CompletedTask;
        }
    }
}
