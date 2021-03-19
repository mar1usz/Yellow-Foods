using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YellowFoods.Data;
using YellowFoods.Dtos;

namespace YellowFoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly YellowFoodsContext _context;
        private readonly IConfigurationProvider _configuration;

        public UnitsController(YellowFoodsContext context,
            IConfigurationProvider configuration) =>
                (_context, _configuration) = (context, configuration);

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitDto>>> GetUnits()
        {
            return await _context.Units
                .ProjectTo<UnitDto>(_configuration)
                .ToListAsync();
        }

        [HttpGet("{unitId}")]
        public async Task<ActionResult<UnitDto>> GetUnit(int unitId)
        {
            var unitDto = await _context.Units
                .Where(u => u.Id == unitId)
                .ProjectTo<UnitDto>(_configuration)
                .FirstOrDefaultAsync();

            if (unitDto == null)
            {
                return NotFound();
            }

            return unitDto;
        }
    }
}
