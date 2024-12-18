using FluentValidation;
using MediatR;
using OnlineStore.Logic.Repositories.Interfaces;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Logic.Queries.Cart
{
    public class CartItemsVm
    {
        public List<CartProductVm> products { get; set; }
        public double endCost { get; set; }
    }
    public class CartProductVm
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int СountOfProduct { get; set; }
        public double Сost { get; set; }
        public string ImageUrl { get; set; }
    }
    public class GetCartItemsQuery : IRequest<CartItemsVm>
    {
        public Guid ClientId {  get; set; }
    }
    public class GetCartItemsQueryValidator : AbstractValidator<GetCartItemsQuery>
    {
        public GetCartItemsQueryValidator() 
        {
            RuleFor(g => g.ClientId).NotEmpty();
        }
    }
    public class GetCartItemsQueryHandler : IRequestHandler<GetCartItemsQuery, CartItemsVm> 
    {
        private readonly IContext context;
        private readonly ICartRepository cartRepository;

        public GetCartItemsQueryHandler(IContext context, ICartRepository cartRepository)
        {
            this.context = context;
            this.cartRepository = cartRepository;
        }

        public async Task<CartItemsVm> Handle(GetCartItemsQuery query, CancellationToken cancellationToken)
        {
            var items = await cartRepository.GetCartItemsAsync(context, query, cancellationToken);
            return items;
        }
    }
}
