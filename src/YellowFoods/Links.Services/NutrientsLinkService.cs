using System.Collections.Generic;
using YellowFoods.Links.Generators.Abstractions;
using YellowFoods.Links.Services.Abstractions;
using YellowFoods.Resources;

namespace YellowFoods.Links.Services
{
    public class NutrientsLinkService : INutrientsLinkService
    {
        private readonly INutrientsGenerator _nutrientsGenerator;

        public NutrientsLinkService(INutrientsGenerator nutrientsGenerator)
        {
            _nutrientsGenerator = nutrientsGenerator;
        }

        public void AddLinks(NutrientResource resource)
        {
            AddGetNutrientsLink(resource);
            AddGetNutrientLink(resource);
        }

        public void AddLinks(IEnumerable<NutrientResource> resources)
        {
            foreach (var resource in resources)
            {
                AddLinks(resource);
            }
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
