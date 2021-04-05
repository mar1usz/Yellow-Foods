using AutoMapper;
using YellowFoods.Data.Models;

namespace YellowFoods.Dtos.Profiles
{
    public class UnitProfile : Profile
    {
        public UnitProfile() => CreateMap<Unit, UnitDto>().ReverseMap();
    }
}
