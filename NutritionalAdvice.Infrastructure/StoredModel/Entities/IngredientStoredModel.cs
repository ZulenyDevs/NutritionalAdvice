using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Infrastructure.StoredModel.Entities
{
	[Table("ingredient")]
	public class IngredientStoredModel
	{
		[Key]
		[Column("Id")]
		public Guid Id { get; set; }

		[Column("Name")]
		[StringLength(250)]
		[Required]
		public string Name { get; set; }

		[Column("Variety")]
		[StringLength(100)]
		public string Variety { get; set; }

		[Column("Benefits")]
		[StringLength(500)]
		public string Benefits { get; set; }

		[Column("DishCategory")]
		[StringLength(100)]
		public string DishCategory { get; set; }

	}
}
