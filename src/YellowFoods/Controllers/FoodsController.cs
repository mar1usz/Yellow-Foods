using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YellowFoods.Links.Services.Abstractions;
using YellowFoods.Resources;
using YellowFoods.Data.Models;
using YellowFoods.Data.Services.Abstractions;

namespace YellowFoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodsDataService _dataService;
        private readonly IMapper _mapper;
        private readonly IFoodsLinkService _linkService;

        public FoodsController(
            IFoodsDataService dataService,
            IMapper mapper,
            IFoodsLinkService linkService)
        {
            _dataService = dataService;
            _mapper = mapper;
            _linkService = linkService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodResource>>> GetFoods()
        {
            var foods = await _dataService.GetFoodsAsync();

            var resources = _mapper.Map<IEnumerable<FoodResource>>(foods);
            _linkService.AddLinks(resources);
            return resources.ToList();
        }

        [HttpGet("{foodId}")]
        public async Task<ActionResult<FoodResource>> GetFood(int foodId)
        {
            var food = await _dataService.GetFoodAsync(foodId);

            if (food == null)
            {
                return NotFound();
            }

            var resource = _mapper.Map<FoodResource>(food);
            _linkService.AddLinks(resource);
            return resource;
        }

        [HttpPut("{foodId}")]
        public async Task<IActionResult> PutFood(
            int foodId,
            FoodResource resource)
        {
            if (foodId != resource.Id)
            {
                return BadRequest();
            }

            var food = _mapper.Map<Food>(resource);
            await _dataService.UpdateFood(food);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<FoodResource>> PostFood(
            FoodResource resource)
        {
            var food = _mapper.Map<Food>(resource);
            await _dataService.AddFood(food);

            resource.Id = food.Id;
            _linkService.AddLinks(resource);
            return CreatedAtAction(
                nameof(GetFood),
                new { foodId = resource.Id },
                resource);
        }

        [HttpDelete("{foodId}")]
        public async Task<ActionResult<FoodResource>> DeleteFood(int foodId)
        {
            var food = await _dataService.GetFoodAsync(foodId);

            if (food == null)
            {
                return NotFound();
            }

            await _dataService.RemoveFood(food);

            var resource = _mapper.Map<FoodResource>(food);
            _linkService.AddLinks(resource);
            return resource;
        }
    }
}
