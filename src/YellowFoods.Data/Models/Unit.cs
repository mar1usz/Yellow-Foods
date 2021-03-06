﻿using System.Collections.Generic;

namespace YellowFoods.Data.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Abbreviation { get; set; }

        public virtual ICollection<NutrientEntry> NutrientEntries { get; set; }
    }
}
