using AutoMapper;
using YellowFoods.Data.Models;

namespace YellowFoods.Api.Resources.Profiles
{
    public class UnitProfile : Profile
    {
        public UnitProfile() => CreateMap<Unit, UnitResource>().ReverseMap();
    }
}
