﻿using YellowFoods.Links.Generators.Abstractions;
using YellowFoods.Links.Services.Abstractions;
using YellowFoods.Resources;

namespace YellowFoods.Links.Services
{
    public class FoodLinkService : ILinkService<FoodResource>
    {
        private readonly IFoodsGenerator _foodsGenerator;
        private readonly INutrientEntriesGenerator _nutrientEntriesGenerator;

        public FoodLinkService(
            IFoodsGenerator foodsGenerator,
            INutrientEntriesGenerator nutrientEntriesGenerator) 
        {
            _foodsGenerator = foodsGenerator;
            _nutrientEntriesGenerator = nutrientEntriesGenerator;
        }

        public void AddLinks(FoodResource resource)
        {
            AddGetFoodsLink(resource);
            AddGetFoodLink(resource);
            AddPostFoodLink(resource);
            AddPutFoodLink(resource);
            AddDeleteFoodLink(resource);
            AddGetNutrientEntriesLink(resource);
            AddPostNutrientEntriesLink(resource);
        }

        private void AddGetFoodsLink(FoodResource resource)
        {
            resource.AddLink(_foodsGenerator.GetGetFoodsLink(
                Relationships.Self));
        }

        private void AddGetFoodLink(FoodResource resource)
        {
            resource.AddLink(_foodsGenerator.GetGetFoodLink(
                Relationships.Self,
                resource.Id));
        }

        private void AddPostFoodLink(FoodResource resource)
        {
            resource.AddLink(_foodsGenerator.GetPostFoodLink(
                Relationships.Self));
        }

        private void AddPutFoodLink(FoodResource resource)
        {
            resource.AddLink(_foodsGenerator.GetPutFoodLink(
                Relationships.Self,
                resource.Id));
        }

        private void AddDeleteFoodLink(FoodResource resource)
        {
            resource.AddLink(_foodsGenerator.GetDeleteFoodLink(
                Relationships.Self,
                resource.Id));
        }

        private void AddGetNutrientEntriesLink(FoodResource resource)
        {
            resource.AddLink(
                _nutrientEntriesGenerator.GetGetNutrientEntriesLink(
                    Relationships.NutrientEntry,
                    resource.Id));
        }

        private void AddPostNutrientEntriesLink(FoodResource resource)
        {
            resource.AddLink(_nutrientEntriesGenerator.GetPostNutrientEntryLink(
                Relationships.NutrientEntry,
                resource.Id));
        }
    }
}