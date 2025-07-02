using Joseco.Outbox.Contracts.Model;
using Joseco.Outbox.EFCore.Persistence;
using Microsoft.EntityFrameworkCore;
using NutritionalAdvice.Domain.Abstractions;
using NutritionalAdvice.Domain.Ingredients;
using NutritionalAdvice.Domain.MealPlans;
using NutritionalAdvice.Domain.Recipes;
using NutritionalAdvice.Infrastructure.StoredModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Infrastructure.DomainModel
{
	public class DomainDbContext(DbContextOptions<DomainDbContext> options) : DbContext(options)
	{
		public DbSet<Ingredient> Ingredient { get; set; }
		public DbSet<Recipe> Recipe { get; set; }
		public DbSet<RecipeIngredient> RecipeIngredient { get; set; }
		public DbSet<MealPlan> MealPlan { get; set; }
		public DbSet<MealTime> MealTime { get; set; }
		public DbSet<OutboxMessage<DomainEvent>> OutboxMessages { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			modelBuilder.AddOutboxModel<DomainEvent>();
			base.OnModelCreating(modelBuilder);

			modelBuilder.Ignore<DomainEvent>();
		}
	}
}
