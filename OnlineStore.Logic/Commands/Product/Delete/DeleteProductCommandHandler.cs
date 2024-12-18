using MediatR;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Repositories.Interfaces;

namespace OnlineStrore.Logic.Commands.ProductNamespace.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private IContext context;
        private IProductRepository productRepository;

        public DeleteProductCommandHandler(IContext _context, IProductRepository _productRepository)
            => (context, productRepository) = (_context, _productRepository);

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await productRepository.DeleteProductAsync(context, request.Id, cancellationToken);
        }
    }
}
