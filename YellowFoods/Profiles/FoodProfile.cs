using AutoMapper;
using YellowFoods.Dtos;
using YellowFoods.Models;

namespace YellowFoods.Profiles
{
    public class FoodProfile : Profile
    {
        public FoodProfile() => CreateMap<Food, FoodDto>().ReverseMap();
    }
}
