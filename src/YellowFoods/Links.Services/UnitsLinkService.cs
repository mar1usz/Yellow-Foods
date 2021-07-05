using System.Collections.Generic;
using YellowFoods.Links.Generators.Abstractions;
using YellowFoods.Links.Services.Abstractions;
using YellowFoods.Resources;

namespace YellowFoods.Links.Services
{
    public class UnitsLinkService : IUnitsLinkService
    {
        private readonly IUnitsGenerator _unitsGenerator;

        public UnitsLinkService(IUnitsGenerator unitsGenerator)
        {
            _unitsGenerator = unitsGenerator;
        }

        public void AddLinks(IEnumerable<UnitResource> resources)
        {
            foreach (var resource in resources)
            {
                AddLinks(resource);
            }
        }

        public void AddLinks(UnitResource resource)
        {
            AddGetUnitsLink(resource);
            AddGetUnitLink(resource);
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
