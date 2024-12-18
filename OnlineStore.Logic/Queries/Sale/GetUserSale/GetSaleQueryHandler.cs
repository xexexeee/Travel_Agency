using AutoMapper;
using MediatR;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Repositories.Interfaces;

namespace OnlineStrore.Logic.Queries.Sale.GetUserSale
{
    public class GetSaleQueryHandler : IRequestHandler <GetSaleQuery, SaleVm>
    {
        private ISaleRepository saleRepository;
        private IContext context;
        private IMapper mapper;

        public GetSaleQueryHandler(ISaleRepository saleRepository, IContext context, IMapper mapper)
        {
            this.saleRepository = saleRepository;
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<SaleVm> Handle(GetSaleQuery query, CancellationToken cancellationToken)
        {
            var sale = await saleRepository.GetSaleAsync(context, query.UserId, cancellationToken);
            
            return mapper.Map<SaleVm>(sale); 
        }
    }
}
