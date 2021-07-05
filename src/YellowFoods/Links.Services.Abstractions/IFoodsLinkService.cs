using System.Collections.Generic;
using YellowFoods.Resources;

namespace YellowFoods.Links.Services.Abstractions
{
    public interface IFoodsLinkService
    {
        void AddLinks(FoodResource resource);
        void AddLinks(IEnumerable<FoodResource> resources);
    }
}