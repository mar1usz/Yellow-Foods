using AutoMapper;
using YellowFoods.Data.Models;
using YellowFoods.Dtos;

namespace YellowFoods.Profiles
{
    public class FoodProfile : Profile
    {
        public FoodProfile() => CreateMap<Food, FoodDto>().ReverseMap();
    }
}
