using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YellowFoods.Data.Models;
using YellowFoods.Data.Services.Abstractions;
using YellowFoods.Links.Services.Abstractions;
using YellowFoods.Resources;

namespace YellowFoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodsDataService _dataService;
        private readonly IMapper _mapper;
        private readonly ILinkService<FoodResource> _linkService; 

        public FoodsController(
            IFoodsDataService dataService,
            IMapper mapper,
            ILinkService<FoodResource> linkService)
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
            FoodResource foodResource)
        {
            if (foodId != foodResource.Id)
            {
                return BadRequest();
            }

            var food = _mapper.Map<Food>(foodResource);
            await _dataService.UpdateFood(food);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<FoodResource>> PostFood(
            FoodResource foodResource)
        {
            var food = _mapper.Map<Food>(foodResource);
            await _dataService.AddFood(food);

            var addedResource = _mapper.Map<FoodResource>(
                food);
            _linkService.AddLinks(addedResource);
            return CreatedAtAction(
                nameof(GetFood),
                new { foodId = food.Id },
                addedResource);
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
