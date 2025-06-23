using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NutritionalAdvice.Domain.Ingredients;
using NutritionalAdvice.Domain.Recipes;
using NutritionalAdvice.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NutritionalAdvice.Infrastructure.DomainModel.Config
{
	[ExcludeFromCodeCoverage]
	internal class RecipeConfig : IEntityTypeConfiguration<Recipe>, IEntityTypeConfiguration<RecipeIngredient>
	{
		public void Configure(EntityTypeBuilder<Recipe> builder)
		{
			builder.ToTable("recipe");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.HasColumnName("Id");

			builder.Property(x => x.Name)
				.HasColumnName("Name");

			builder.Property(x => x.Description)
				.HasColumnName("Description");

			builder.Property(x => x.Portions)
				.HasColumnName("Portions");

			builder.Ignore(x => x.RecipeIngredients);
			builder.Ignore(x => x.MealTimes);
		}

		public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
		{
			builder.ToTable("recipeingredient");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.HasColumnName("Id");

			var quantityConverter = new ValueConverter<QuantityValue, double>(
				quantityValue => quantityValue.Value,
				quantity => new QuantityValue(quantity)
			); ;

			builder.Property(x => x.Quantity)
				.HasColumnName("Quantity")
				.HasConversion(quantityConverter);

			builder.Property(x => x.UnitOfMeasure)
				.HasColumnName("UnitOfMeasure");

			builder.Property(x => x.RecipeId)
				.HasColumnName("RecipeId");

			builder.Property(x => x.IngredientId)
				.HasColumnName("IngredientId");

			builder.HasOne<Recipe>().
				WithMany().
				HasForeignKey(x => x.RecipeId).
				OnDelete(DeleteBehavior.Cascade);

			builder.HasOne<Ingredient>().
				WithMany().
				HasForeignKey(x => x.IngredientId).
				OnDelete(DeleteBehavior.Cascade);
		}
	}
}
