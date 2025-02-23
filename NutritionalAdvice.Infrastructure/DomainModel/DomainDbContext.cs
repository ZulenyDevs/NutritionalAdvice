using NutritionalAdvice.Infrastructure.StoredModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NutritionalAdvice.Domain.Ingredients;
using NutritionalAdvice.Domain.Recipes;
using NutritionalAdvice.Domain.MealPlans;

namespace NutritionalAdvice.Infrastructure.DomainModel
{
    public class DomainDbContext : DbContext
    {
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredient { get; set; }
        public DbSet<MealPlan> MealPlan { get; set; }
        public DbSet<MealTime> MealTime { get; set; }


        public DomainDbContext(DbContextOptions<DomainDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DomainDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
