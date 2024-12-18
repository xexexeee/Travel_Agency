using AutoMapper;
using MediatR;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Repositories.Interfaces;

namespace OnlineStrore.Logic.Queries.ProductType.GetProductTypeList
{
    public class GetProductTypeListQueryHandler : IRequestHandler<GetProductTypeListQuery, ProductTypeListVm>
    {
        private IProductTypeRepository productTypeRepository;
        private IContext context;
        private IMapper mapper;

        public GetProductTypeListQueryHandler(IProductTypeRepository productTypeRepository, IContext context, IMapper mapper)
        {
            this.productTypeRepository = productTypeRepository;
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<ProductTypeListVm> Handle (GetProductTypeListQuery query, CancellationToken cancellationToken)
        {
            var types = await productTypeRepository.GetAllProductTypesAsync(context, cancellationToken);
            var typeDtos = mapper.Map<List<ProductTypeLookUpDto>>(types);

            return new ProductTypeListVm { ProductTypes = typeDtos };
        }
    }
}
