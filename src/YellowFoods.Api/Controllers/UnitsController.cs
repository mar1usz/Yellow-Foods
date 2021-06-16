using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YellowFoods.Api.Links.Services.Abstractions;
using YellowFoods.Api.Resources;
using YellowFoods.Data.Services.Abstractions;

namespace YellowFoods.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly IUnitsDataService _dataService;
        private readonly IMapper _mapper;
        private readonly ILinkService<UnitResource> _linkService;

        public UnitsController(
            IUnitsDataService dataService,
            IMapper mapper,
            ILinkService<UnitResource> linkService)
        {
            _dataService = dataService;
            _mapper = mapper;
            _linkService = linkService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitResource>>> GetUnits()
        {
            var units = await _dataService.GetUnitsAsync();

            var resources = _mapper.Map<IEnumerable<UnitResource>>(units);
            _linkService.AddLinks(resources);
            return resources.ToList();
        }

        [HttpGet("{unitId}")]
        public async Task<ActionResult<UnitResource>> GetUnit(int unitId)
        {
            var unit = await _dataService.GetUnitAsync(unitId);
            if (unit == null)
            {
                return NotFound();
            }

            var resource = _mapper.Map<UnitResource>(unit);
            _linkService.AddLinks(resource);
            return resource;
        }
    }
}
