using AutoMapper;
using OnlineStore.Storage.MS_SQL;
using OnlineStrore.Logic.Queries.Client.GetClient;
using OnlineStrore.Logic.Queries.Client.GetClientList;


namespace OnlineStrore.Logic.Mappers.ClientMap
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<Client, ClientLookUpDto>()
                .ForMember(c => c.Id,
                src => src.MapFrom(c => c.Id));

            CreateMap<Client, ClientVm>()
                .ForMember(c => c.Name,
                src => src.MapFrom(c => c.Name))
                .ForMember(c => c.Email,
                src => src.MapFrom(c => c.Email))
                .ForMember(c => c.PhoneNumber,
                src => src.MapFrom(src => src.PhoneNumber));

        }
    }
}
