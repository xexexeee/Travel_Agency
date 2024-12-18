using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Repositories.Interfaces;

namespace OnlineStrore.Logic.Queries.Client.GetClientList
{
    public class GetClientListQueryHandler : IRequestHandler<GetClientListQuery, ClientListVm>
    {
        private IClientRepository clientRepository;
        private IContext context;
        private IMapper mapper;

        public GetClientListQueryHandler(IClientRepository clientRepository, IContext context, IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ClientListVm> Handle(GetClientListQuery request, CancellationToken cancellationToken)
        {
            var clients = await clientRepository.GetAllClientsAsync(context, cancellationToken);

            var clientDtos = mapper.Map<List<ClientLookUpDto>>(clients);

            return new ClientListVm { Clients = clientDtos };
        }
    }
}
