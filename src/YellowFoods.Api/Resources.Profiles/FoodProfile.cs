using AutoMapper;
using YellowFoods.Data.Models;

namespace YellowFoods.Api.Resources.Profiles
{
    public class FoodProfile : Profile
    {
        public FoodProfile() => CreateMap<Food, FoodResource>().ReverseMap();
    }
}
