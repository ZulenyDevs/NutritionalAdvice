using Microsoft.Extensions.DependencyInjection;
using NutritionalAdvice.Domain.Ingredients;
using NutritionalAdvice.Domain.MealPlans;
using NutritionalAdvice.Domain.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );

            services.AddSingleton<IMealPlanFactory, MealPlanFactory>();
            services.AddSingleton<IRecipeFactory, RecipeFactory>();
            services.AddSingleton<IIngredientFactory, IngredientFactory>();


            return services;
        }

    }
}
