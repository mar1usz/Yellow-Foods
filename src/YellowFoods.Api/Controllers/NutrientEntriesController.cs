using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YellowFoods.Api.Links.Services.Abstractions;
using YellowFoods.Api.Resources;
using YellowFoods.Data.Models;
using YellowFoods.Data.Services.Abstractions;

namespace YellowFoods.Api.Controllers
{
    [Route("api/foods")]
    [ApiController]
    public class NutrientEntriesController : ControllerBase
    {
        private readonly INutrientEntriesDataService _dataService;
        private readonly IMapper _mapper;
        private readonly ILinkService<NutrientEntryResource> _linkService;

        public NutrientEntriesController(
            INutrientEntriesDataService dataService,
            IMapper mapper,
            ILinkService<NutrientEntryResource> linkService)
        {
            _dataService = dataService;
            _mapper = mapper;
            _linkService = linkService;
        }

        [HttpGet("{foodId}/[controller]")]
        public async Task<ActionResult<IEnumerable<NutrientEntryResource>>>
            GetNutrientEntries(int foodId)
        {
            var nutrientEntries = await _dataService.GetNutrientEntriesAsync(
                foodId);
            var resources = _mapper.Map<IEnumerable<NutrientEntryResource>>(
                nutrientEntries);
            _linkService.AddLinks(resources);
            return resources.ToList();
        }

        [HttpGet("{foodId}/[controller]/{nutrientEntryId}")]
        public async Task<ActionResult<NutrientEntryResource>> GetNutrientEntry(
            int foodId,
            int nutrientEntryId)
        {
            var nutrientEntry = await _dataService.GetNutrientEntryAsync(
                foodId, nutrientEntryId);
            if (nutrientEntry == null)
            {
                return NotFound();
            }

            var resource = _mapper.Map<NutrientEntryResource>(nutrientEntry);
            _linkService.AddLinks(resource);
            return resource;
        }

        [HttpPut("{foodId}/[controller]/{nutrientEntryId}")]
        public async Task<IActionResult> PutNutrientEntry(
            int foodId,
            int nutrientEntryId,
            NutrientEntryResource resource)
        {
            if (foodId != resource.FoodId
                || nutrientEntryId != resource.Id)
            {
                return BadRequest();
            }

            var nutrientEntry = _mapper.Map<NutrientEntry>(resource);
            await _dataService.UpdateNutrientEntry(nutrientEntry);

            return NoContent();
        }

        [HttpPost("{foodId}/[controller]")]
        public async Task<ActionResult<NutrientEntryResource>>
            PostNutrientEntry(int foodId, NutrientEntryResource resource)
        {
            if (foodId != resource.FoodId)
            {
                return BadRequest();
            }

            var nutrientEntry = _mapper.Map<NutrientEntry>(resource);
            await _dataService.AddNutrientEntry(nutrientEntry);

            var addedResource = _mapper.Map<NutrientEntryResource>(
                nutrientEntry);
            _linkService.AddLinks(addedResource);
            return CreatedAtAction(
                nameof(GetNutrientEntry),
                new { foodId, nutrientEntryId = addedResource.Id },
                addedResource);
        }

        [HttpDelete("{foodId}/[controller]/{nutrientEntryId}")]
        public async Task<ActionResult<NutrientEntryResource>>
            DeleteNutrientEntry(int foodId, int nutrientEntryId)
        {
            var nutrientEntry = await _dataService.GetNutrientEntryAsync(
                foodId, nutrientEntryId);
            if (nutrientEntry == null)
            {
                return NotFound();
            }

            await _dataService.RemoveNutrientEntry(nutrientEntry);

            var resource = _mapper.Map<NutrientEntryResource>(nutrientEntry);
            _linkService.AddLinks(resource);
            return resource;
        }
    }
}
