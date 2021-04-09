using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using YellowFoods.Data.Data;
using YellowFoods.Data.Models;
using YellowFoods.Data.Services.Abstractions;

namespace YellowFoods.Data.Services
{
    public class NutrientsDataService : INutrientsDataService
    {
        private readonly YellowFoodsContext _context;

        public NutrientsDataService(YellowFoodsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Nutrient>> GetNutrientsAsync()
        {
            return await _context.Nutrients.ToListAsync();
        }

        public async Task<Nutrient> GetNutrientAsync(int nutrientId)
        {
            return await _context.Nutrients
                .FirstOrDefaultAsync(n => n.Id == nutrientId);
        }
    }
}
