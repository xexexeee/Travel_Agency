using AutoMapper;
using MediatR;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Repositories.Interfaces;

namespace OnlineStrore.Logic.Queries.Client.GetClient
{
    public class GetClientQueryHandler : IRequestHandler<GetClientQuery, ClientVm>
    {
        private IClientRepository clientRepository;
        private IContext context;
        private IMapper mapper;

        public GetClientQueryHandler(IClientRepository clientRepository, IContext context, IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ClientVm> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var client = await clientRepository.GetClientAsync(context, request.Id, cancellationToken);
            return mapper.Map<ClientVm>(client);
        }
    }
}
