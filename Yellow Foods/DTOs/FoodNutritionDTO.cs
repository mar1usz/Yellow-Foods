using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Yellow_Foods.DTOs
{
    public class FoodNutritionDTO
    {
        [JsonPropertyName("nutrition_id")]
        public int NutritionID { get; set; }

        [JsonPropertyName("nutrition_name")]
        [MaxLength(50)]
        public string NutritionName { get; set; }

        [JsonPropertyName("value")]
        public decimal Value { get; set; }

        [JsonPropertyName("unit_id")]
        public int UnitID { get; set; }

        [JsonPropertyName("unit_abbrev")]
        [MaxLength(50)]
        public string UnitAbbreviation { get; set; }
    }
}
