using NutritionalAdvice.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NutritionalAdvice.Test.Domain.Shared
{
	public class QuantityValueTest
	{
		[Fact]
		public void validateOperator()
		{
			// arrange
			double firstValue = 15.99;
			double secongValue = 0.01;

			// act
			QuantityValue quantityFirstValue = firstValue;
			QuantityValue quantitySecondValue = secongValue;
			QuantityValue sumQuantities = quantityFirstValue + quantitySecondValue;
			// assert
			Assert.Equal(firstValue, quantityFirstValue.Value);
			Assert.Equal(secongValue, quantitySecondValue.Value);
			Assert.Equal(firstValue + secongValue, sumQuantities.Value);
		}

		[Fact]
		public void QuantityValueIsNull()
		{
			// arrange
			QuantityValue firstValue = null;
			QuantityValue secondValue = null;

			// act
			QuantityValue sumQuantities = firstValue + secondValue;
			// assert
			Assert.Equal(sumQuantities, 0);

		}

		[Fact]
		public void QuantityValueIsNegative()
		{
			// Arrange
			double negativeValue = -1.0;

			// Act & Assert
			var exception = Assert.Throws<ArgumentException>(() => new QuantityValue(negativeValue));

			// Verificar que el mensaje de la excepción sea el esperado
			Assert.Equal("Quantity value cannot be negative (Parameter 'value')", exception.Message);

		}
	}
}
