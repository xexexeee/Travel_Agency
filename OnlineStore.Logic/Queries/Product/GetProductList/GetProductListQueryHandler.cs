using AutoMapper;
using MediatR;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Repositories.Interfaces;

namespace OnlineStrore.Logic.Queries.Product.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, ProductListVm>
    {
        private IProductRepository productRepository;
        private IContext context;
        private IMapper mapper;

        public GetProductListQueryHandler(IProductRepository productRepository, IContext context, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ProductListVm> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAllProductsByTypeAsync(context, request.ProductTypeName, cancellationToken);

            var productDtos = mapper.Map<List<ProductLookUpDto>>(products);
            return new ProductListVm { Products = productDtos };
        }
    }
}
