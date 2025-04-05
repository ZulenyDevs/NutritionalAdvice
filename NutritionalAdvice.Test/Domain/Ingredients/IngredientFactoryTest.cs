using NutritionalAdvice.Domain.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalAdvice.Test.Domain.Ingredients
{
	public class IngredientFactoryTest
	{
		[Fact]
		public void IngredientFactoryIsValid()
		{
			// arrange
			string name = "Coca cola";
			string variety = "Personal";
			string benefits = "Cafeina";
			string dishCategory = "Gaseosas";

			// act
			IIngredientFactory ingredientFactory = new IngredientFactory();
			Ingredient ingredientSaved = ingredientFactory.Create(name, variety, benefits, dishCategory);

			//asserts
			Assert.Equal(name, ingredientSaved.Name);
			Assert.Equal(variety, ingredientSaved.Variety);
			Assert.Equal(benefits, ingredientSaved.Benefits);
			Assert.Equal(dishCategory, ingredientSaved.DishCategory);


		}
	}
}