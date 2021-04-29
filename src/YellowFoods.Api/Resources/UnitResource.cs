using YellowFoods.Api.Resources.Abstractions;

namespace YellowFoods.Api.Resources
{
    public class UnitResource : Resource
    {
        public int Id { get; set; }
        public string Abbreviation { get; set; }
    }
}
