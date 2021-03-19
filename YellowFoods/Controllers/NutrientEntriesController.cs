using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YellowFoods.Data;
using YellowFoods.Models;

namespace YellowFoods.Controllers
{
    [Route("api/foods")]
    [ApiController]
    public class NutrientEntriesController : ControllerBase
    {
        private readonly YellowFoodsContext _context;

        public NutrientEntriesController(YellowFoodsContext context) =>
            _context = context;

        [HttpGet("{foodId}/[controller]")]
        public async Task<ActionResult<IEnumerable<NutrientEntry>>>
            GetNutrientEntries(int foodId)
        {
            return await _context.NutrientEntries
                .Where(ne => ne.FoodId == foodId)
                .ToListAsync();
        }

        [HttpGet("{foodId}/[controller]/{nutrientEntryId}")]
        public async Task<ActionResult<NutrientEntry>> GetNutrientEntry(
            int foodId,
            int nutrientEntryId)
        {
            var nutrientEntry = await _context.NutrientEntries
                .FindAsync(nutrientEntryId);

            if (nutrientEntry == null
                || nutrientEntry.Id != foodId)
            {
                return NotFound();
            }

            return nutrientEntry;
        }

        [HttpPut("{foodId}/[controller]/{nutrientEntryId}")]
        public async Task<IActionResult> PutNutrientEntry(
            int foodId,
            int nutrientEntryId,
            NutrientEntry nutrientEntry)
        {
            if (foodId != nutrientEntry.FoodId
                || nutrientEntryId != nutrientEntry.Id)
            {
                return BadRequest();
            }

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
        public async Task<ActionResult<NutrientEntry>> PostNutrientEntry(
            int foodId,
            NutrientEntry nutrientEntry)
        {
            if (foodId != nutrientEntry.FoodId)
            {
                return BadRequest();
            }

            _context.NutrientEntries.Add(nutrientEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetNutrientEntry),
                new { foodId, nutrientEntryId = nutrientEntry.Id },
                nutrientEntry);
        }

        [HttpDelete("{foodId}/[controller]/{nutrientEntryId}")]
        public async Task<ActionResult<NutrientEntry>> DeleteNutrientEntry(
            int foodId,
            int nutrientEntryId)
        {
            var nutrientEntry = await _context.NutrientEntries
                .FindAsync(nutrientEntryId);

            if (nutrientEntry == null
                || nutrientEntry.FoodId != foodId)
            {
                return NotFound();
            }

            _context.NutrientEntries.Remove(nutrientEntry);
            await _context.SaveChangesAsync();

            return nutrientEntry;
        }

        private bool NutrientEntryExists(int nutrientEntryId) =>
            _context.NutrientEntries.Any(ne => ne.Id == nutrientEntryId);
    }
}
