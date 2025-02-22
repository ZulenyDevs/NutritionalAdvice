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
            Assert.Equal(firstValue+ secongValue, sumQuantities.Value);
        }
    }
}
