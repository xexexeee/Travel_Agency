using AutoMapper;
using MediatR;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Repositories.Interfaces;

namespace OnlineStrore.Logic.Queries.ProductType.GetProductType
{
    public class GetProductTypeQueryHandler : IRequestHandler<GetProductTypeQuery, ProductTypeVm>
    {
        private IProductTypeRepository productTypeRepository;
        private IContext context;
        private IMapper mapper;

        public GetProductTypeQueryHandler(IProductTypeRepository productTypeRepository, IContext context, IMapper mapper)
        {
            this.productTypeRepository = productTypeRepository;
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ProductTypeVm> Handle (GetProductTypeQuery query, CancellationToken cancellationToken)
        {
            var productType = await productTypeRepository.GetProductTypeAsync(context, query.Id, cancellationToken);
            return mapper.Map<ProductTypeVm>(productType);
        }
    }
}
