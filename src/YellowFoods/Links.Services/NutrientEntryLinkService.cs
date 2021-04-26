using YellowFoods.Links.Generators.Abstractions;
using YellowFoods.Links.Services.Abstractions;
using YellowFoods.Resources;

namespace YellowFoods.Links.Services
{
    public class NutrientEntryLinkService : ILinkService<NutrientEntryResource>
    {
        private readonly INutrientEntriesGenerator _nutrientEntriesGenerator;

        public NutrientEntryLinkService(
            INutrientEntriesGenerator nutrientEntriesGenerator)
        {
            _nutrientEntriesGenerator = nutrientEntriesGenerator;
        }

        public void AddLinks(NutrientEntryResource resource)
        {
            AddGetNutrientEntriesLink(resource);
            AddGetNutrientEntryLink(resource);
            AddPostNutrientEntryLink(resource);
            AddPutNutrientEntryLink(resource);
            AddDeleteNutrientEntryLink(resource);
        }

        private void AddGetNutrientEntriesLink(NutrientEntryResource resource)
        {
            resource.AddLink(
                _nutrientEntriesGenerator.GetGetNutrientEntriesLink(
                    Relationships.Self,
                    resource.FoodId));
        }

        private void AddGetNutrientEntryLink(NutrientEntryResource resource)
        {
            resource.AddLink(_nutrientEntriesGenerator.GetGetNutrientEntryLink(
                Relationships.Self,
                resource.FoodId,
                resource.Id));
        }

        private void AddPostNutrientEntryLink(NutrientEntryResource resource)
        {
            resource.AddLink(_nutrientEntriesGenerator.GetPostNutrientEntryLink(
                Relationships.Self,
                resource.FoodId));
        }

        private void AddPutNutrientEntryLink(NutrientEntryResource resource)
        {
            resource.AddLink(_nutrientEntriesGenerator.GetPutNutrientEntryLink(
                Relationships.Self,
                resource.FoodId,
                resource.Id));
        }

        private void AddDeleteNutrientEntryLink(NutrientEntryResource resource)
        {
            resource.AddLink(
                _nutrientEntriesGenerator.GetDeleteNutrientEntryLink(
                    Relationships.Self,
                    resource.FoodId,
                    resource.Id));
        }
    }
}
