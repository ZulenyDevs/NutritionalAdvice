using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Domain.Shared
{
    public record QuantityValue
    {
        public double Value { get; init; }

        public QuantityValue(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Quantity value cannot be negative", nameof(value));
            }

            Value = value;
        }

        public static implicit operator double(QuantityValue quantity)
        {
            return quantity == null ? 0 : quantity.Value;
        }

        public static implicit operator QuantityValue(double a)
        {
            return new QuantityValue(a);
        }
    }
}
