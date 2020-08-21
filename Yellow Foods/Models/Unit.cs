﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yellow_Foods.Models
{
    [Table("units")]
    public class Unit
    {
        [Column("id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("abbrev")]
        [MaxLength(50)]
        [Required]
        public string Abbreviation { get; set; }

        public ICollection<FoodNutrient> FoodNutrients { get; set; }
    }
}
