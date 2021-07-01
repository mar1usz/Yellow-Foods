using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using YellowFoods.Controllers;
using YellowFoods.Extensions;
using YellowFoods.Links.Generators.Abstractions;

namespace YellowFoods.Links.Generators
{
    public class UnitsGenerator : IUnitsGenerator
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UnitsGenerator(
            LinkGenerator linkGenerator,
            IHttpContextAccessor httpContextAccessor)
        {
            _linkGenerator = linkGenerator;
            _httpContextAccessor = httpContextAccessor;
        }

        public Link GetGetUnitsLink(string relationship)
        {
            return new Link
            {
                Rel = relationship,
                Href = _linkGenerator.GetUriByNameofAction(
                    _httpContextAccessor.HttpContext,
                    nameof(UnitsController.GetUnits),
                    nameof(UnitsController)),
                Action = HttpMethods.Get
            };
        }

        public Link GetGetUnitLink(string relationship, int unitId)
        {
            return new Link
            {
                Rel = relationship,
                Href = _linkGenerator.GetUriByNameofAction(
                    _httpContextAccessor.HttpContext,
                    nameof(UnitsController.GetUnit),
                    nameof(UnitsController),
                    new { unitId }),
                Action = HttpMethods.Get
            };
        }
    }
}
