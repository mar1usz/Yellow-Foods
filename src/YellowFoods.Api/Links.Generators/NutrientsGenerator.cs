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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NutrientsGenerator(
            LinkGenerator linkGenerator,
            IHttpContextAccessor httpContextAccessor)
        {
            _linkGenerator = linkGenerator;
            _httpContextAccessor = httpContextAccessor;
        }

        public Link GetGetNutrientsLink(string relationship)
        {
            return new Link
            {
                Rel = relationship,
                Href = _linkGenerator.GetUriByNameofAction(
                    _httpContextAccessor.HttpContext,
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
                Href = _linkGenerator.GetUriByNameofAction(
                    _httpContextAccessor.HttpContext,
                    nameof(NutrientsController.GetNutrient),
                    nameof(NutrientsController),
                    new { nutrientId }),
                Action = HttpMethods.Get
            };
        }
    }
}
