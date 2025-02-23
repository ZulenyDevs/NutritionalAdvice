using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalAdvice.Infrastructure.StoredModel.Entities
{
    [Table("recipe")]
    public class RecipeStoredModel
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Required]
        [Column("Name")]
        [StringLength(250)]
        public string Name { get; set; }

        [Column("Description")]
        [StringLength(256)]
        public string Description { get; set; }

        [Column("PreparationTime")]
        public int PreparationTime { get; set; }

        [Column("CookingTime")]
        public int CookingTime { get; set; }

        [Column("Portions")]
        public int Portions { get; set; }

        [Column("Instructions")]
        public string Instructions { get; set; }

        public List<RecipeIngredientStoredModel> RecipeIngredients { get; set; }

    }
}
