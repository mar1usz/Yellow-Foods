using AutoMapper;
using YellowFoods.Data.Models;
using YellowFoods.Dtos;

namespace YellowFoods.Profiles
{
    public class NutrientEntryProfile : Profile
    {
        public NutrientEntryProfile() =>
            CreateMap<NutrientEntry, NutrientEntryDto>().ReverseMap();
    }
}
