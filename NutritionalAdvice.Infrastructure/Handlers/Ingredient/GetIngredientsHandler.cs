using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionalAdvice.Application.Ingredients.GetIngredients;
using NutritionalAdvice.Infrastructure.StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NutritionalAdvice.Infrastructure.Handlers.Ingredient
{
    public class GetIngredientsHandler : IRequestHandler<GetIngredientsQuery, IEnumerable<IngredientDto>>
    {
        private readonly StoredDbContext _dbContext;

        public GetIngredientsHandler(StoredDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<IngredientDto>> Handle(GetIngredientsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Ingredient.AsNoTracking().
            Select(i => new IngredientDto()
            {
                Id = i.Id,
                Name = i.Name,
                Variety = i.Variety,
                Benefits = i.Benefits,
                DishCategory = i.DishCategory
            }).
            ToListAsync(cancellationToken);
        }
    }
}
