using AutoMapper;
using YellowFoods.Dtos;
using YellowFoods.Models;

namespace YellowFoods.Profiles
{
    public class NutrientEntryProfile : Profile
    {
        public NutrientEntryProfile() =>
            CreateMap<NutrientEntry, NutrientEntryDto>().ReverseMap();
    }
}
