using Microsoft.EntityFrameworkCore;
using YellowFoods.Data.Models;

namespace YellowFoods.Data
{
    public class YellowFoodsContext : DbContext
    {
        public YellowFoodsContext(DbContextOptions<YellowFoodsContext> options)
            : base(options)
        {
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Nutrient> Nutrients { get; set; }
        public DbSet<NutrientEntry> NutrientEntries { get; set; }
        public DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NutrientEntry>()
                .HasIndex(ne => new { ne.NutrientId, ne.FoodId })
                .IsUnique();
        }
    }
}
