using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yellow_Foods.Models
{
    [Table("food_nutrients")]
    public class FoodNutrient
    {
        [Column("id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("food_id")]
        [Required]
        public int FoodID { get; set; }

        [Column("nutrient_id")]
        [Required]
        public int NutrientID { get; set; }

        [Column("unit_id")]
        [Required]
        public int UnitID { get; set; }

        [Column("amount", TypeName = "decimal(18, 1)")]
        [Required]
        public decimal Amount { get; set; }

        public Food Food { get; set; }
        public Nutrient Nutrient { get; set; }
        public Unit Unit { get; set; }

    }
}
