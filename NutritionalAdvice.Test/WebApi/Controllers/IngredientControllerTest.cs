using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NutritionalAdvice.Application.Ingredients.CreateIngredient;
using NutritionalAdvice.Application.Ingredients.GetIngredients;
using NutritionalAdvice.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalAdvice.Test.WebApi.Controllers
{
    public class IngredientControllerTest
    {
        [Fact]
        public async Task CreateItem_ReturnsOkResult_WithId()
        {
            // Arrange
            string name = "Tomate";
            string variety = "Chery";
            string benefits = "Posee propiedades diuréticas, antiinflamatorias, antioxidantes, anticancerígenas, digestivas, entre otras";
            string dishCategory = "ensaladas";

            var mediatorMock = new Mock<IMediator>();
            var command = new CreateIngredientCommand(name, variety, benefits, dishCategory);
            var expectedId = Guid.NewGuid();

            mediatorMock
                .Setup(m => m.Send(command, default))
                .ReturnsAsync(expectedId);

            var controller = new IngredientController(mediatorMock.Object);

            // Act
            var result = await controller.CreateItem(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedId, okResult.Value);
        }

        [Fact]
        public async Task CreateItem_ReturnsStatusCode500_WhenExceptionOccurs()
        {
            // Arrange
            string name = "Tomate";
            string variety = "Chery";
            string benefits = "Posee propiedades diuréticas, antiinflamatorias, antioxidantes, anticancerígenas, digestivas, entre otras";
            string dishCategory = "ensaladas";

            var mediatorMock = new Mock<IMediator>();
            var command = new CreateIngredientCommand(name, variety, benefits, dishCategory);
            var exceptionMessage = "An error occurred";

            mediatorMock
                .Setup(m => m.Send(command, default))
                .ThrowsAsync(new Exception(exceptionMessage));

            var controller = new IngredientController(mediatorMock.Object);

            // Act
            var result = await controller.CreateItem(command);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
            Assert.Equal(exceptionMessage, statusCodeResult.Value);
        }

        [Fact]
        public async Task GetItems_ReturnsOkResult_WithIngredients()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var query = new GetIngredientsQuery("");
            var expectedIngredients = new List<IngredientDto> // Asume que IngredientDto es el tipo de retorno
            {
                new IngredientDto { Id = Guid.NewGuid(), Name = "Tomato", Variety = "Chery", Benefits = "Posee propiedades diuréticas, antiinflamatorias, antioxidantes, anticancerígenas, digestivas, entre otras", DishCategory = "ensaladas" },
                new IngredientDto { Id = Guid.NewGuid(), Name = "Zanahoria", Variety = "baby", Benefits = "Rica en beta-caroteno, ayuda a mejorar la visión y fortalece el sistema inmunológico", DishCategory = "ensaladas" }
            };

            mediatorMock
                .Setup(m => m.Send(query, default)) // Configura el mock para devolver una lista
                .ReturnsAsync(expectedIngredients); // Usa ReturnsAsync con el tipo correcto

            var controller = new IngredientController(mediatorMock.Object);

            // Act
            var result = await controller.GetItems();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedIngredients = Assert.IsType<List<IngredientDto>>(okResult.Value);
            Assert.Equal(expectedIngredients.Count, returnedIngredients.Count);
        }

        [Fact]
        public async Task GetItems_ReturnsStatusCode500_WhenExceptionOccurs()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var query = new GetIngredientsQuery("");
            var exceptionMessage = "An error occurred";

            mediatorMock
                .Setup(m => m.Send(query, default))
                .ThrowsAsync(new Exception(exceptionMessage));

            var controller = new IngredientController(mediatorMock.Object);

            // Act
            var result = await controller.GetItems();

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
            Assert.Equal(exceptionMessage, statusCodeResult.Value);
        }
    }
}
