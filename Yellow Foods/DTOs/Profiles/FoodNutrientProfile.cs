using AutoMapper;
using Yellow_Foods.Models;

namespace Yellow_Foods.DTOs.Profiles
{
    public class FoodNutrientProfile : Profile
    {
        public FoodNutrientProfile()
        {
            CreateMap<FoodNutrient, FoodNutrientDTO>()
                .ForMember(dto =>
                dto.NutrientID,
                options => options.MapFrom(model => model.NutrientID))
                .ForMember(dto =>
                dto.NutrientName,
                options => options.MapFrom(model => model.Nutrient.Name))
                .ForMember(dto =>
                dto.Amount,
                options => options.MapFrom(model => model.Amount))
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
