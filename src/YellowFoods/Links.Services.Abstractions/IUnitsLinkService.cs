using System.Collections.Generic;
using YellowFoods.Resources;

namespace YellowFoods.Links.Services.Abstractions
{
    public interface IUnitsLinkService
    {
        void AddLinks(IEnumerable<UnitResource> resources);
        void AddLinks(UnitResource resource);
    }
}