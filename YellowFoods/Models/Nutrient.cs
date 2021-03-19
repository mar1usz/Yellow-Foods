using System.Collections.Generic;

namespace YellowFoods.Models
{
    public class Nutrient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<NutrientEntry> NutrientEntries { get; set; }
    }
}
