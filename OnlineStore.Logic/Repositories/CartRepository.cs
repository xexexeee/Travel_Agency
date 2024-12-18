using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Logic.Commands.Cart;
using OnlineStore.Logic.Queries.Cart;
using OnlineStore.Logic.Repositories.Interfaces;
using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStore.Storage.MS_SQL.Entities;
using OnlineStrore.Logic.Queries.Product.GetProductList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Logic.Repositories
{
    public class CartRepository : ICartRepository
    {
        public async Task AddToCartAsync(IContext context, AddToCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await context.Carts.FirstOrDefaultAsync(c => c.ClientId == request.ClientId, cancellationToken);
            if (cart == null)
                throw new ArgumentException("Cart wasn't created for client");
            
            var cartToProd = await context.CartToProducts.FirstOrDefaultAsync(c => c.CartId == cart.CartId && c.ProductId == request.ProductId);
            if (cartToProd == null)
            {
                await context.CartToProducts.AddAsync(new CartToProduct() { CartId = cart.CartId, ProductId = request.ProductId, ProductCount = 1 });
            }
            else
            {
                cartToProd.ProductCount += 1;
            }
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> GetCartCountAsync(IContext context, GetCartCountQuery request, CancellationToken cancellationToken)
        {
            var cart = await context.Carts.FirstOrDefaultAsync(c => c.ClientId == request.ClientId, cancellationToken);
            if (cart == null)
                throw new ArgumentException("Cart wasn't created for client");

            var cartToProd = await context.CartToProducts.FirstOrDefaultAsync(c => c.CartId == cart.CartId);
            if (cartToProd == null)
                return 0;
            else
            {
                var countOfProducts = context.CartToProducts.Where(c => c.CartId == cart.CartId).Sum(c => c.ProductCount);
                return countOfProducts;
            }         
        }

        public async Task CreateClientCartAsync(IContext context, Guid clientId, CancellationToken cancellationToken)
        {
            var cart = new Cart() { CartId = Guid.NewGuid(), ClientId = clientId, Products = new List<Product>() };

            await context.Carts.AddAsync(cart, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteFromCartAsync(IContext context, DeleteFromCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await context.Carts.FirstOrDefaultAsync(c => c.ClientId == request.ClientId, cancellationToken);
            if (cart == null)
                throw new ArgumentException("Cart wasn't created for client");

            var cartToProd = await context.CartToProducts.FirstOrDefaultAsync(c => c.CartId == cart.CartId && c.ProductId == request.ProductId);
            if (cartToProd == null)
            {
                throw new ArgumentException("Cart is empty");
            }
            else
            {
                if(cartToProd.ProductCount > 1)
                    cartToProd.ProductCount--;
                else if(cartToProd.ProductCount == 1)
                    context.CartToProducts.Remove(cartToProd);
            }
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<CartItemsVm> GetCartItemsAsync(IContext context, GetCartItemsQuery querry, CancellationToken cancellationToken)
        {
            var cart = await context.Carts.FirstOrDefaultAsync(c => c.ClientId == querry.ClientId, cancellationToken);
            if (cart == null)
                throw new ArgumentException("Cart wasn't created for client");

            var cartItems = await context.CartToProducts.Where(c => c.CartId == cart.CartId).ToListAsync(cancellationToken);

            // Получаем список продуктов из таблицы Products по их Id
            var productIds = cartItems.Select(item => item.ProductId).Distinct().ToList();
            var products = await context.Products
                                         .Where(p => productIds.Contains(p.Id))
                                         .ToListAsync(cancellationToken);
            // Собираем данные в список CartProductVm
            var cartProductVms = cartItems
                .Join(products,
                      cartItem => cartItem.ProductId,
                      product => product.Id,
                      (cartItem, product) => new CartProductVm
                      {
                          ProductId = cartItem.ProductId,
                          ProductName = product.Name,
                          Сost = product.Cost,
                          СountOfProduct = cartItem.ProductCount,
                          ImageUrl = product.ImageUrl
                      })
                .ToList();

            CartItemsVm cartItemsVm = new CartItemsVm() { products = cartProductVms, endCost = cartProductVms.Sum(c => c.Сost * c.СountOfProduct) };

            return cartItemsVm;
        }
    }
}
