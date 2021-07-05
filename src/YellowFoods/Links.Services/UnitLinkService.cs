using System.Collections.Generic;
using YellowFoods.Links.Generators.Abstractions;
using YellowFoods.Links.Services.Abstractions;
using YellowFoods.Resources;

namespace YellowFoods.Links.Services
{
    public class UnitLinkService : IUnitLinkService
    {
        private readonly IUnitsGenerator _unitsGenerator;

        public UnitLinkService(IUnitsGenerator unitsGenerator)
        {
            _unitsGenerator = unitsGenerator;
        }

        public void AddLinks(UnitResource resource)
        {
            AddGetUnitsLink(resource);
            AddGetUnitLink(resource);
        }

        public void AddLinks(IEnumerable<UnitResource> resources)
        {
            foreach (var resource in resources)
            {
                AddLinks(resource);
            }
        }

        private void AddGetUnitsLink(UnitResource resource)
        {
            resource.AddLink(_unitsGenerator.GetGetUnitsLink(
                Relationships.Self));
        }

        private void AddGetUnitLink(UnitResource resource)
        {
            resource.AddLink(_unitsGenerator.GetGetUnitLink(
                Relationships.Self,
                resource.Id));
        }
    }
}
