using MediatR;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Repositories.Interfaces;

namespace OnlineStrore.Logic.Commands.Client.Delete
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand>
    {
        private IClientRepository clientRepository;
        private IContext context;
        public DeleteClientCommandHandler(IClientRepository _clientRepository, IContext _context)
            => (clientRepository, context) = (_clientRepository, _context);
        public async Task Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            await clientRepository.DeleteClientAsync(context, request.Id, cancellationToken);
        }
    }
}
