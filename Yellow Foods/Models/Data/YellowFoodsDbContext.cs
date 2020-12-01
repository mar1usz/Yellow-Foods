using Microsoft.EntityFrameworkCore;

namespace Yellow_Foods.Models.Data
{
    public class YellowFoodsDbContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<Nutrient> Nutrients { get; set; }
        public DbSet<FoodNutrient> FoodNutrients { get; set; }
        public DbSet<Unit> Units { get; set; }

        public YellowFoodsDbContext(DbContextOptions<YellowFoodsDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodNutrient>().HasIndex(fn => new { fn.FoodID, fn.NutrientID }).IsUnique();
            modelBuilder.Entity<FoodNutrient>().HasOne(fn => fn.Food).WithMany(f => f.FoodNutrients).HasForeignKey(fn => fn.FoodID);
            modelBuilder.Entity<FoodNutrient>().HasOne(fn => fn.Nutrient).WithMany(n => n.FoodNutrients).HasForeignKey(fn => fn.NutrientID);
            modelBuilder.Entity<FoodNutrient>().HasOne(fn => fn.Unit).WithMany(u => u.FoodNutrients).HasForeignKey(fn => fn.UnitID);
        }
    }
}
