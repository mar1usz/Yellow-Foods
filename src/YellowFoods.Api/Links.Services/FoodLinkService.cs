using YellowFoods.Api.Links.Generators.Abstractions;
using YellowFoods.Api.Links.Services.Abstractions;
using YellowFoods.Api.Resources;

namespace YellowFoods.Api.Links.Services
{
    public class FoodLinkService : ILinkService<FoodResource>
    {
        private readonly IFoodsGenerator _foodsGenerator;

        public FoodLinkService(IFoodsGenerator foodsGenerator)
        {
            _foodsGenerator = foodsGenerator;
        }

        public void AddLinks(FoodResource resource)
        {
            AddGetFoodsLink(resource);
            AddGetFoodLink(resource);
            AddPostFoodLink(resource);
            AddPutFoodLink(resource);
            AddDeleteFoodLink(resource);
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
    }
}
