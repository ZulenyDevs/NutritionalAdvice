using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionalAdvice.Application.Recipes.GetRecipeById;
using NutritionalAdvice.Infrastructure.StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NutritionalAdvice.Infrastructure.Handlers.Recipe
{
    public class GetRecipeByIdHandler : IRequestHandler<GetRecipeByIdQuery, RecipeDto>
    {
        private readonly StoredDbContext _dbContext;

        public GetRecipeByIdHandler(StoredDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RecipeDto> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
        {
            var recipe = await _dbContext.Recipe
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

            if (recipe == null)
            {
                return new RecipeDto
                {
                    Name = "Recipe Not Found"
                };
            }

            var recipeDto = new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description,
                PreparationTime = recipe.PreparationTime,
                CookingTime = recipe.CookingTime,
                Portions = recipe.Portions,
                //Instructions = recipe.Instructions,
                RecipeIngredients = recipe.RecipeIngredients.Select(i => new RecipeIngredientDto
                {
                    Id = i.Id,
                    Quantity = i.Quantity,
                    UnitOfMeasure = i.UnitOfMeasure,
                    IngredientId = i.IngredientId
                }).ToList(),
                
            };

            return recipeDto;
        }
    }
}
