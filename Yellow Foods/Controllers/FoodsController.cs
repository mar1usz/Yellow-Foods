using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yellow_Foods.DTOs;
using Yellow_Foods.Models;
using Yellow_Foods.Models.Data;

namespace Yellow_Foods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public FoodsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/foods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodDTO>>> GetFoods()
        {
            var foods = await _context.Foods.ToListAsync();

            return _mapper.Map<List<FoodDTO>>(foods);
        }

        // GET: api/foods/1
        [HttpGet("{foodID}")]
        public async Task<ActionResult<FoodDTO>> GetFood(int foodID)
        {
            var food = await _context.Foods.FindAsync(foodID);

            if (food == null)
            {
                return NotFound();
            }

            return _mapper.Map<FoodDTO>(food);
        }

        // GET: api/foods/1/nutritions
        [HttpGet("{foodID}/nutritions")]
        public async Task<ActionResult<IEnumerable<FoodNutritionDTO>>> GetFoodNutritions(int foodID)
        {
            var foodNutrition = await GetFoodNutritionsForDTO(foodID, null).ToListAsync();

            return _mapper.Map<List<FoodNutritionDTO>>(foodNutrition);
        }

        // GET: api/foods/1/nutritions/2
        [HttpGet("{foodID}/nutritions/{nutritionID}")]
        public async Task<ActionResult<FoodNutritionDTO>> GetFoodNutrition(int foodID, int nutritionID)
        {
            var foodNutrition = await GetFoodNutritionsForDTO(foodID, nutritionID).SingleOrDefaultAsync();

            if (foodNutrition == null)
            {
                return NotFound();
            }

            return _mapper.Map<FoodNutritionDTO>(foodNutrition);
        }

        // PUT: api/foods/1
        [HttpPut("{foodID}")]
        public async Task<IActionResult> PutFood(int foodID, FoodDTO foodDTO)
        {
            if (foodID != foodDTO.ID)
            {
                return BadRequest();
            }

            var food = _mapper.Map<Food>(foodDTO);
            _context.Entry(food).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(foodID))
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

        // PUT: api/foods/1/nutritions/2
        [HttpPut("{foodID}/nutritions/{nutritionID}")]
        public async Task<IActionResult> PutFoodNutrition(int foodID, int nutritionID, FoodNutritionDTO foodNutritionDTO)
        {
            if (foodNutritionDTO.NutritionID != nutritionID)
            {
                return BadRequest();
            }

            var foodNutritionOG = await GetFoodNutritionsForDTO(foodID, nutritionID)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            var foodNutrition = _mapper.Map<FoodNutrition>(foodNutritionDTO);
            foodNutrition.ID = foodNutritionOG.ID;
            foodNutrition.FoodID = foodID;
            _context.Entry(foodNutrition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodNutritionExists(foodID, nutritionID))
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

        // POST: api/foods
        [HttpPost]
        public async Task<ActionResult<FoodDTO>> PostFood(FoodDTO foodDTO)
        {
            var food = _mapper.Map<Food>(foodDTO);
            _context.Foods.Add(food);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFood), new { foodID = food.ID }, _mapper.Map<FoodDTO>(food));
        }

        // POST: api/foods/1/nutritions
        [HttpPost("{foodID}/nutritions")]
        public async Task<ActionResult<FoodNutritionDTO>> PostFoodNutrition(int foodID, FoodNutritionDTO foodNutritionDTO)
        {
            var foodNutrition = _mapper.Map<FoodNutrition>(foodNutritionDTO);
            foodNutrition.FoodID = foodID;
            _context.FoodNutritions.Add(foodNutrition);

            await _context.SaveChangesAsync();

            int _foodID = foodNutrition.FoodID;
            int _nutritionID = foodNutrition.NutritionID;
            var _foodNutrition = await GetFoodNutritionsForDTO(_foodID, _nutritionID).SingleOrDefaultAsync();

            return CreatedAtAction(nameof(GetFoodNutrition), new { foodID = _foodID, nutritionID = _nutritionID }, _mapper.Map<FoodNutritionDTO>(_foodNutrition));
        }

        // DELETE: api/foods/1
        [HttpDelete("{foodID}")]
        public async Task<ActionResult<FoodDTO>> DeleteFood(int foodID)
        {
            var food = await _context.Foods.FindAsync(foodID);

            if (food == null)
            {
                return NotFound();
            }

            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();

            return _mapper.Map<FoodDTO>(food);
        }

        // DELETE: api/foods/1/nutritions/2
        [HttpDelete("{foodID}/nutritions/{nutritionID}")]
        public async Task<ActionResult<FoodNutritionDTO>> DeleteFoodNutrition(int foodID, int nutritionID)
        {
            var foodNutrition = await GetFoodNutritionsForDTO(foodID, nutritionID).SingleOrDefaultAsync();

            if (foodNutrition == null)
            {
                return NotFound();
            }

            _context.FoodNutritions.Remove(foodNutrition);
            await _context.SaveChangesAsync();

            return _mapper.Map<FoodNutritionDTO>(foodNutrition);
        }

        private bool FoodExists(int foodID)
        {
            return _context.Foods.Any(f => f.ID == foodID);
        }

        private bool FoodNutritionExists(int foodID, int nutritionID)
        {
            return _context.FoodNutritions
                .Where(fn => fn.FoodID == foodID)
                .Where(fn => fn.NutritionID == nutritionID)
                .Any();
        }

        private IQueryable<FoodNutrition> GetFoodNutritionsForDTO(int? foodID = null, int? nutritionID = null)
        {
            IQueryable<FoodNutrition> foodNutritions = _context.FoodNutritions
                .Include(fn => fn.Nutrition)
                .Include(fn => fn.Unit)
                .OrderBy(fn => fn.FoodID)
                .OrderBy(fn => fn.NutritionID);

            if (foodID.HasValue)
                foodNutritions = foodNutritions.Where(fn => fn.FoodID == foodID);

            if(nutritionID.HasValue)
                foodNutritions = foodNutritions.Where(fn =>  fn.NutritionID == nutritionID);

            return foodNutritions;
        }
    }
}
