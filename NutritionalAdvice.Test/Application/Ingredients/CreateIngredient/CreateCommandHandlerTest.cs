using Moq;
using NutritionalAdvice.Application.Ingredients.CreateIngredient;
using NutritionalAdvice.Domain.Abstractions;
using NutritionalAdvice.Domain.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalAdvice.Test.Application.Ingredients.CreateIngredient
{
	public class CreateCommandHandlerTest
	{
		private readonly Mock<IIngredientFactory> _ingredientFactory;
		private readonly Mock<IIngredientRepository> _ingredientRepository;
		private readonly Mock<IUnitOfWork> _unitOfWork;

		public CreateCommandHandlerTest()
		{
			_ingredientFactory = new Mock<IIngredientFactory>();
			_ingredientRepository = new Mock<IIngredientRepository>();
			_unitOfWork = new Mock<IUnitOfWork>();
		}

		[Fact]
		public async Task HandleIsValid()
		{
			// arrange
			string name = "Tomate";
			string variety = "Chery";
			string benefits = "Posee propiedades diuréticas, antiinflamatorias, antioxidantes, anticancerígenas, digestivas, entre otras";
			string dishCategory = "ensaladas";
			Ingredient ingredient = new Ingredient(name, variety, benefits, dishCategory);

			_ingredientFactory.Setup(x => x.Create(name, variety, benefits, dishCategory)).Returns(ingredient);

			CreateCommandHandler createCommandHandler = new CreateCommandHandler(_ingredientFactory.Object, _ingredientRepository.Object, _unitOfWork.Object);

			CreateIngredientCommand createIngredientCommand = new CreateIngredientCommand(name, variety, benefits, dishCategory);

			var tcs = new CancellationTokenSource(1000);

			// act
			await createCommandHandler.Handle(createIngredientCommand, tcs.Token);

			// assert
			_ingredientRepository.Verify(x => x.AddAsync(It.IsAny<Ingredient>()), Times.Once);
			_unitOfWork.Verify(x => x.CommitAsync(tcs.Token), Times.Once);

		}
	}
}
