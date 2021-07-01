using AutoMapper;
using YellowFoods.Data.Models;

namespace YellowFoods.Resources.Profiles
{
    public class FoodProfile : Profile
    {
        public FoodProfile() => CreateMap<Food, FoodResource>().ReverseMap();
    }
}
