using System.Collections.Generic;
using YellowFoods.Links.Generators.Abstractions;
using YellowFoods.Links.Services.Abstractions;
using YellowFoods.Resources;

namespace YellowFoods.Links.Services
{
    public class NutrientEntriesLinkService : INutrientEntriesLinkService
    {
        private readonly INutrientEntriesGenerator _nutrientEntriesGenerator;
        private readonly IFoodsGenerator _foodsGenerator;
        private readonly INutrientsGenerator _nutrientsGenerator;
        private readonly IUnitsGenerator _unitsGenerator;

        public NutrientEntriesLinkService(
            INutrientEntriesGenerator nutrientEntriesGenerator,
            IFoodsGenerator foodsGenerator,
            INutrientsGenerator nutrientsGenerator,
            IUnitsGenerator unitsGenerator)
        {
            _nutrientEntriesGenerator = nutrientEntriesGenerator;
            _foodsGenerator = foodsGenerator;
            _nutrientsGenerator = nutrientsGenerator;
            _unitsGenerator = unitsGenerator;
        }

        public void AddLinks(NutrientEntryResource resource)
        {
            AddGetNutrientEntriesLink(resource);
            AddGetNutrientEntryLink(resource);
            AddPostNutrientEntryLink(resource);
            AddPutNutrientEntryLink(resource);
            AddDeleteNutrientEntryLink(resource);
            AddGetFoodsLink(resource);
            AddGetFoodLink(resource);
            AddPostFoodLink(resource);
            AddPutFoodLink(resource);
            AddDeleteFoodLink(resource);
            AddGetNutrientsLink(resource);
            AddGetNutrientLink(resource);
            AddGetUnitsLink(resource);
            AddGetUnitLink(resource);
        }

        public void AddLinks(IEnumerable<NutrientEntryResource> resources)
        {
            foreach (var resource in resources)
            {
                AddLinks(resource);
            }
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

        private void AddGetFoodsLink(NutrientEntryResource resource)
        {
            resource.AddLink(_foodsGenerator.GetGetFoodsLink(
                Relationships.Food));
        }

        private void AddGetFoodLink(NutrientEntryResource resource)
        {
            resource.AddLink(_foodsGenerator.GetGetFoodLink(
                Relationships.Food,
                resource.FoodId));
        }

        private void AddPostFoodLink(NutrientEntryResource resource)
        {
            resource.AddLink(_foodsGenerator.GetPostFoodLink(
                Relationships.Food));
        }

        private void AddPutFoodLink(NutrientEntryResource resource)
        {
            resource.AddLink(_foodsGenerator.GetPutFoodLink(
                Relationships.Food,
                resource.FoodId));
        }

        private void AddDeleteFoodLink(NutrientEntryResource resource)
        {
            resource.AddLink(_foodsGenerator.GetDeleteFoodLink(
                Relationships.Food,
                resource.FoodId));
        }

        private void AddGetNutrientsLink(NutrientEntryResource resource)
        {
            resource.AddLink(_nutrientsGenerator.GetGetNutrientsLink(
                Relationships.Nutrient));
        }

        private void AddGetNutrientLink(NutrientEntryResource resource)
        {
            resource.AddLink(_nutrientsGenerator.GetGetNutrientLink(
                Relationships.Nutrient,
                resource.NutrientId));
        }

        private void AddGetUnitsLink(NutrientEntryResource resource)
        {
            resource.AddLink(_unitsGenerator.GetGetUnitsLink(
                Relationships.Unit));
        }

        private void AddGetUnitLink(NutrientEntryResource resource)
        {
            resource.AddLink(_unitsGenerator.GetGetUnitLink(
                Relationships.Unit,
                resource.UnitId));
        }
    }
}
