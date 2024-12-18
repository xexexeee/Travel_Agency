using AutoMapper;
using MediatR;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Repositories.Interfaces;

namespace OnlineStrore.Logic.Queries.Product.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductVm>
    {
        private IProductRepository productRepository;
        private IContext context;
        private IMapper mapper;

        public GetProductQueryHandler(IProductRepository productRepository, IContext context, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<ProductVm> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetProductAsync(context, request.Id, cancellationToken);
            return mapper.Map<ProductVm>(product);  
        }
    }
}
