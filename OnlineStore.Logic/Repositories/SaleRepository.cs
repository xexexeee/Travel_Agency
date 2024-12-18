using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Commands.Sale.Create;
using OnlineStrore.Logic.Exceptions;
using OnlineStrore.Logic.Repositories.Interfaces;

namespace OnlineStrore.Logic.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        public async Task<Guid> CreateSaleAsync(IContext context, CreateSaleCommand request, CancellationToken cancellationToken)
        {
            Guid id = Guid.NewGuid();
            var sale = new Sale()
            {
                Id = id,
                DateTime = DateTime.Now,
                ClientId = request.ClientId,
                TotalSum = request.TotalSum ?? 0,
                Products = request.Products
            };
            await context.Sales.AddAsync(sale, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return id;
        }

        public async Task DeleteSaleAsync(IContext context, Guid id, CancellationToken cancellationToken)
        {
            var sale = await context.Sales.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
            if (sale == null || sale.Id != id)
                throw new NotFoundException(id);
            context.Sales.Remove(sale);
            await context.SaveChangesAsync(cancellationToken); 
        }

        //Получить все покупки пользователя
        public async Task<IEnumerable<Sale>> GetAllSalesOfUserAsync(IContext context, Guid UserId, CancellationToken cancellationToken)
        {
            var sales = await context.Sales.Where(s => s.ClientId == UserId).ToListAsync(cancellationToken);
            if (sales.Count == 0)
                throw new NotFoundException();
            return sales;
        }

        //Получить последнюю покупку пользователя
        public async Task<Sale> GetSaleAsync(IContext context, Guid id, CancellationToken cancellationToken)
        {
            // Получаем последнюю покупку клиента с подгрузкой данных о клиенте (имени)
            var sale = await context.Sales
                .Where(s => s.ClientId == id) // Фильтруем покупки по идентификатору клиента
                .OrderByDescending(s => s.DateTime) // Сортируем по дате покупки, чтобы взять последнюю
                .FirstOrDefaultAsync(cancellationToken); // Получаем последнюю покупку
            if(context is Context _context)
                await _context.Entry(sale).Reference(s => s.Client).LoadAsync();
            else
                throw new InvalidOperationException("Invalid context type");
            if (sale == null || sale.Id != id)
                throw new NotFoundException(id);
            return sale;
        }

    }
}
