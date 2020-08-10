using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yellow_Foods.Models
{
    [Table("nutrition")]
    public class Nutrition
    {
        [Column("id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("name")]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public ICollection<FoodNutrition> FoodNutritions { get; set; }
    }
}
