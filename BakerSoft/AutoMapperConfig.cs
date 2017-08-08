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
                    config.CreateMap<Product, PRODUCT>();
                    config.CreateMap<PRODUCT, Product>();
                    //.ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                    //.ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
                    //.ForMember(dest => dest.ProductDescription, opt => opt.MapFrom(src => src.ProductDescription))
                    //.ForMember(dest => dest.ProductCategoryId, opt => opt.MapFrom(src => src.ProductCategoryId))
                    //.ForMember(dest => dest.ProductSearchId, opt => opt.MapFrom(src => src.ProductSearchId))
                    //.ForMember(dest => dest.ProductUoM, opt => opt.MapFrom(src => src.ProductUoM))
                    //.ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType));
                });
        }
    }
}
