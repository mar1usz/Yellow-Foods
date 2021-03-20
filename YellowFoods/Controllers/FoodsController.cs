using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YellowFoods.Data;
using YellowFoods.Dtos;
using YellowFoods.Models;

namespace YellowFoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly YellowFoodsContext _context;
        private readonly IMapper _mapper;
        private readonly IConfigurationProvider _configuration;

        public FoodsController(
            YellowFoodsContext context,
            IMapper mapper,
            IConfigurationProvider configuration) =>
            (_context, _mapper, _configuration) =
                (context, mapper, configuration);

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodDto>>> GetFoods()
        {
            return await _context.Foods
                .ProjectTo<FoodDto>(_configuration)
                .ToListAsync();
        }

        [HttpGet("{foodId}")]
        public async Task<ActionResult<FoodDto>> GetFood(int foodId)
        {
            var foodDto = await _context.Foods
                .Where(f => f.Id == foodId)
                .ProjectTo<FoodDto>(_configuration)
                .FirstOrDefaultAsync();

            if (foodDto == null)
            {
                return NotFound();
            }

            return foodDto;
        }

        [HttpPut("{foodId}")]
        public async Task<IActionResult> PutFood(int foodId, FoodDto foodDto)
        {
            if (foodId != foodDto.Id)
            {
                return BadRequest();
            }

            var food =_mapper.Map<Food>(foodDto);
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
        public async Task<ActionResult<FoodDto>> PostFood(FoodDto foodDto)
        {
            var food = _mapper.Map<Food>(foodDto);
            _context.Foods.Add(food);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetFood),
                new { foodId = food.Id },
                _mapper.Map<FoodDto>(food));
        }

        [HttpDelete("{foodId}")]
        public async Task<ActionResult<FoodDto>> DeleteFood(int foodId)
        {
            var food = await _context.Foods.FindAsync(foodId);
            if (food == null)
            {
                return NotFound();
            }

            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();

            return _mapper.Map<FoodDto>(food);
        }

        private bool FoodExists(int foodId) =>
            _context.Foods.Any(f => f.Id == foodId);
    }
}
