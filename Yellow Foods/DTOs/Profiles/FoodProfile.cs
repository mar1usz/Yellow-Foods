using AutoMapper;
using Yellow_Foods.Models;

namespace Yellow_Foods.DTOs.Profiles
{
    public class FoodProfile : Profile
    {
        public FoodProfile()
        {
            CreateMap<Food, FoodDTO>()
                .ReverseMap();
        }
    }
}
