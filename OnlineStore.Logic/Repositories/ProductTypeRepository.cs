using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Commands.ProductType.Create;
using OnlineStrore.Logic.Commands.ProductType.Update;
using OnlineStrore.Logic.Exceptions;
using OnlineStrore.Logic.Repositories.Interfaces;

namespace OnlineStrore.Logic.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        public async Task<Guid> CreateProductTypeAsync(IContext context, CreateProductTypeCommand request, CancellationToken cancellationToken)
        {
            if (await context.ProductTypes.AnyAsync(p => p.Name == request.Name, cancellationToken))
                throw new AlreadyCreatedException();
            Guid id = Guid.NewGuid();
            var type = new ProductType
            {
                Id = id,
                Name = request.Name
            };
            await context.ProductTypes.AddAsync(type, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return id;
        }

        public async Task DeleteProductTypeAsync(IContext context, Guid id, CancellationToken cancellationToken)
        {
            var type = await context.ProductTypes.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
            if (type == null || type.Id != id)
                throw new NotFoundException(id);

            context.ProductTypes.Remove(type);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<ProductType>> GetAllProductTypesAsync(IContext context,CancellationToken cancellationToken)
        {
            var types = await context.ProductTypes.ToListAsync(cancellationToken);
            if (types.Count == 0)
                throw new NotFoundException();
            return types;
        }

        public async Task<ProductType> GetProductTypeAsync(IContext context, Guid id, CancellationToken cancellationToken)
        {
            var type = await context.ProductTypes.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
            if (type == null || type.Id != id)
                throw new NotFoundException(id);

            return type;
        }

        public async Task<Guid> UpdateProductTypeAsync(IContext context, UpdateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var type = await context.ProductTypes.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
            if (type == null || type.Id != request.Id)
                throw new NotFoundException(request.Id);

            type.Name = request.Name ?? type.Name;
            await context.SaveChangesAsync(cancellationToken);
            return type.Id;
        }
    }
}
