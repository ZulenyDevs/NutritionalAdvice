using MediatR;
using NutritionalAdvice.Domain.Abstractions;
using NutritionalAdvice.Domain.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NutritionalAdvice.Application.Ingredients.CreateIngredient
{
	public class CreateCommandHandler : IRequestHandler<CreateIngredientCommand, Guid>
	{
		private readonly IIngredientFactory _ingredientFactory;
		private readonly IIngredientRepository _ingredientRepository;
		private readonly IUnitOfWork _unitOfWork;

		public CreateCommandHandler(IIngredientFactory ingredientFactory,
			IIngredientRepository ingredientRepository,
			IUnitOfWork unitOfWork)
		{
			_ingredientFactory = ingredientFactory;
			_ingredientRepository = ingredientRepository;
			_unitOfWork = unitOfWork;
		}
		public async Task<Guid> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
		{
			var ingredient = _ingredientFactory.Create(request.name, request.variety, request.benefits, request.dishCategory);

			await _ingredientRepository.AddAsync(ingredient);

			await _unitOfWork.CommitAsync(cancellationToken);

			return ingredient.Id;
		}
	}
}
