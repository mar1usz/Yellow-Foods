using System.ComponentModel.DataAnnotations.Schema;

namespace YellowFoods.Data.Models
{
    public class NutrientEntry
    {
        public int Id { get; set; }
        public int NutrientId { get; set; }
        public int FoodId { get; set; }
        public int UnitId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        public virtual Nutrient Nutrient { get; set; }
        public virtual Food Food { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
