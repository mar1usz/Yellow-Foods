﻿using YellowFoods.Resources.Abstractions;

namespace YellowFoods.Resources
{
    public class NutrientEntryResource : Resource
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public int NutrientId { get; set; }
        public int UnitId { get; set; }
        public decimal Amount { get; set; }
    }
}
