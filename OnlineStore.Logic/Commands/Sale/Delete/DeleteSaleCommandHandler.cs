using MediatR;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Repositories.Interfaces;

namespace OnlineStrore.Logic.Commands.Sale.Delete
{
    public class DeleteSaleCommandHandler : IRequestHandler<DeleteSaleCommand>
    {
        private IContext context;
        private ISaleRepository saleRepository;

        public DeleteSaleCommandHandler(ISaleRepository _saleRepository, IContext _context)
            => (context, saleRepository) = (_context, _saleRepository);

        public async Task Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
        {
            await saleRepository.DeleteSaleAsync(context, request.Id, cancellationToken);
        }
    }
}
