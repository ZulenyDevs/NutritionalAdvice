using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NutritionalAdvice.Application.Ingredients.GetIngredients;
using NutritionalAdvice.Infrastructure.Handlers.Ingredient;
using NutritionalAdvice.Infrastructure.StoredModel;
using NutritionalAdvice.Infrastructure.StoredModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalAdvice.Test.Infrastructure.Handlers.Ingredient
{
    public class GetIngredientsHandlerTest
    {
        private readonly Mock<StoredDbContext> _dbContext;

        public GetIngredientsHandlerTest()
        {
            var options = new DbContextOptions<StoredDbContext>();
            _dbContext = new Mock<StoredDbContext>(options);
        }

        [Fact]
        public async Task HandleIsValid()
        {

            // Arrange
            var ingredients = new List<IngredientStoredModel>
            {
                new IngredientStoredModel { Id = Guid.NewGuid(), Name = "Tomato", Variety = "Cherry", Benefits = "Rich in vitamins", DishCategory = "Salad" },
                new IngredientStoredModel { Id = Guid.NewGuid(), Name = "Carrot", Variety = "Orange", Benefits = "Good for vision", DishCategory = "Soup" }
            };

            // Configurar el DbContext simulado con Moq.EntityFrameworkCore
            _dbContext.Setup(x => x.Ingredient).ReturnsDbSet(ingredients);

            var handler = new GetIngredientsHandler(_dbContext.Object);
            var tcs = new CancellationTokenSource(1000);
            // Act
            var result = await handler.Handle(new GetIngredientsQuery(""), tcs.Token);

            // Assert
            Assert.NotNull(result);
            var resultList = result.ToList();
            Assert.Equal(2, resultList.Count);
            Assert.Equal("Tomato", resultList[0].Name);
            Assert.Equal("Carrot", resultList[1].Name);
        }

    }
    

}
