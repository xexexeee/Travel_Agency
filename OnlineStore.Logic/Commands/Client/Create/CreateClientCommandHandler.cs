using MediatR;
using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Repositories.Interfaces;

namespace OnlineStrore.Logic.Commands.Client.Create
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, string>
    {
        private IClientRepository clientRepository;
        private IContext context;
        public CreateClientCommandHandler(IClientRepository _clientRepository, IContext _context)
            => (clientRepository, context) = (_clientRepository, _context);

        public async Task<string> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var token = await clientRepository.CreateClientAsync(context, request, cancellationToken);
            return token;
        }
    }
}
