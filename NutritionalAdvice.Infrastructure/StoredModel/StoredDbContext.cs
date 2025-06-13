using Joseco.Outbox.EFCore.Persistence;
using Microsoft.EntityFrameworkCore;
using NutritionalAdvice.Domain.Abstractions;
using NutritionalAdvice.Infrastructure.Repositories;
using NutritionalAdvice.Infrastructure.StoredModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Infrastructure.StoredModel
{
	public class StoredDbContext : DbContext, IDatabase
	{
		public virtual DbSet<IngredientStoredModel> Ingredient { get; set; }
		public virtual DbSet<RecipeStoredModel> Recipe { get; set; }
		public DbSet<RecipeIngredientStoredModel> RecipeIngredient { get; set; }
		public virtual DbSet<MealPlanStoredModel> MealPlan { get; set; }
		public DbSet<MealTimeStoredModel> MealTime { get; set; }

		public StoredDbContext(DbContextOptions<StoredDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.AddOutboxModel<DomainEvent>();
		}

		public void Migrate()
		{
			Database.Migrate();
		}
	}
}
