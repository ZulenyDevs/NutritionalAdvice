using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutritionalAdvice.Domain.MealPlans;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NutritionalAdvice.Domain.Shared;
using NutritionalAdvice.Domain.Recipes;

namespace NutritionalAdvice.Infrastructure.DomainModel.Config
{
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

            builder.HasOne<MealPlan>().
                WithMany().
                HasForeignKey(x => x.MealPlanId).
                OnDelete(DeleteBehavior.Cascade); 
            
            builder.HasOne<Recipe>().
                WithMany().
                HasForeignKey(x => x.RecipeId).
                OnDelete(DeleteBehavior.Cascade);
        }
    }
}
