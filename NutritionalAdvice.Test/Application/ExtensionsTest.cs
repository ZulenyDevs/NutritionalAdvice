using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NutritionalAdvice.Application;
using NutritionalAdvice.Domain.Ingredients;
using NutritionalAdvice.Domain.MealPlans;
using NutritionalAdvice.Domain.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalAdvice.Test.Application
{
    public class ExtensionsTest
    {
        [Fact]
        public void AddApplication_ShouldRegisterRequiredServices()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act
            services.AddAplication(); // Llamamos al método que estamos probando
            var serviceProvider = services.BuildServiceProvider();

            // Assert
            // Verificar que MediatR fue registrado
            var mediator = serviceProvider.GetService<IMediator>();
            Assert.NotNull(mediator);

            // Verificar que las fábricas fueron registradas como Singleton
            Assert.True(IsRegisteredAsSingleton<IMealPlanFactory, MealPlanFactory>(services));
            Assert.True(IsRegisteredAsSingleton<IRecipeFactory, RecipeFactory>(services));
            Assert.True(IsRegisteredAsSingleton<IIngredientFactory, IngredientFactory>(services));
        }

        // Método auxiliar para verificar si un servicio está registrado como Singleton
        private bool IsRegisteredAsSingleton<TInterface, TImplementation>(IServiceCollection services)
        {
            var descriptor = services.FirstOrDefault(d => d.ServiceType == typeof(TInterface));
            return descriptor != null &&
                   descriptor.Lifetime == ServiceLifetime.Singleton &&
                   descriptor.ImplementationType == typeof(TImplementation);
        }
    }
}
