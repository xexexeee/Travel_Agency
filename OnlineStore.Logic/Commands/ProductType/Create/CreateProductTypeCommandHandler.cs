using MediatR;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Repositories.Interfaces;

namespace OnlineStrore.Logic.Commands.ProductType.Create
{
    public class CreateProductTypeCommandHandler : IRequestHandler<CreateProductTypeCommand, Guid>
    {
        private IProductTypeRepository productTypeRepository;
        private IContext context;

        public CreateProductTypeCommandHandler(IProductTypeRepository productTypeRepository, IContext context)
        {
            this.productTypeRepository = productTypeRepository;
            this.context = context;
        }

        public async Task<Guid> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
        {
            Guid id = await productTypeRepository.CreateProductTypeAsync(context, request, cancellationToken);
            return id;
        }
    }
}
