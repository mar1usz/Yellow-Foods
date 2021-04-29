using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using YellowFoods.Api.Controllers;
using YellowFoods.Api.Extensions;
using YellowFoods.Api.Links.Generators.Abstractions;

namespace YellowFoods.Api.Links.Generators
{
    public class FoodsGenerator : IFoodsGenerator
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FoodsGenerator(
            LinkGenerator linkGenerator,
            IHttpContextAccessor httpContextAccessor)
        {
            _linkGenerator = linkGenerator;
            _httpContextAccessor = httpContextAccessor;
        }

        public Link GetGetFoodsLink(string relationship)
        {
            return new Link
            {
                Rel = relationship,
                Href = _linkGenerator.GetUriByNameofAction(
                    _httpContextAccessor.HttpContext,
                    nameof(FoodsController.GetFoods),
                    nameof(FoodsController)),
                Action = HttpMethods.Get
            };
        }

        public Link GetGetFoodLink(string relationship, int foodId)
        {
            return new Link
            {
                Rel = relationship,
                Href = _linkGenerator.GetUriByNameofAction(
                    _httpContextAccessor.HttpContext,
                    nameof(FoodsController.GetFood),
                    nameof(FoodsController),
                    new { foodId }),
                Action = HttpMethods.Get
            };
        }

        public Link GetPostFoodLink(string relationship)
        {
            return new Link
            {
                Rel = relationship,
                Href = _linkGenerator.GetUriByNameofAction(
                    _httpContextAccessor.HttpContext,
                    nameof(FoodsController.PostFood),
                    nameof(FoodsController)),
                Action = HttpMethods.Post
            };
        }

        public Link GetPutFoodLink(string relationship, int foodId)
        {
            return new Link
            {
                Rel = relationship,
                Href = _linkGenerator.GetUriByNameofAction(
                    _httpContextAccessor.HttpContext,
                    nameof(FoodsController.PutFood),
                    nameof(FoodsController),
                    new { foodId }),
                Action = HttpMethods.Put
            };
        }

        public Link GetDeleteFoodLink(string relationship, int foodId)
        {
            return new Link
            {
                Rel = relationship,
                Href = _linkGenerator.GetUriByNameofAction(
                    _httpContextAccessor.HttpContext,
                    nameof(FoodsController.DeleteFood),
                    nameof(FoodsController),
                    new { foodId }),
                Action = HttpMethods.Delete
            };
        }
    }
}
