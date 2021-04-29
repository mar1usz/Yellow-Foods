using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using YellowFoods.Api.Controllers;
using YellowFoods.Api.Extensions;
using YellowFoods.Api.Links.Generators.Abstractions;

namespace YellowFoods.Api.Links.Generators
{
    public class NutrientEntriesGenerator : INutrientEntriesGenerator
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NutrientEntriesGenerator(
            LinkGenerator linkGenerator,
            IHttpContextAccessor httpContextAccessor)
        {
            _linkGenerator = linkGenerator;
            _httpContextAccessor = httpContextAccessor;
        }

        public Link GetGetNutrientEntriesLink(string relationship, int foodId)
        {
            return new Link
            {
                Rel = relationship,
                Href = _linkGenerator.GetUriByNameofAction(
                    _httpContextAccessor.HttpContext,
                    nameof(NutrientEntriesController.GetNutrientEntries),
                    nameof(NutrientEntriesController),
                    new { foodId }),
                Action = HttpMethods.Get
            };
        }

        public Link GetGetNutrientEntryLink(
            string relationship,
            int foodId,
            int nutrientEntryId)

        {
            return new Link
            {
                Rel = relationship,
                Href = _linkGenerator.GetUriByNameofAction(
                    _httpContextAccessor.HttpContext,
                    nameof(NutrientEntriesController.GetNutrientEntry),
                    nameof(NutrientEntriesController),
                    new { foodId, nutrientEntryId }),
                Action = HttpMethods.Get
            };
        }

        public Link GetPostNutrientEntryLink(string relationship, int foodId)
        {
            return new Link
            {
                Rel = relationship,
                Href = _linkGenerator.GetUriByNameofAction(
                    _httpContextAccessor.HttpContext,
                    nameof(NutrientEntriesController.PostNutrientEntry),
                    nameof(NutrientEntriesController),
                    new { foodId }),
                Action = HttpMethods.Post
            };
        }

        public Link GetPutNutrientEntryLink(
            string relationship,
            int foodId,
            int nutrientEntryId)

        {
            return new Link
            {
                Rel = relationship,
                Href = _linkGenerator.GetUriByNameofAction(
                    _httpContextAccessor.HttpContext,
                    nameof(NutrientEntriesController.PutNutrientEntry),
                    nameof(NutrientEntriesController),
                    new { foodId, nutrientEntryId }),
                Action = HttpMethods.Put
            };
        }

        public Link GetDeleteNutrientEntryLink(
            string relationship,
            int foodId,
            int nutrientEntryId)

        {
            return new Link
            {
                Rel = relationship,
                Href = _linkGenerator.GetUriByNameofAction(
                    _httpContextAccessor.HttpContext,
                    nameof(NutrientEntriesController.DeleteNutrientEntry),
                    nameof(NutrientEntriesController),
                    new { foodId, nutrientEntryId }),
                Action = HttpMethods.Delete
            };
        }
    }
}
