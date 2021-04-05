using System.Collections.Generic;
using System.Threading.Tasks;
using YellowFoods.Data.Models;

namespace YellowFoods.Data.Services.Abstractions
{
    public interface IFoodsDataService
    {
        Task AddFood(Food food);
        Task<Food> GetFoodAsync(int foodId);
        Task<IEnumerable<Food>> GetFoodsAsync();
        Task RemoveFood(Food food);
        Task UpdateFood(Food food);
    }
}