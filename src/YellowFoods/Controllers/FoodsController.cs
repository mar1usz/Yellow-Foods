using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YellowFoods.Data.Models;
using YellowFoods.Data.Services.Abstractions;
using YellowFoods.Dtos;

namespace YellowFoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodsDataService _dataService;
        private readonly IMapper _mapper;
        private readonly IConfigurationProvider _configuration;

        public FoodsController(
            IFoodsDataService dataService,
            IMapper mapper,
            IConfigurationProvider configuration)
        {
            _dataService = dataService;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodDto>>> GetFoods()
        {
            var foods = await _dataService.GetFoodsAsync();
            return  _mapper.Map<IEnumerable<FoodDto>>(foods).ToList();
        }

        [HttpGet("{foodId}")]
        public async Task<ActionResult<FoodDto>> GetFood(int foodId)
        {
            var food = await _dataService.GetFoodAsync(foodId);
            if (food == null)
            {
                return NotFound();
            }

            return _mapper.Map<FoodDto>(food);
        }

        [HttpPut("{foodId}")]
        public async Task<IActionResult> PutFood(int foodId, FoodDto foodDto)
        {
            if (foodId != foodDto.Id)
            {
                return BadRequest();
            }

            var food = _mapper.Map<Food>(foodDto);
            await _dataService.UpdateFood(food);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<FoodDto>> PostFood(FoodDto foodDto)
        {
            var food = _mapper.Map<Food>(foodDto);
            await _dataService.AddFood(food);

            return CreatedAtAction(
                nameof(GetFood),
                new { foodId = food.Id },
                _mapper.Map<FoodDto>(food));
        }

        [HttpDelete("{foodId}")]
        public async Task<ActionResult<FoodDto>> DeleteFood(int foodId)
        {
            var food = await _dataService.GetFoodAsync(foodId);
            if (food == null)
            {
                return NotFound();
            }

            await _dataService.RemoveFood(food);
            return _mapper.Map<FoodDto>(food);
        }
    }
}
