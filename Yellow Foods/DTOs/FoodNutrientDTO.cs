using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Yellow_Foods.DTOs
{
    public class FoodNutrientDTO
    {
        [JsonPropertyName("nutrient_id")]
        public int NutrientID { get; set; }

        [JsonPropertyName("nutrient_name")]
        [MaxLength(50)]
        public string NutrientName { get; set; }

        [JsonPropertyName("value")]
        public decimal Value { get; set; }

        [JsonPropertyName("unit_id")]
        public int UnitID { get; set; }

        [JsonPropertyName("unit_abbrev")]
        [MaxLength(50)]
        public string UnitAbbreviation { get; set; }
    }
}
