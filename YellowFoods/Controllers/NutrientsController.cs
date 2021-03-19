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
    public class NutrientsController : ControllerBase
    {
        private readonly YellowFoodsContext _context;

        public NutrientsController(YellowFoodsContext context) =>
            _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nutrient>>> GetNutrients()
        {
            return await _context.Nutrients.ToListAsync();
        }

        [HttpGet("{nutrientId}")]
        public async Task<ActionResult<Nutrient>> GetNutrient(int nutrientId)
        {
            var nutrient = await _context.Nutrients.FindAsync(nutrientId);

            if (nutrient == null)
            {
                return NotFound();
            }

            return nutrient;
        }
    }
}
