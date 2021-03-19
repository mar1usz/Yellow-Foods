using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using YellowFoods.Data;
using YellowFoods.Models;

namespace YellowFoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly YellowFoodsContext _context;

        public UnitsController(YellowFoodsContext context) =>
            _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unit>>> GetUnits()
        {
            return await _context.Units.ToListAsync();
        }

        [HttpGet("{unitId}")]
        public async Task<ActionResult<Unit>> GetUnit(int unitId)
        {
            var unit = await _context.Units.FindAsync(unitId);

            if (unit == null)
            {
                return NotFound();
            }

            return unit;
        }
    }
}
