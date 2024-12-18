using AutoMapper;
using OnlineStore.Storage.MS_SQL;
using OnlineStrore.Logic.Queries.ProductType.GetProductType;
using OnlineStrore.Logic.Queries.ProductType.GetProductTypeList;


namespace OnlineStrore.Logic.Mappers.ProductTypeMap
{
    public class ProductTypeMappingProfile : Profile
    {
        public ProductTypeMappingProfile()
        {
            CreateMap<ProductType, ProductTypeVm>()
                .ForMember(t => t.Name,
                src => src.MapFrom(src => src.Name))
                .ForMember(t => t.Id,
                src => src.MapFrom(src => src.Id));

            CreateMap<ProductType, ProductTypeLookUpDto>()
                .ForMember(t => t.Id,
                src => src.MapFrom(src => src.Id))
                .ForMember(t => t.Name,
                src => src.MapFrom(t => t.Name)); 
        }
    }
}
