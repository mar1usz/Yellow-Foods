﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YellowFoods.Data.Services.Abstractions;
using YellowFoods.Resources;

namespace YellowFoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutrientsController : ControllerBase
    {
        private readonly INutrientsDataService _dataService;
        private readonly IMapper _mapper;

        public NutrientsController(INutrientsDataService dataService,
            IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NutrientResource>>>
            GetNutrients()
        {
            var nutrients = await _dataService.GetNutrientsAsync();
            return _mapper.Map<IEnumerable<NutrientResource>>(nutrients)
                .ToList();
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

            return _mapper.Map<NutrientResource>(nutrient);
        }
    }
}
