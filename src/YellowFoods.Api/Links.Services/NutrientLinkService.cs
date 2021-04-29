using YellowFoods.Api.Links.Generators.Abstractions;
using YellowFoods.Api.Links.Services.Abstractions;
using YellowFoods.Api.Resources;

namespace YellowFoods.Api.Links.Services
{
    public class NutrientLinkService : ILinkService<NutrientResource>
    {
        private readonly INutrientsGenerator _nutrientsGenerator;

        public NutrientLinkService(INutrientsGenerator nutrientsGenerator)
        {
            _nutrientsGenerator = nutrientsGenerator;
        }

        public void AddLinks(NutrientResource resource)
        {
            AddGetNutrientsLink(resource);
            AddGetNutrientLink(resource);
        }

        private void AddGetNutrientsLink(NutrientResource resource)
        {
            resource.AddLink(_nutrientsGenerator.GetGetNutrientsLink(
                Relationships.Self));
        }

        private void AddGetNutrientLink(NutrientResource resource)
        {
            resource.AddLink(_nutrientsGenerator.GetGetNutrientLink(
                Relationships.Self,
                resource.Id));
        }
    }
}
