using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Infrastructure.StoredModel.Entities
{
	[Table("mealtime")]
	public class MealTimeStoredModel
	{
		[Key]
		[Column("Id")]
		public Guid Id { get; set; }

		[Required]
		[Column("Number")]
		public int Number { get; set; }

		[Required]
		[Column("Type")]
		[StringLength(50)]
		public string Type { get; set; }

		[Column("Date", TypeName = "timestamp")]
		public DateTime Date { get; set; }

		[Column("MealPlanId")]
		public Guid MealPlanId { get; set; }
		public MealPlanStoredModel MealPlan { get; set; }


		[Column("RecipeId")]
		public Guid RecipeId { get; set; }
		public RecipeStoredModel Recipe { get; set; }
	}
}
