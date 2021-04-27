using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using YellowFoods.Controllers;
using YellowFoods.Extensions;
using YellowFoods.Links.Generators.Abstractions;

namespace YellowFoods.Links.Generators
{
    public class FoodsGenerator : IFoodsGenerator
    {
        private readonly LinkGenerator _linkGenerator;

        public FoodsGenerator(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        public Link GetGetFoodsLink(string relationship)
        {
            return new Link
            {
                Rel = relationship,
                Href = _linkGenerator.GetPathByControllerAction(
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
                Href = _linkGenerator.GetPathByControllerAction(
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
                Href = _linkGenerator.GetPathByControllerAction(
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
                Href = _linkGenerator.GetPathByControllerAction(
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
                Href = _linkGenerator.GetPathByControllerAction(
                    nameof(FoodsController.DeleteFood),
                    nameof(FoodsController),
                    new { foodId }),
                Action = HttpMethods.Delete
            };
        }
    }
}
