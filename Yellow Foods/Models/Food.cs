using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yellow_Foods.Models
{
    [Table("food")]
    public class Food
    {
        [Column("id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("name")]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public ICollection<FoodNutrient> FoodNutrients { get; set; }
    }
}
