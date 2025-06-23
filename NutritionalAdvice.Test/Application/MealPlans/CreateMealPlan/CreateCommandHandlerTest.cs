using Moq;
using NutritionalAdvice.Application.MealPlans.CreateMealPlan;
using NutritionalAdvice.Domain.Abstractions;
using NutritionalAdvice.Domain.MealPlans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalAdvice.Test.Application.MealPlans.CreateMealPlan
{
	public class CreateCommandHandlerTest
	{
		private readonly Mock<IMealPlanFactory> _mealplanFactory;
		private readonly Mock<IMealPlanRepository> _mealplanRepository;
		private readonly Mock<IUnitOfWork> _unitOfWork;

		public CreateCommandHandlerTest()
		{
			_mealplanFactory = new Mock<IMealPlanFactory>();
			_mealplanRepository = new Mock<IMealPlanRepository>();
			_unitOfWork = new Mock<IUnitOfWork>();
		}

		[Fact]
		public async Task HandleIsValid()
		{
			// arrange
			string name = "Plan de Alimentación Balanceado";
			string description = "Un plan diseñado para mantener un equilibrio saludable de nutrientes.";
			string goal = "Mantener peso";
			int dailyCalories = 2000;
			Guid nutritionistId = Guid.NewGuid();
			Guid patientId = Guid.NewGuid();
			Guid diagnosticId = Guid.NewGuid();
			MealPlan mealplan = new MealPlan(name, description, goal, dailyCalories, nutritionistId, patientId, diagnosticId);

			_mealplanFactory.Setup(x => x.Create(name, description, goal, dailyCalories, 10, 10, 10, nutritionistId, patientId, diagnosticId)).Returns(mealplan);

			CreateCommandHandler createCommandHandler = new CreateCommandHandler(_mealplanFactory.Object, _mealplanRepository.Object, _unitOfWork.Object);

			CreateMealPlanCommand createMealPlanCommand = new CreateMealPlanCommand(name, description, goal, dailyCalories, 10, 10, 10, nutritionistId, patientId, diagnosticId);

			var tcs = new CancellationTokenSource(1000);

			// act
			await createCommandHandler.Handle(createMealPlanCommand, tcs.Token);

			// assert
			_mealplanRepository.Verify(x => x.AddAsync(It.IsAny<MealPlan>()), Times.Once);
			_unitOfWork.Verify(x => x.CommitAsync(tcs.Token), Times.Once);

		}
	}
}
