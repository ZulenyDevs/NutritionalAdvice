using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NutritionalAdvice.Application.Recipes.CreateRecipe;
using NutritionalAdvice.Application.Recipes.GetRecipeById;
using NutritionalAdvice.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalAdvice.Test.WebApi.Controllers
{
    public class RecipeControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        public RecipeControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
        }
        [Fact]
        public async Task CreateItem_ReturnsOkResult_WithId()
        {
            // Arrange
            string name = "Espaguetis a la Carbonara";
            string description = "Un plato clásico italiano hecho con huevos, queso, panceta y pimienta.";
            int preparationTime = 15;
            int cookingTime = 20;
            int portions = 4;
            List<string> instructions = new()
            {
                "1. Hervir los espaguetis.",
                "2. Cocinar la panceta hasta que esté crujiente.",
                "3. Mezclar los huevos y el queso en un bol.",
                "4. Combinar los espaguetis con la panceta y la mezcla de huevo.",
                "5. Servir con una pizca de pimienta."
            };

            var mediatorMock = new Mock<IMediator>();
            var command = new CreateRecipeCommand(name, description, preparationTime, cookingTime, portions, instructions);
            var expectedId = Guid.NewGuid();

            _mediatorMock
                .Setup(m => m.Send(command, default))
                .ReturnsAsync(expectedId);

            var controller = new RecipeController(_mediatorMock.Object);

            // Act
            var result = await controller.CreateRecipe(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedId, okResult.Value);
        }

        [Fact]
        public async Task CreateItem_ReturnsStatusCode500_WhenExceptionOccurs()
        {
            // Arrange
            string name = "Espaguetis a la Carbonara";
            string description = "Un plato clásico italiano hecho con huevos, queso, panceta y pimienta.";
            int preparationTime = 15;
            int cookingTime = 20;
            int portions = 4;
            List<string> instructions = new()
            {
                "1. Hervir los espaguetis.",
                "2. Cocinar la panceta hasta que esté crujiente.",
                "3. Mezclar los huevos y el queso en un bol.",
                "4. Combinar los espaguetis con la panceta y la mezcla de huevo.",
                "5. Servir con una pizca de pimienta."
            };

            var _mediatorMock = new Mock<IMediator>();
            var command = new CreateRecipeCommand(name, description, preparationTime, cookingTime, portions, instructions);
            var exceptionMessage = "An error occurred";

            _mediatorMock
                .Setup(m => m.Send(command, default))
                .ThrowsAsync(new Exception(exceptionMessage));

            var controller = new RecipeController(_mediatorMock.Object);

            // Act
            var result = await controller.CreateRecipe(command);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
            Assert.Equal(exceptionMessage, statusCodeResult.Value);
        }

        [Fact]
        public async Task GetRecipeById_ShouldReturnOk_WhenRecipeExists()
        {
            // Arrange
            var recipeId = Guid.NewGuid();
            var query = new GetRecipeByIdQuery(recipeId);
            RecipeDto expectedRecipe = new()
            {
                Id = recipeId,
                Name = "Spaghetti Bolognese",
                Description = "Classic Italian pasta dish",
                PreparationTime = 15,
                CookingTime = 30,
                Portions = 4,
                Instructions = new List<string>{
                    "Boil pasta", "cook sauce", "mix together"
                },
                RecipeIngredients = new List<RecipeIngredientDto>
                {
                    new RecipeIngredientDto { Id = Guid.NewGuid(), Quantity = 200, UnitOfMeasure = "g", RecipeId = Guid.NewGuid(), IngredientId = Guid.NewGuid() },
                    new RecipeIngredientDto { Id = Guid.NewGuid(), Quantity = 100, UnitOfMeasure = "ml", RecipeId = Guid.NewGuid(), IngredientId = Guid.NewGuid() }
                }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetRecipeByIdQuery>(), default))
                         .ReturnsAsync(expectedRecipe);

            var controller = new RecipeController(_mediatorMock.Object);
            // Act
            var result = await controller.GetRecipeById(query);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(expectedRecipe, okResult.Value);
        }

        [Fact]
        public async Task GetRecipeById_ShouldReturn500_WhenExceptionOccurs()
        {
            // Arrange
            var query = new GetRecipeByIdQuery(Guid.NewGuid());
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetRecipeByIdQuery>(), default))
                         .ThrowsAsync(new Exception("Database connection failed"));

            var controller = new RecipeController(_mediatorMock.Object);
            // Act
            var result = await controller.GetRecipeById(query);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
            Assert.Equal("Database connection failed", objectResult.Value);
        }
    }
}
