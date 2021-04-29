using YellowFoods.Api.Links.Generators.Abstractions;
using YellowFoods.Api.Links.Services.Abstractions;
using YellowFoods.Api.Resources;

namespace YellowFoods.Api.Links.Services
{
    public class UnitLinkService : ILinkService<UnitResource>
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
