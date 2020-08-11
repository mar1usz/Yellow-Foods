using AutoMapper;
using Yellow_Foods.Models;

namespace Yellow_Foods.DTOs.Profiles
{
    public class FoodNutritionProfile : Profile
    {
        public FoodNutritionProfile()
        {
            CreateMap<FoodNutrition, FoodNutritionDTO>()
                .ForMember(dto =>
                dto.NutritionID,
                options => options.MapFrom(model => model.NutritionID))
                .ForMember(dto =>
                dto.NutritionName,
                options => options.MapFrom(model => model.Nutrition.Name))
                .ForMember(dto =>
                dto.Value,
                options => options.MapFrom(model => model.Value))
                .ForMember(dto =>
                dto.UnitID,
                options => options.MapFrom(model => model.UnitID))
                .ForMember(dto =>
                dto.UnitAbbreviation,
                options => options.MapFrom(model => model.Unit.Abbreviation))
                    .ReverseMap()
                        .ForAllOtherMembers(options => options.Ignore());
        }
    }
}
