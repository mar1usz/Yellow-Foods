using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using YellowFoods.Data.Models;
using YellowFoods.Data.Services.Abstractions;

namespace YellowFoods.Data.Services
{
    public class UnitsDataService : IUnitsDataService
    {
        private readonly YellowFoodsContext _context;

        public UnitsDataService(YellowFoodsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Unit>> GetUnitsAsync()
        {
            return await _context.Units.ToListAsync();
        }

        public async Task<Unit> GetUnitAsync(int unitId)
        {
            return await _context.Units.FindAsync(unitId);
        }
    }
}
