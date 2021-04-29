using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using YellowFoods.Api.Controllers;
using YellowFoods.Api.Extensions;
using YellowFoods.Api.Links.Generators.Abstractions;

namespace YellowFoods.Api.Links.Generators
{
    public class UnitsGenerator : IUnitsGenerator
    {
        private readonly LinkGenerator _linkGenerator;

        public UnitsGenerator(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        public Link GetGetUnitsLink(string relationship)
        {
            return new Link
            {
                Rel = relationship,
                Href = _linkGenerator.GetPathByControllerAction(
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
                Href = _linkGenerator.GetPathByControllerAction(
                    nameof(UnitsController.GetUnit),
                    nameof(UnitsController),
                    new { unitId }),
                Action = HttpMethods.Get
            };
        }
    }
}
