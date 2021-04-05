using AutoMapper;
using YellowFoods.Data.Models;
using YellowFoods.Dtos;

namespace YellowFoods.Profiles
{
    public class NutrientProfile : Profile
    {
        public NutrientProfile() => CreateMap<Nutrient, NutrientDto>()
            .ReverseMap();
    }
}
