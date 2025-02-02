using NutritionalAdvice.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Domain.Recipes
{
    public class Recipe : AggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int PreparationTime { get; private set; }
        public int CookingTime { get; private set; }
        public int Portions { get; private set; }
        public List<string> Instructions { get; private set; } = new List<string>();
        
        private List<RecipeIngredient> _recipeIngredients;
        public ICollection<RecipeIngredient> RecipeIngredients
        {
            get
            {
                return _recipeIngredients;
            }
        }

        public Recipe(string name, string description, int preparationTime, int cookingTime, int portions, List<string> instructions) : base(Guid.NewGuid())
        {
            Name = name;
            Description = description;
            PreparationTime = preparationTime;
            CookingTime = cookingTime;
            Portions = portions;
            Instructions = instructions;
            _recipeIngredients = new List<RecipeIngredient>();
        }

        public void AddRecipeIngredient(double quantity, string unitOfMeasure, Guid recipeId, Guid ingredientId)
        {
            RecipeIngredient recipeIngredient = new RecipeIngredient(unitOfMeasure, recipeId, ingredientId);
            _recipeIngredients.Add(recipeIngredient);
        }

        public void UpdateRecipeIngredient(Guid id, double quantity, string unitOfMeasure, Guid ingredientId)
        {
            RecipeIngredient recipeIngredient = _recipeIngredients.FirstOrDefault(i => i.Id == id);
            if (recipeIngredient == null)
            {
                throw new InvalidOperationException("RecipeIngredient not found in Recipe");
            }

            recipeIngredient.Update(quantity, unitOfMeasure, ingredientId);
        }

        public void RemoveRecipeIngredient(Guid id)
        {
            RecipeIngredient recipeIngredient = _recipeIngredients.FirstOrDefault(i => i.Id == id);
            if (recipeIngredient == null)
            {
                throw new InvalidOperationException("RecipeIngredient not found in Recipe");
            }
            _recipeIngredients.Remove(recipeIngredient);
        }
    }
}
