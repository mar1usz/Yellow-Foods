using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using YellowFoods.Data.Models;
using YellowFoods.Data.Services.Abstractions;

namespace YellowFoods.Data.Services
{
    public class FoodsDataService : IFoodsDataService
    {
        private readonly YellowFoodsContext _context;

        public FoodsDataService(YellowFoodsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Food>> GetFoodsAsync()
        {
            return await _context.Foods.ToListAsync();
        }

        public async Task<Food> GetFoodAsync(int foodId)
        {
            return await _context.Foods.FindAsync(foodId);
        }

        public async Task UpdateFood(Food food)
        {
            _context.Update(food);
            await _context.SaveChangesAsync();
        }

        public async Task AddFood(Food food)
        {
            _context.Add(food);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFood(Food food)
        {
            _context.Remove(food);
            await _context.SaveChangesAsync();
        }
    }
}
