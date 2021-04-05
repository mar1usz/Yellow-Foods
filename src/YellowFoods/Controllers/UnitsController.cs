using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YellowFoods.Data.Services.Abstractions;
using YellowFoods.Dtos;

namespace YellowFoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly IUnitsDataService _dataService;
        private readonly IMapper _mapper;

        public UnitsController(IUnitsDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitDto>>> GetUnits()
        {
            var nutrients = await _dataService.GetUnitsAsync();

            return _mapper.Map<IEnumerable<UnitDto>>(nutrients).ToList();
        }

        [HttpGet("{unitId}")]
        public async Task<ActionResult<UnitDto>> GetUnit(int unitId)
        {
            var unit = await _dataService.GetUnitAsync(unitId);
            if (unit == null)
            {
                return NotFound();
            }

            return _mapper.Map<UnitDto>(unit);
        }
    }
}
