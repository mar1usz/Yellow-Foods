using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YellowFoods.Data;
using YellowFoods.Models;

namespace YellowFoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly YellowFoodsContext _context;

        public FoodsController(YellowFoodsContext context) =>
            _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Food>>> GetFoods()
        {
            return await _context.Foods.ToListAsync();
        }

        [HttpGet("{foodId}")]
        public async Task<ActionResult<Food>> GetFood(int foodId)
        {
            var food = await _context.Foods.FindAsync(foodId);

            if (food == null)
            {
                return NotFound();
            }

            return food;
        }

        [HttpPut("{foodId}")]
        public async Task<IActionResult> PutFood(int foodId, Food food)
        {
            if (foodId != food.Id)
            {
                return BadRequest();
            }

            _context.Entry(food).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(foodId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Food>> PostFood(Food food)
        {
            _context.Foods.Add(food);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetFood),
                new { foodId = food.Id },
                food);
        }

        [HttpDelete("{foodId}")]
        public async Task<ActionResult<Food>> DeleteFood(int foodId)
        {
            var food = await _context.Foods.FindAsync(foodId);
            if (food == null)
            {
                return NotFound();
            }

            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();

            return food;
        }

        private bool FoodExists(int foodId) =>
            _context.Foods.Any(f => f.Id == foodId);
    }
}
