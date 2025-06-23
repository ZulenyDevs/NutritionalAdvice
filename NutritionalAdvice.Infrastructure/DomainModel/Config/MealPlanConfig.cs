using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Hosting;
using NutritionalAdvice.Domain.MealPlans;
using NutritionalAdvice.Domain.Recipes;
using NutritionalAdvice.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Infrastructure.DomainModel.Config
{
	[ExcludeFromCodeCoverage]
	internal class MealPlanConfig : IEntityTypeConfiguration<MealPlan>, IEntityTypeConfiguration<MealTime>
	{
		public void Configure(EntityTypeBuilder<MealPlan> builder)
		{
			builder.ToTable("mealplan");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.HasColumnName("Id");

			builder.Property(x => x.Name)
				.HasColumnName("Name");

			builder.Property(x => x.Description)
				.HasColumnName("Description");

			builder.Property(x => x.Goal)
				.HasColumnName("Goal");

			builder.Property(x => x.DailyCalories)
				.HasColumnName("DailyCalories");

			var quantityConverter = new ValueConverter<QuantityValue, double>(
				quantityValue => quantityValue.Value,
				quantity => new QuantityValue(quantity)
			);
			builder.Property(x => x.DailyProtein)
				.HasConversion(quantityConverter)
				.HasColumnName("DailyProtein");

			builder.Property(x => x.DailyCarbohydrates)
				.HasConversion(quantityConverter)
				.HasColumnName("DailyCarbohydrates");

			builder.Property(x => x.DailyFats)
				.HasConversion(quantityConverter)
				.HasColumnName("DailyFats");

			builder.Property(x => x.NutritionistId)
				.HasColumnName("NutritionistId");

			builder.Property(x => x.PatientId)
				.HasColumnName("PatientId");

			builder.Property(x => x.DiagnosticId)
				.HasColumnName("DiagnosticId");

			builder.Ignore(x => x.MealTimes);
		}

		public void Configure(EntityTypeBuilder<MealTime> builder)
		{
			builder.ToTable("mealtime");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.HasColumnName("Id");

			builder.Property(x => x.Number)
				.HasColumnName("Number");

			builder.Property(x => x.Type)
				.HasColumnName("Type");

			builder.Property(x => x.MealPlanId)
				.HasColumnName("MealPlanId");

			builder.Property(x => x.RecipeId)
				.HasColumnName("RecipeId");

			builder.HasOne<MealPlan>()
				.WithMany()
				.HasForeignKey(e => e.MealPlanId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne<Recipe>()
				.WithMany()
				.HasForeignKey(e => e.RecipeId)
				.OnDelete(DeleteBehavior.Cascade);

		}
	}
}
