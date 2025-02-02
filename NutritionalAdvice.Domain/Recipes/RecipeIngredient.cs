using NutritionalAdvice.Domain.Abstractions;
using NutritionalAdvice.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Domain.Recipes
{
    public class RecipeIngredient : Entity
    {

        public QuantityValue Quantity { get; private set; }
        public string UnitOfMeasure { get; private set; }
        public Guid RecipeId { get; private set; }
        public Guid IngredientId { get; private set; }

        public RecipeIngredient(string unitOfMeasure, Guid recipeId, Guid ingredientId) : base(Guid.NewGuid())
        {
            Quantity = 0;
            UnitOfMeasure = unitOfMeasure;
            RecipeId = recipeId;
            IngredientId = ingredientId;
        }

        public void Update(double quantity, string unitOfMeasure, Guid ingredientId)
        {
            Quantity = quantity;
            UnitOfMeasure = unitOfMeasure;
            IngredientId = ingredientId;
        }
    }
}
