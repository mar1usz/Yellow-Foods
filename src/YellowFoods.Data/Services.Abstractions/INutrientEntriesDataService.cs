using System.Collections.Generic;
using System.Threading.Tasks;
using YellowFoods.Data.Models;

namespace YellowFoods.Data.Services.Abstractions
{
    public interface INutrientEntriesDataService
    {
        Task AddNutrientEntry(NutrientEntry nutrientEntry);
        Task<IEnumerable<NutrientEntry>> GetNutrientEntriesAsync(int foodId);
        Task<NutrientEntry> GetNutrientEntryAsync(int foodId, int nutrientEntryId);
        Task RemoveNutrientEntry(NutrientEntry nutrientEntry);
        Task UpdateNutrientEntry(NutrientEntry nutrientEntry);
    }
}