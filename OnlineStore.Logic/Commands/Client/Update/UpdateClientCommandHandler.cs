using MediatR;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Repositories.Interfaces;

namespace OnlineStrore.Logic.Commands.Client.Update
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Guid>
    {
        private IClientRepository clientRepository;
        private IContext context;
        public UpdateClientCommandHandler(IClientRepository _clientRepository, IContext _context)
            => (clientRepository, context) = (_clientRepository, _context);

        public async Task<Guid> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            Guid id = await clientRepository.UpdateClientAsync(context, request, cancellationToken);
            return id;
        }

    }
}
