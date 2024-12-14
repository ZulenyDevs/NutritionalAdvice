using NutritionalAdvice.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Domain.Ingredients
{
    public class Ingredient : AggregateRoot
    {
        public string Name { get; private set; }
        public string Variety { get; private set; }
        public string Benefits { get; private set; }
        public string DishCategory { get; private set; }

        public Ingredient(string name, string variety, string benefits, string dishCategory) : base(Guid.NewGuid())
        {
            Name = name;
            Variety = variety;
            Benefits = benefits;
            DishCategory = dishCategory;
        }
    }
}
