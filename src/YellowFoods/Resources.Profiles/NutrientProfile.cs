using AutoMapper;
using YellowFoods.Data.Models;

namespace YellowFoods.Resources.Profiles
{
    public class NutrientProfile : Profile
    {
        public NutrientProfile() => CreateMap<Nutrient, NutrientResource>().ReverseMap();
    }
}
