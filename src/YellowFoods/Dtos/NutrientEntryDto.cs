namespace YellowFoods.Dtos
{
    public class NutrientEntryDto
    {
        public int Id { get; set; }
        public int NutrientId { get; set; }
        public int FoodId { get; set; }
        public int UnitId { get; set; }
        public decimal Amount { get; set; }
    }
}
