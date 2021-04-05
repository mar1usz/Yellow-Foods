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
    public class NutrientsController : ControllerBase
    {
        private readonly YellowFoodsContext _context;
        private readonly IConfigurationProvider _configuration;

        public NutrientsController(YellowFoodsContext context,
            IConfigurationProvider configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NutrientDto>>>
            GetNutrients()
        {
            return await _context.Nutrients
                .ProjectTo<NutrientDto>(_configuration)
                .ToListAsync();
        }

        [HttpGet("{nutrientId}")]
        public async Task<ActionResult<NutrientDto>> GetNutrient(
            int nutrientId)
        {
            var nutrientDto = await _context.Nutrients
                .Where(n => n.Id == nutrientId)
                .ProjectTo<NutrientDto>(_configuration)
                .FirstOrDefaultAsync();

            if (nutrientDto == null)
            {
                return NotFound();
            }

            return nutrientDto;
        }
    }
}
