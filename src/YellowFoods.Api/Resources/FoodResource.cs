using YellowFoods.Api.Resources.Abstractions;

namespace YellowFoods.Api.Resources
{
    public class FoodResource : Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
