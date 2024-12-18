using AutoMapper;
using OnlineStore.Storage.MS_SQL;
using OnlineStrore.Logic.Queries.Product.GetProduct;
using OnlineStrore.Logic.Queries.Product.GetProductList;


namespace OnlineStrore.Logic.Mappers.ProductMap
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductVm>()
                .ForMember(p => p.Id,
                src => src.MapFrom(src => src.Id))
                .ForMember(p => p.Name,
                src => src.MapFrom(src => src.Name))
                .ForMember(p => p.Cost,
                src => src.MapFrom(src => src.Cost))
                .ForMember(p => p.CountOfProduct,
                src => src.MapFrom(src => src.CountOfProduct))
                .ForMember(p => p.ProductTypeName,
                src => src.MapFrom(src => src.ProductType.Name))
                .ForMember(p => p.Characteristics, 
                src => src.MapFrom(p => p.Characteristics))
                .ForMember(p => p.ImageUrl,
                src => src.MapFrom(p => p.ImageUrl));

            CreateMap<Product, ProductLookUpDto>()
                .ForMember(p => p.Id,
                src => src.MapFrom(src => src.Id))
                .ForMember(p => p.Name, 
                src => src.MapFrom(src => src.Name))
                .ForMember(p => p.Characteristics,
                src => src.MapFrom(src => src.Characteristics))
                .ForMember(p => p.Cost,
                src => src.MapFrom(src => src.Cost))
                .ForMember(p => p.CountOfProduct,
                src => src.MapFrom(src => src.CountOfProduct))
                .ForMember(p => p.ProductTypeName,
                src => src.MapFrom(src => src.ProductType.Name))
                .ForMember(p => p.ImageUrl,
                src => src.MapFrom(p => p.ImageUrl));

        }
    }
}
