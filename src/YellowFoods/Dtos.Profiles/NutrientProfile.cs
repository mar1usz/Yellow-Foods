using AutoMapper;
using YellowFoods.Data.Models;

namespace YellowFoods.Dtos.Profiles
{
    public class NutrientProfile : Profile
    {
        public NutrientProfile() => CreateMap<Nutrient, NutrientDto>().ReverseMap();
    }
}
