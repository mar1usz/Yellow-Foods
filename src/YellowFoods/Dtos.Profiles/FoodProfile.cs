using AutoMapper;
using YellowFoods.Data.Models;

namespace YellowFoods.Dtos.Profiles
{
    public class FoodProfile : Profile
    {
        public FoodProfile() => CreateMap<Food, FoodDto>().ReverseMap();
    }
}
