using AutoMapper;
using YellowFoods.Data.Models;
using YellowFoods.Dtos;

namespace YellowFoods.Profiles
{
    public class UnitProfile : Profile
    {
        public UnitProfile() => CreateMap<Unit, UnitDto>().ReverseMap();
    }
}
