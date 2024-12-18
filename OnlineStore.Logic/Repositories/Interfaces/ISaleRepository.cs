using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Commands.Sale.Create;


namespace OnlineStrore.Logic.Repositories.Interfaces
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> GetAllSalesOfUserAsync(IContext context, Guid UserId, CancellationToken cancellationToken);
        Task<Sale> GetSaleAsync(IContext context, Guid id, CancellationToken cancellationToken);

        Task<Guid> CreateSaleAsync(IContext context, CreateSaleCommand request, CancellationToken cancellationToken);

        //Task<Guid> UpdateSaleAsync(IContext context, UpdateSaleCommand request, CancellationToken cancellationToken);

        Task DeleteSaleAsync(IContext context, Guid id, CancellationToken cancellationToken);
    }
}
