using AutoMapper;
using OnlineStore.Storage.MS_SQL;
using OnlineStrore.Logic.Queries.Sale.GetSaleList;
using OnlineStrore.Logic.Queries.Sale.GetUserSale;

namespace OnlineStrore.Logic.Mappers.SaleMap
{
    public class SaleMappingProfile : Profile
    {
        public SaleMappingProfile()
        {
            CreateMap<Sale, SaleVm>()
                .ForMember(s => s.UserName,
                src => src.MapFrom(src => src.Client.Name))
                .ForMember(s => s.TotalSum,
                src => src.MapFrom(src => src.TotalSum))
                .ForMember(s => s.DateTime,
                src => src.MapFrom(src => src.DateTime));

            CreateMap<Sale, SaleLookUpDto>()
                .ForMember(s => s.Id,
                src => src.MapFrom(src => src.Id)); 
        }
    }
}
