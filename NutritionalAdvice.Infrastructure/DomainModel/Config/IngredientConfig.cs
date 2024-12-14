using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutritionalAdvice.Domain.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Infrastructure.DomainModel.Config
{
    internal class IngredientConfig : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable("ingredient");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.Name)
                .HasColumnName("Name");

            builder.Property(x => x.Variety)
                .HasColumnName("Variety");

            builder.Property(x => x.Benefits)
                .HasColumnName("Benefits");

            builder.Property(x => x.DishCategory)
                .HasColumnName("DishCategory");
        }
    }
}
