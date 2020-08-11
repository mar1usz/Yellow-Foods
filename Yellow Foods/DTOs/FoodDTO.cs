using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Yellow_Foods.DTOs
{
    public class FoodDTO
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("name")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
