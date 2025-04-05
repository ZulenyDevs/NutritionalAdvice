using MediatR;
using NutritionalAdvice.Domain.Abstractions;
using NutritionalAdvice.Domain.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NutritionalAdvice.Application.Recipes.CreateRecipe
{
	public class CreateCommandHandler : IRequestHandler<CreateRecipeCommand, Guid>
	{
		private readonly IRecipeFactory _recipeFactory;
		private readonly IRecipeRepository _recipeRepository;
		private readonly IUnitOfWork _unitOfWork;

		public CreateCommandHandler(IRecipeFactory recipeFactory,
			IRecipeRepository recipeRepository,
			IUnitOfWork unitOfWork)
		{
			_recipeFactory = recipeFactory;
			_recipeRepository = recipeRepository;
			_unitOfWork = unitOfWork;
		}
		public async Task<Guid> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
		{
			var recipe = _recipeFactory.Create(request.name, request.description, request.preparationTime, request.cookingTime, request.portions, request.instructions);

			await _recipeRepository.AddAsync(recipe);

			await _unitOfWork.CommitAsync(cancellationToken);

			return recipe.Id;
		}
	}
}
