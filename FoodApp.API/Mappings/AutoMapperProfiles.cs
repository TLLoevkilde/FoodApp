using AutoMapper;
using FoodApp.API.Models.Domain;
using FoodApp.API.Models.DTO;

namespace FoodApp.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<FoodItem, FoodItemDto>().ReverseMap();

            CreateMap<CreateFoodItemDto, FoodItem>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ProteinPerWeightInGrams, opt => opt.Ignore())
            .ForMember(dest => dest.CalPerHundredGramsOfProtein, opt => opt.Ignore())
            .ForMember(dest => dest.PricePerHundredGramsOfProtein, opt => opt.Ignore())
            .ForMember(dest => dest.Score, opt => opt.Ignore());

            CreateMap<UpdateFoodItemDto, FoodItem>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ProteinPerWeightInGrams, opt => opt.Ignore())
            .ForMember(dest => dest.CalPerHundredGramsOfProtein, opt => opt.Ignore())
            .ForMember(dest => dest.PricePerHundredGramsOfProtein, opt => opt.Ignore())
            .ForMember(dest => dest.Score, opt => opt.Ignore());
        }
    }
}
