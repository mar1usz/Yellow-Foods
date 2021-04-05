using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YellowFoods.Data.Models;
using YellowFoods.Data.Services.Abstractions;

namespace YellowFoods.Data.Services
{
    public class NutrientEntriesDataService : INutrientEntriesDataService
    {
        private readonly YellowFoodsContext _context;

        public NutrientEntriesDataService(YellowFoodsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NutrientEntry>> GetNutrientEntriesAsync(
            int foodId)
        {
            return await _context.NutrientEntries
                .Where(ne => ne.FoodId == foodId)
                .ToListAsync();
        }

        public async Task<NutrientEntry> GetNutrientEntryAsync(
            int foodId,
            int nutrientEntryId)
        {
            return await _context.NutrientEntries
                .Where(ne => ne.FoodId == foodId)
                .FirstOrDefaultAsync(ne => ne.Id == nutrientEntryId);
        }

        public async Task UpdateNutrientEntry(NutrientEntry nutrientEntry)
        {
            _context.Update(nutrientEntry);
            await _context.SaveChangesAsync();
        }

        public async Task AddNutrientEntry(NutrientEntry nutrientEntry)
        {
            _context.Add(nutrientEntry);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveNutrientEntry(NutrientEntry nutrientEntry)
        {
            _context.Remove(nutrientEntry);
            await _context.SaveChangesAsync();
        }
    }
}
