using MediatR;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Repositories.Interfaces;

namespace OnlineStrore.Logic.Commands.ProductType.Delete
{
    public class DeleteProductTypeCommandHandler : IRequestHandler<DeleteProductTypeCommand>
    {
        private IProductTypeRepository productTypeRepository;
        private IContext context;

        public DeleteProductTypeCommandHandler(IProductTypeRepository productTypeRepository, IContext context)
        {
            this.productTypeRepository = productTypeRepository;
            this.context = context;
        }

        public async Task Handle (DeleteProductTypeCommand request, CancellationToken cancellationToken)
        {
            await productTypeRepository.DeleteProductTypeAsync(context, request.Id, cancellationToken);
        }
    }
}
