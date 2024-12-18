using MediatR;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Repositories.Interfaces;

namespace OnlineStrore.Logic.Commands.ProductNamespace.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Guid>
    {
        private IContext context;
        private IProductRepository productRepository;

        public UpdateProductCommandHandler(IContext _context, IProductRepository _productRepository)
            => (context, productRepository) = (_context, _productRepository);

        public async Task<Guid> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Guid id = await productRepository.UpdateProductAsync(context, request, cancellationToken);
            return id;
        }
    }
}
