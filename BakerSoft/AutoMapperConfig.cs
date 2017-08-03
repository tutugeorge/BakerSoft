using AutoMapper;
using DAL.Models;
using GSTBill.Models;

namespace BakerSoft
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(
                config =>
                {
                    config.CreateMap<Product, PRODUCT>()
                    .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.ProductDescription, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.ProductCategoryId, opt => opt.MapFrom(src => src.CategoryId))
                    .ForMember(dest => dest.ProductSearchId, opt => opt.MapFrom(src => src.SearchId))
                    .ForMember(dest => dest.ProductUoM, opt => opt.MapFrom(src => src.UoM))
                    .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.Type));
                });
        }
    }
}
