using System.Collections.Generic;
using System.Threading.Tasks;
using YellowFoods.Data.Models;

namespace YellowFoods.Data.Services.Abstractions
{
    public interface IUnitsDataService
    {
        Task<Unit> GetUnitAsync(int unitId);
        Task<IEnumerable<Unit>> GetUnitsAsync();
    }
}