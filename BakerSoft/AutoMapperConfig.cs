using AutoMapper;
using BakerSoft.Models;
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
                    config.CreateMap<PRODUCT_CATEGORY_MASTER, ProductCategory>().
                    ForMember(dest => dest.TaxId, opt => opt.MapFrom(src => src.CATEGORY_TAX_DEFINITION.)

                    config.CreateMap<Supplier, SUPPLIER>();
                    config.CreateMap<SUPPLIER, Supplier>();

                    config.CreateMap<Address, ADDRESS>();
                    config.CreateMap<ADDRESS, Address>();

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
