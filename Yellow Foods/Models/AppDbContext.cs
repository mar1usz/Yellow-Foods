using Microsoft.EntityFrameworkCore;

namespace Yellow_Foods.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<Nutrition> Nutritions { get; set; }
        public DbSet<FoodNutrition> FoodNutritions { get; set; }

        public DbSet<Unit> Units { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodNutrition>().HasOne(fn => fn.Food).WithMany(f => f.FoodNutritions).HasForeignKey(fn => fn.FoodID);
            modelBuilder.Entity<FoodNutrition>().HasOne(fn => fn.Nutrition).WithMany(n => n.FoodNutritions).HasForeignKey(fn => fn.NutritionID);
            modelBuilder.Entity<FoodNutrition>().HasOne(fn => fn.Unit).WithMany(u => u.FoodNutritions).HasForeignKey(fn => fn.UnitID);
        }
    }
}
