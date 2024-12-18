using AutoMapper;
using MediatR;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Repositories.Interfaces;

namespace OnlineStrore.Logic.Queries.Sale.GetSaleList
{
    public class GetSaleListQueryHandler : IRequestHandler<GetSaleListQuery, SaleListVm>
    {
        private ISaleRepository saleRepository;
        private IContext context;
        private IMapper mapper;

        public GetSaleListQueryHandler(ISaleRepository saleRepository, IContext context, IMapper mapper)
        {
            this.saleRepository = saleRepository;
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<SaleListVm> Handle (GetSaleListQuery query, CancellationToken cancellationToken)
        {
            var sales = await saleRepository.GetAllSalesOfUserAsync(context, query.UserId, cancellationToken);
            var saleDtos = mapper.Map<List<SaleLookUpDto>>(sales);

            return new SaleListVm { Sales = saleDtos };
        }
    }
}
