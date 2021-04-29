using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using YellowFoods.Api.Controllers;
using YellowFoods.Api.Extensions;
using YellowFoods.Api.Links.Generators.Abstractions;

namespace YellowFoods.Api.Links.Generators
{
    public class NutrientsGenerator : INutrientsGenerator
    {
        private readonly LinkGenerator _linkGenerator;

        public NutrientsGenerator(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        public Link GetGetNutrientsLink(string relationship)
        {
            return new Link
            {
                Rel = relationship,
                Href = _linkGenerator.GetPathByControllerAction(
                    nameof(NutrientsController.GetNutrients),
                    nameof(NutrientsController)),
                Action = HttpMethods.Get
            };
        }

        public Link GetGetNutrientLink(string relationship, int nutrientId)
        {
            return new Link
            {
                Rel = relationship,
                Href = _linkGenerator.GetPathByControllerAction(
                    nameof(NutrientsController.GetNutrient),
                    nameof(NutrientsController),
                    new { nutrientId }),
                Action = HttpMethods.Get
            };
        }
    }
}
