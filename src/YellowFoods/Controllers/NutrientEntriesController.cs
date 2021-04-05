using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YellowFoods.Data;
using YellowFoods.Data.Models;
using YellowFoods.Dtos;

namespace YellowFoods.Controllers
{
    [Route("api/foods")]
    [ApiController]
    public class NutrientEntriesController : ControllerBase
    {
        private readonly YellowFoodsContext _context;
        private readonly IMapper _mapper;
        private readonly IConfigurationProvider _configuration;

        public NutrientEntriesController(
            YellowFoodsContext context,
            IMapper mapper,
            IConfigurationProvider configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet("{foodId}/[controller]")]
        public async Task<ActionResult<IEnumerable<NutrientEntryDto>>>
            GetNutrientEntries(int foodId)
        {
            return await _context.NutrientEntries
                .Where(ne => ne.FoodId == foodId)
                .ProjectTo<NutrientEntryDto>(_configuration)
                .ToListAsync();
        }

        [HttpGet("{foodId}/[controller]/{nutrientEntryId}")]
        public async Task<ActionResult<NutrientEntryDto>> GetNutrientEntry(
            int foodId,
            int nutrientEntryId)
        {
            var nutrientEntryDto = await _context.NutrientEntries
                .Where(ne => ne.FoodId == foodId
                             && ne.Id == nutrientEntryId)
                .ProjectTo<NutrientEntryDto>(_configuration)
                .FirstOrDefaultAsync();

            if (nutrientEntryDto == null)
            {
                return NotFound();
            }

            return nutrientEntryDto;
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
            _context.Entry(nutrientEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NutrientEntryExists(nutrientEntryId))
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
            _context.NutrientEntries.Add(nutrientEntry);
            await _context.SaveChangesAsync();

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
            var nutrientEntry = await _context.NutrientEntries
                .Where(ne => ne.FoodId == foodId
                             && ne.Id == nutrientEntryId)
                .FirstOrDefaultAsync();
            if (nutrientEntry == null)
            {
                return NotFound();
            }

            _context.NutrientEntries.Remove(nutrientEntry);
            await _context.SaveChangesAsync();

            return _mapper.Map<NutrientEntryDto>(nutrientEntry);
        }

        private bool NutrientEntryExists(int nutrientEntryId) =>
            _context.NutrientEntries.Any(ne => ne.Id == nutrientEntryId);
    }
}
