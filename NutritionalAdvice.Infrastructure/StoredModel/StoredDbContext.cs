using NutritionalAdvice.Infrastructure.StoredModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Infrastructure.StoredModel
{
    public class StoredDbContext : DbContext
    {
        public virtual DbSet<IngredientStoredModel> Ingredient { get; set; }
        public virtual DbSet<RecipeStoredModel> Recipe { get; set; }
        public DbSet<RecipeIngredientStoredModel> RecipeIngredient { get; set; }
        public virtual DbSet<MealPlanStoredModel> MealPlan { get; set; }
        public DbSet<MealTimeStoredModel> MealTime { get; set; }

        public StoredDbContext(DbContextOptions<StoredDbContext> options) : base(options)
        {

        }
    }
}
