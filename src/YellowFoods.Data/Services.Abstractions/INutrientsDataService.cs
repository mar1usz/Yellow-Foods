using System.Collections.Generic;
using System.Threading.Tasks;
using YellowFoods.Data.Models;

namespace YellowFoods.Data.Services.Abstractions
{
    public interface INutrientsDataService
    {
        Task<Nutrient> GetNutrientAsync(int nutrientId);
        Task<IEnumerable<Nutrient>> GetNutrientsAsync();
    }
}