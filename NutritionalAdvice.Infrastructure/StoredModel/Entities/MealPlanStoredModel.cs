using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Infrastructure.StoredModel.Entities
{
	[Table("mealplan")]
	public class MealPlanStoredModel
	{
		[Key]
		[Column("Id")]
		public Guid Id { get; set; }

		[Required]
		[Column("Name")]
		[StringLength(100)]
		public string Name { get; set; }

		[Column("Description")]
		[StringLength(256)]
		public string Description { get; set; }

		[Column("Goal")]
		[StringLength(256)]
		public string Goal { get; set; }

		[Column("DailyCalories")]
		public int DailyCalories { get; set; }

		[Column("DailyProtein", TypeName = "double precision")]
		public double DailyProtein { get; set; }

		[Column("DailyCarbohydrates", TypeName = "double precision")]
		public double DailyCarbohydrates { get; set; }

		[Column("DailyFats", TypeName = "double precision")]
		public double DailyFats { get; set; }

		[Column("NutritionistId")]
		public Guid NutritionistId { get; set; }

		[Column("PatientId")]
		public Guid PatientId { get; set; }

		[Column("DiagnosticId")]
		public Guid DiagnosticId { get; set; }

		public List<MealTimeStoredModel> MealTime { get; set; }

	}
}
