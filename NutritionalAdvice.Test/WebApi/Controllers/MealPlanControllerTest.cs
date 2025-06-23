using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NutritionalAdvice.Application.MealPlans.CreateMealPlan;
using NutritionalAdvice.Application.MealPlans.GetMealPlans;
using NutritionalAdvice.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalAdvice.Test.WebApi.Controllers
{
	public class MealPlanControllerTest
	{
		[Fact]
		public async Task CreateItem_ReturnsOkResult_WithId()
		{
			// Arrange
			string name = "Plan de Alimentación Balanceado";
			string description = "Un plan diseñado para mantener un equilibrio saludable de nutrientes.";
			string goal = "Mantener peso";
			int dailyCalories = 2000;
			Guid nutritionistId = Guid.NewGuid();
			Guid patientId = Guid.NewGuid();
			Guid diagnosticId = Guid.NewGuid();

			var mediatorMock = new Mock<IMediator>();
			var command = new CreateMealPlanCommand(name, description, goal, dailyCalories, 10, 10, 10, nutritionistId, patientId, diagnosticId);
			var expectedId = Guid.NewGuid();

			mediatorMock
				.Setup(m => m.Send(command, default))
				.ReturnsAsync(expectedId);

			var controller = new MealPlanController(mediatorMock.Object);

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
			string name = "Plan de Alimentación Balanceado";
			string description = "Un plan diseñado para mantener un equilibrio saludable de nutrientes.";
			string goal = "Mantener peso";
			int dailyCalories = 2000;
			Guid nutritionistId = Guid.NewGuid();
			Guid patientId = Guid.NewGuid();
			Guid diagnosticId = Guid.NewGuid();

			var mediatorMock = new Mock<IMediator>();
			var command = new CreateMealPlanCommand(name, description, goal, dailyCalories, 10, 10, 10, nutritionistId, patientId, diagnosticId);
			var exceptionMessage = "An error occurred";

			mediatorMock
				.Setup(m => m.Send(command, default))
				.ThrowsAsync(new Exception(exceptionMessage));

			var controller = new MealPlanController(mediatorMock.Object);

			// Act
			var result = await controller.CreateItem(command);

			// Assert
			var statusCodeResult = Assert.IsType<ObjectResult>(result);
			Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
			Assert.Equal(exceptionMessage, statusCodeResult.Value);
		}

		[Fact]
		public async Task GetItems_ReturnsOkResult_WithMealPlans()
		{
			// Arrange
			var mediatorMock = new Mock<IMediator>();
			var query = new GetMealPlansQuery("");
			var expectedMealPlans = this.GetMealPlanDtos();

			mediatorMock
				.Setup(m => m.Send(query, default)) // Configura el mock para devolver una lista
				.ReturnsAsync(expectedMealPlans); // Usa ReturnsAsync con el tipo correcto

			var controller = new MealPlanController(mediatorMock.Object);

			// Act
			var result = await controller.GetItems();

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			var returnedMealPlans = Assert.IsType<List<MealPlanDto>>(okResult.Value);
			Assert.Equal(expectedMealPlans.Count, returnedMealPlans.Count);
		}

		[Fact]
		public async Task GetItems_ReturnsStatusCode500_WhenExceptionOccurs()
		{
			// Arrange
			var mediatorMock = new Mock<IMediator>();
			var query = new GetMealPlansQuery("");
			var exceptionMessage = "An error occurred";

			mediatorMock
				.Setup(m => m.Send(query, default))
				.ThrowsAsync(new Exception(exceptionMessage));

			var controller = new MealPlanController(mediatorMock.Object);

			// Act
			var result = await controller.GetItems();

			// Assert
			var statusCodeResult = Assert.IsType<ObjectResult>(result);
			Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
			Assert.Equal(exceptionMessage, statusCodeResult.Value);
		}

		private List<MealPlanDto> GetMealPlanDtos()
		{
			var expectedMealPlans = new List<MealPlanDto>
			{
				new MealPlanDto
				{
					Id = Guid.NewGuid(),
					Name = "Plan Balanceado",
					Description = "Plan de alimentación equilibrado para mantener un estilo de vida saludable.",
					Goal = "Mantener peso",
					DailyCalories = 2000,
					DailyProtein = 100.5,
					DailyCarbohydrates = 250.0,
					DailyFats = 60.0,
					NutritionistId = Guid.NewGuid(),
					PatientId = Guid.NewGuid(),
					DiagnosticId = Guid.NewGuid(),
					MealTime = new List<MealTimeDto>
					{
						new MealTimeDto
						{
							Id = Guid.NewGuid(),
							Number = 1,
							Type = "Desayuno",
							MealPlanId = Guid.NewGuid(),
							RecipeId = Guid.NewGuid()
						},
						new MealTimeDto
						{
							Id = Guid.NewGuid(),
							Number = 2,
							Type = "Cena",
							MealPlanId = Guid.NewGuid(),
							RecipeId = Guid.NewGuid()
						}
					}
				},
				new MealPlanDto
				{
					Id = Guid.NewGuid(),
					Name = "Plan Alto en Proteínas",
					Description = "Dieta rica en proteínas para el desarrollo muscular.",
					Goal = "Ganar masa muscular",
					DailyCalories = 2500,
					DailyProtein = 150.0,
					DailyCarbohydrates = 200.0,
					DailyFats = 70.0,
					NutritionistId = Guid.NewGuid(),
					PatientId = Guid.NewGuid(),
					DiagnosticId = Guid.NewGuid(),
					MealTime = new List<MealTimeDto>
					{
						new MealTimeDto
						{
							Id = Guid.NewGuid(),
							Number = 1,
							Type = "Almuerzo",
							MealPlanId = Guid.NewGuid(),
							RecipeId = Guid.NewGuid()
						},
						new MealTimeDto
						{
							Id = Guid.NewGuid(),
							Number = 2,
							Type = "Merienda",
							MealPlanId = Guid.NewGuid(),
							RecipeId = Guid.NewGuid()
						}
					}
				}
			};


			return expectedMealPlans;
		}
	}
}
