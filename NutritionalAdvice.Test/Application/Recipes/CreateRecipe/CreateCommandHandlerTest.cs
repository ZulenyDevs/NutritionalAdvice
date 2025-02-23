using Moq;
using NutritionalAdvice.Application.Recipes.CreateRecipe;
using NutritionalAdvice.Domain.Abstractions;
using NutritionalAdvice.Domain.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalAdvice.Test.Application.Recipes.CreateRecipe
{
    public class CreateCommandHandlerTest
    {
        private readonly Mock<IRecipeFactory> _recipeFactory;
        private readonly Mock<IRecipeRepository> _recipeRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public CreateCommandHandlerTest()
        {
            _recipeFactory = new Mock<IRecipeFactory>();
            _recipeRepository = new Mock<IRecipeRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task HandleIsValid()
        {
            // arrange
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

            Recipe recipe = new Recipe(name, description, preparationTime, cookingTime, portions, instructions);

            _recipeFactory.Setup(x => x.Create(name, description, preparationTime, cookingTime, portions, instructions)).Returns(recipe);

            CreateCommandHandler createCommandHandler = new CreateCommandHandler(_recipeFactory.Object, _recipeRepository.Object, _unitOfWork.Object);

            CreateRecipeCommand createRecipeCommand = new CreateRecipeCommand(name, description, preparationTime, cookingTime, portions, instructions);

            var tcs = new CancellationTokenSource(1000);

            // act
            await createCommandHandler.Handle(createRecipeCommand, tcs.Token);

            // assert
            _recipeRepository.Verify(x => x.AddAsync(It.IsAny<Recipe>()), Times.Once);
            _unitOfWork.Verify(x => x.CommitAsync(tcs.Token), Times.Once);

        }
    }
}
