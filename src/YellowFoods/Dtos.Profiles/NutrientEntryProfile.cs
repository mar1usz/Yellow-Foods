using AutoMapper;
using YellowFoods.Data.Models;

namespace YellowFoods.Dtos.Profiles
{
    public class NutrientEntryProfile : Profile
    {
        public NutrientEntryProfile() =>
            CreateMap<NutrientEntry, NutrientEntryDto>().ReverseMap();
    }
}
