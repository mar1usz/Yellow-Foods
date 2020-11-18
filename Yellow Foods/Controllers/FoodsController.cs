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

        // GET: api/foods/1/nutrients
        [HttpGet("{foodID}/nutrients")]
        public async Task<ActionResult<IEnumerable<FoodNutrientDTO>>> GetFoodNutrients(int foodID)
        {
            var foodNutrient = await GetFoodNutrientsForDTO(foodID, null).ToListAsync();

            return _mapper.Map<List<FoodNutrientDTO>>(foodNutrient);
        }

        // GET: api/foods/1/nutrients/2
        [HttpGet("{foodID}/nutrients/{nutrientID}")]
        public async Task<ActionResult<FoodNutrientDTO>> GetFoodNutrient(int foodID, int nutrientID)
        {
            var foodNutrient = await GetFoodNutrientsForDTO(foodID, nutrientID).SingleOrDefaultAsync();

            if (foodNutrient == null)
            {
                return NotFound();
            }

            return _mapper.Map<FoodNutrientDTO>(foodNutrient);
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

        // PUT: api/foods/1/nutrients/2
        [HttpPut("{foodID}/nutrients/{nutrientID}")]
        public async Task<IActionResult> PutFoodNutrient(int foodID, int nutrientID, FoodNutrientDTO foodNutrientDTO)
        {
            if (foodNutrientDTO.NutrientID != nutrientID)
            {
                return BadRequest();
            }

            int ID = await _context.FoodNutrients
                .Where(fn => fn.FoodID == foodID)
                .Where(fn => fn.NutrientID == nutrientID)
                .Select(fn => fn.ID)
                .SingleOrDefaultAsync();

            if (ID == 0)
            {
                return NotFound();
            }

            var foodNutrient = _mapper.Map<FoodNutrient>(foodNutrientDTO);
            foodNutrient.ID = ID;
            foodNutrient.FoodID = foodID;
            _context.Entry(foodNutrient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodNutrientExists(foodID, nutrientID))
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

        // POST: api/foods/1/nutrients
        [HttpPost("{foodID}/nutrients")]
        public async Task<ActionResult<FoodNutrientDTO>> PostFoodNutrient(int foodID, FoodNutrientDTO foodNutrientDTO)
        {
            var foodNutrient = _mapper.Map<FoodNutrient>(foodNutrientDTO);
            foodNutrient.FoodID = foodID;
            _context.FoodNutrients.Add(foodNutrient);

            await _context.SaveChangesAsync();

            foodNutrient = await GetFoodNutrientsForDTO(foodNutrient.FoodID, foodNutrient.NutrientID).SingleOrDefaultAsync();

            return CreatedAtAction(nameof(GetFoodNutrient), new { foodID = foodNutrient.FoodID, nutrientID = foodNutrient.NutrientID }, _mapper.Map<FoodNutrientDTO>(foodNutrient));
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

        // DELETE: api/foods/1/nutrients/2
        [HttpDelete("{foodID}/nutrients/{nutrientID}")]
        public async Task<ActionResult<FoodNutrientDTO>> DeleteFoodNutrient(int foodID, int nutrientID)
        {
            var foodNutrient = await GetFoodNutrientsForDTO(foodID, nutrientID).SingleOrDefaultAsync();

            if (foodNutrient == null)
            {
                return NotFound();
            }

            _context.FoodNutrients.Remove(foodNutrient);
            await _context.SaveChangesAsync();

            return _mapper.Map<FoodNutrientDTO>(foodNutrient);
        }

        private bool FoodExists(int foodID)
        {
            return _context.Foods.Any(f => f.ID == foodID);
        }

        private bool FoodNutrientExists(int foodID, int nutrientID)
        {
            return _context.FoodNutrients
                .Where(fn => fn.FoodID == foodID)
                .Where(fn => fn.NutrientID == nutrientID)
                .Any();
        }

        private IQueryable<FoodNutrient> GetFoodNutrientsForDTO(int? foodID = null, int? nutrientID = null)
        {
            IQueryable<FoodNutrient> foodNutrients = _context.FoodNutrients
                .Include(fn => fn.Nutrient)
                .Include(fn => fn.Unit);

            if (foodID.HasValue)
            {
                foodNutrients = foodNutrients.Where(fn => fn.FoodID == foodID);
            }

            if (nutrientID.HasValue)
            {
                foodNutrients = foodNutrients.Where(fn => fn.NutrientID == nutrientID);
            }

            return foodNutrients;
        }
    }
}
