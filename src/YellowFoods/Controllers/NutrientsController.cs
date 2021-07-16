using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YellowFoods.Links.Services.Abstractions;
using YellowFoods.Resources;
using YellowFoods.Data.Services.Abstractions;

namespace YellowFoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutrientsController : ControllerBase
    {
        private readonly INutrientsDataService _dataService;
        private readonly IMapper _mapper;
        private readonly INutrientsLinkService _linkService;

        public NutrientsController(
            INutrientsDataService dataService,
            IMapper mapper,
            INutrientsLinkService linkService)
        {
            _dataService = dataService;
            _mapper = mapper;
            _linkService = linkService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NutrientResource>>>
            GetNutrients()
        {
            var nutrients = await _dataService.GetNutrientsAsync();

            var resources = _mapper
                .Map<IEnumerable<NutrientResource>>(nutrients);
            _linkService.AddLinks(resources);
            return resources.ToList();
        }

        [HttpGet("{nutrientId}")]
        public async Task<ActionResult<NutrientResource>> GetNutrient(
            int nutrientId)
        {
            var nutrient = await _dataService.GetNutrientAsync(nutrientId);

            if (nutrient == null)
            {
                return NotFound();
            }

            var resource = _mapper.Map<NutrientResource>(nutrient);
            _linkService.AddLinks(resource);
            return resource;
        }
    }
}
