using OnlineStore.Logic.Commands.Cart;
using OnlineStore.Logic.Queries.Cart;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Queries.Product.GetProductList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Logic.Repositories.Interfaces
{
    public interface ICartRepository
    {
        public Task AddToCartAsync(IContext context, AddToCartCommand request, CancellationToken cancellationToken);
        public Task DeleteFromCartAsync(IContext context, DeleteFromCartCommand request, CancellationToken cancellationToken);

        public Task<int> GetCartCountAsync(IContext context, GetCartCountQuery request, CancellationToken cancellationToken);
        public Task<CartItemsVm> GetCartItemsAsync(IContext context, GetCartItemsQuery querry, CancellationToken cancellationToken);

        public Task CreateClientCartAsync(IContext context, Guid clientId, CancellationToken cancellationToken);
    }
}
