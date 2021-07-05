using System.Collections.Generic;
using YellowFoods.Resources;

namespace YellowFoods.Links.Services.Abstractions
{
    public interface INutrientsLinkService
    {
        void AddLinks(IEnumerable<NutrientResource> resources);
        void AddLinks(NutrientResource resource);
    }
}