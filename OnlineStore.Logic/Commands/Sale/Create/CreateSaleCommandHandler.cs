using MediatR;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Repositories.Interfaces;

namespace OnlineStrore.Logic.Commands.Sale.Create
{
    public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, Guid>
    {
        private IContext context;
        private ISaleRepository saleRepository;

        public CreateSaleCommandHandler(ISaleRepository _saleRepository, IContext _context)
            => (context, saleRepository) = (_context, _saleRepository);

        public async Task<Guid> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            Guid id = await saleRepository.CreateSaleAsync(context, request, cancellationToken);
            return id;
        }
    }
}
