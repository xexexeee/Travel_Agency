using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Commands.ProductNamespace.Create;
using OnlineStrore.Logic.Commands.ProductNamespace.Update;
using OnlineStrore.Logic.Exceptions;
using OnlineStrore.Logic.Queries.ProductType.GetProductType;
using OnlineStrore.Logic.Repositories.Interfaces;

namespace OnlineStrore.Logic.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public async Task<Guid> CreateProductAsync(IContext context, CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (await context.Products.AnyAsync(p => p.Name == request.Name, cancellationToken))
                throw new AlreadyCreatedException();
            Guid id = Guid.NewGuid();
            await context.Products.AddAsync(new Product
            {
                Id = id,
                Name = request.Name,
                Cost = request.Cost,
                CountOfProduct = request.CountOfProduct,
                Characteristics = request.Characteristics,
                ProductTypeId = (Guid)request.ProductTypeId,
            }, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return id;
        }

        public async Task DeleteProductAsync(IContext context, Guid id, CancellationToken cancellationToken)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            if (product == null || product.Id != id)
                throw new NotFoundException();
            context.Products.Remove(product);

            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(IContext context, CancellationToken cancellationToken)
        {
            var products = await context.Products.Include(p => p.ProductType).ToListAsync(cancellationToken);
            if (products.Count == 0)
                throw new NotFoundException();
            return products;
        }

        public async Task<IEnumerable<Product>> GetAllProductsByTypeAsync(IContext context, string TypeName, CancellationToken cancellationToken)
        {
            var type= await context.ProductTypes.FirstOrDefaultAsync(t => t.Name == TypeName);
            if (type == null)
            {
                throw new NotFoundException();
            }
            var products = await context.Products.Where(p => p.ProductTypeId == type.Id).Include(p => p.ProductType).ToListAsync(cancellationToken);
            if (products.Count == 0)
                throw new NotFoundException();
            return products;
        }

        public async Task<Product> GetProductAsync(IContext context, Guid id, CancellationToken cancellationToken)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            if (context is Context _context)
                await _context.Entry(product).Reference(p => p.ProductType).LoadAsync(); 
            else
                throw new InvalidOperationException("Invalid context type");

            if (product == null || product.Id != id)
                throw new NotFoundException();
            return product;
        }

        public async Task<Guid> UpdateProductAsync(IContext context, UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (product == null || product.Id != request.Id)
                throw new NotFoundException();
            
            product.Name = request.Name ?? product.Name;
            product.Cost = request.Cost ?? product.Cost;
            product.CountOfProduct = request.CountOfProduct ?? product.CountOfProduct;
            product.Characteristics = request.Characteristics ?? product.Characteristics;

            await context.SaveChangesAsync(cancellationToken);
            return product.Id; 
        }
    }
}
