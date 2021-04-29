using AutoMapper;
using YellowFoods.Data.Models;

namespace YellowFoods.Api.Resources.Profiles
{
    public class NutrientEntryProfile : Profile
    {
        public NutrientEntryProfile() =>
            CreateMap<NutrientEntry, NutrientEntryResource>().ReverseMap();
    }
}
