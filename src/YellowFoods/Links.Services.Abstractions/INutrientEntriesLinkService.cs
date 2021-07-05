using System.Collections.Generic;
using YellowFoods.Resources;

namespace YellowFoods.Links.Services.Abstractions
{
    public interface INutrientEntriesLinkService
    {
        void AddLinks(IEnumerable<NutrientEntryResource> resources);
        void AddLinks(NutrientEntryResource resource);
    }
}