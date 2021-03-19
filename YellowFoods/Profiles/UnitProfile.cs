using AutoMapper;
using YellowFoods.Dtos;
using YellowFoods.Models;

namespace YellowFoods.Profiles
{
    public class UnitProfile : Profile
    {
        public UnitProfile() => CreateMap<Unit, UnitDto>().ReverseMap();
    }
}
