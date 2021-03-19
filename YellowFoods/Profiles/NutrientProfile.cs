using AutoMapper;
using YellowFoods.Dtos;
using YellowFoods.Models;

namespace YellowFoods.Profiles
{
    public class NutrientProfile : Profile
    {
        public NutrientProfile() => CreateMap<Nutrient, NutrientDto>()
            .ReverseMap();
    }
}
