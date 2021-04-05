using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YellowFoods.Data.Models;
using YellowFoods.Data.Services.Abstractions;
using YellowFoods.Dtos;

namespace YellowFoods.Controllers
{
    [Route("api/foods")]
    [ApiController]
    public class NutrientEntriesController : ControllerBase
    {
        private readonly INutrientEntriesDataService _dataService;
        private readonly IMapper _mapper;

        public NutrientEntriesController(
            INutrientEntriesDataService dataService,
            IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet("{foodId}/[controller]")]
        public async Task<ActionResult<IEnumerable<NutrientEntryDto>>>
            GetNutrientEntries(int foodId)
        {
            var nutrientEntries = await _dataService.GetNutrientEntriesAsync(
                foodId);

            return _mapper.Map<IEnumerable<NutrientEntryDto>>(nutrientEntries)
                .ToList();
        }

        [HttpGet("{foodId}/[controller]/{nutrientEntryId}")]
        public async Task<ActionResult<NutrientEntryDto>> GetNutrientEntry(
            int foodId,
            int nutrientEntryId)
        {
            var nutrientEntry = await _dataService.GetNutrientEntryAsync(
                foodId, nutrientEntryId);
            if (nutrientEntry == null)
            {
                return NotFound();
            }

            return _mapper.Map<NutrientEntryDto>(nutrientEntry);
        }

        [HttpPut("{foodId}/[controller]/{nutrientEntryId}")]
        public async Task<IActionResult> PutNutrientEntry(
            int foodId,
            int nutrientEntryId,
            NutrientEntryDto nutrientEntryDto)
        {
            if (foodId != nutrientEntryDto.FoodId
                || nutrientEntryId != nutrientEntryDto.Id)
            {
                return BadRequest();
            }

            var nutrientEntry = _mapper.Map<NutrientEntry>(nutrientEntryDto);
            await _dataService.UpdateNutrientEntry(nutrientEntry);

            return NoContent();
        }

        [HttpPost("{foodId}/[controller]")]
        public async Task<ActionResult<NutrientEntryDto>> PostNutrientEntry(
            int foodId,
            NutrientEntryDto nutrientEntryDto)
        {
            if (foodId != nutrientEntryDto.FoodId)
            {
                return BadRequest();
            }

            var nutrientEntry = _mapper.Map<NutrientEntry>(nutrientEntryDto);
            await _dataService.AddNutrientEntry(nutrientEntry);

            return CreatedAtAction(
                nameof(GetNutrientEntry),
                new { foodId, nutrientEntryId = nutrientEntry.Id },
                _mapper.Map<NutrientEntryDto>(nutrientEntry));
        }

        [HttpDelete("{foodId}/[controller]/{nutrientEntryId}")]
        public async Task<ActionResult<NutrientEntryDto>> DeleteNutrientEntry(
            int foodId,
            int nutrientEntryId)
        {
            var nutrientEntry = await _dataService.GetNutrientEntryAsync(
                foodId, nutrientEntryId);
            if (nutrientEntry == null)
            {
                return NotFound();
            }

            await _dataService.RemoveNutrientEntry(nutrientEntry);

            return _mapper.Map<NutrientEntryDto>(nutrientEntry);
        }
    }
}
