
using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Commands.ProductType.Create;
using OnlineStrore.Logic.Commands.ProductType.Update;


namespace OnlineStrore.Logic.Repositories.Interfaces
{
    public interface IProductTypeRepository
    {
        Task<IEnumerable<ProductType>> GetAllProductTypesAsync(IContext context, CancellationToken cancellationToken);

        Task<ProductType> GetProductTypeAsync(IContext context, Guid id, CancellationToken cancellationToken);

        Task<Guid> CreateProductTypeAsync(IContext context, CreateProductTypeCommand request, CancellationToken cancellationToken);

        Task<Guid> UpdateProductTypeAsync(IContext context, UpdateProductTypeCommand request, CancellationToken cancellationToken);

        Task DeleteProductTypeAsync(IContext context, Guid id, CancellationToken cancellationToken);
    }
}
