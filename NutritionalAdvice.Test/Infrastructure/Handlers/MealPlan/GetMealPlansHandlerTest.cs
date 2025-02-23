using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NutritionalAdvice.Application.MealPlans.GetMealPlans;
using NutritionalAdvice.Infrastructure.Handlers.MealPlan;
using NutritionalAdvice.Infrastructure.StoredModel;
using NutritionalAdvice.Infrastructure.StoredModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalAdvice.Test.Infrastructure.Handlers.MealPlan
{
    public class GetMealPlansHandlerTest
    {
        private readonly Mock<StoredDbContext> _dbContext;

        public GetMealPlansHandlerTest()
        {
            var options = new DbContextOptions<StoredDbContext>();
            _dbContext = new Mock<StoredDbContext>(options);
        }

        [Fact]
        public async Task HandleIsValid()
        {

            // Arrange
            var mealPlans = this.getMealPlansTest();

            // Configurar el DbContext simulado con Moq.EntityFrameworkCore
            _dbContext.Setup(x => x.MealPlan).ReturnsDbSet(mealPlans);

            var handler = new GetMealPlansHandler(_dbContext.Object);
            var tcs = new CancellationTokenSource(1000);
            // Act
            var result = await handler.Handle(new GetMealPlansQuery(""), tcs.Token);

            // Assert
            Assert.NotNull(result);
            var resultList = result.ToList();
            Assert.Equal(2, resultList.Count);
            Assert.Equal("Plan de Pérdida de Peso", resultList[0].Name);
            Assert.Equal("Plan de Ganancia Muscular", resultList[1].Name);
        }

        private List<MealPlanStoredModel> getMealPlansTest()
        {
            var mealPlans = new List<MealPlanStoredModel>
            {
                new MealPlanStoredModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Plan de Pérdida de Peso",
                    Description = "Plan diseñado para ayudar a perder peso de manera saludable.",
                    Goal = "Pérdida de peso",
                    DailyCalories = 1500,
                    DailyProtein = 100.0,
                    DailyCarbohydrates = 150.0,
                    DailyFats = 50.0,
                    NutritionistId = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(),
                    MealTime = new List<MealTimeStoredModel>
                    {
                        new MealTimeStoredModel
                        {
                            Id = Guid.NewGuid(),
                            Number = 1,
                            Type = "Desayuno",
                            MealPlanId = Guid.NewGuid(), // Este debe ser el mismo Id del MealPlanStoredModel
                            RecipeId = Guid.NewGuid() // Id de la receta asociada
                        },
                        new MealTimeStoredModel
                        {
                            Id = Guid.NewGuid(),
                            Number = 2,
                            Type = "Almuerzo",
                            MealPlanId = Guid.NewGuid(), // Este debe ser el mismo Id del MealPlanStoredModel
                            RecipeId = Guid.NewGuid() // Id de la receta asociada
                        },
                        new MealTimeStoredModel
                        {
                            Id = Guid.NewGuid(),
                            Number = 3,
                            Type = "Cena",
                            MealPlanId = Guid.NewGuid(), // Este debe ser el mismo Id del MealPlanStoredModel
                            RecipeId = Guid.NewGuid() // Id de la receta asociada
                        }
                    }
                },
                new MealPlanStoredModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Plan de Ganancia Muscular",
                    Description = "Plan diseñado para aumentar la masa muscular.",
                    Goal = "Ganancia muscular",
                    DailyCalories = 2500,
                    DailyProtein = 150.0,
                    DailyCarbohydrates = 250.0,
                    DailyFats = 80.0,
                    NutritionistId = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(),
                    MealTime = new List<MealTimeStoredModel>
                    {
                        new MealTimeStoredModel
                        {
                            Id = Guid.NewGuid(),
                            Number = 1,
                            Type = "Desayuno",
                            MealPlanId = Guid.NewGuid(), // Este debe ser el mismo Id del MealPlanStoredModel
                            RecipeId = Guid.NewGuid() // Id de la receta asociada
                        },
                        new MealTimeStoredModel
                        {
                            Id = Guid.NewGuid(),
                            Number = 2,
                            Type = "Almuerzo",
                            MealPlanId = Guid.NewGuid(), // Este debe ser el mismo Id del MealPlanStoredModel
                            RecipeId = Guid.NewGuid() // Id de la receta asociada
                        },
                        new MealTimeStoredModel
                        {
                            Id = Guid.NewGuid(),
                            Number = 3,
                            Type = "Cena",
                            MealPlanId = Guid.NewGuid(), // Este debe ser el mismo Id del MealPlanStoredModel
                            RecipeId = Guid.NewGuid() // Id de la receta asociada
                        }
                    }
                }
            };
            return mealPlans;
        }

    }
}
