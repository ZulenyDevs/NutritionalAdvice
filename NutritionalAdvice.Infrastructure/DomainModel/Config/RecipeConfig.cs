using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutritionalAdvice.Domain.Recipes;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NutritionalAdvice.Domain.Shared;
using NutritionalAdvice.Domain.Ingredients;
using System.Text.Json;
using System.Diagnostics.CodeAnalysis;

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

            builder.Property(x => x.PreparationTime)
                .HasColumnName("PreparationTime");

            builder.Property(x => x.CookingTime)
                .HasColumnName("CookingTime");

            builder.Property(x => x.Portions)
                .HasColumnName("Portions");

            var instructionsConverter = new ValueConverter<List<string>, string>(
                v => string.Join(";", v), 
                v => v.Split(";", StringSplitOptions.None).ToList()
            );

            builder.Property(x => x.Instructions)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null))
                .HasColumnName("Instructions");
            //builder.HasMany(typeof(RecipeIngredient), "_recipeIngredients");

            builder.Ignore(x => x.RecipeIngredients);
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
            );;

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
