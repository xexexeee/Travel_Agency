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
    public class GetCartCountQuery : IRequest<int>
    {
        public Guid ClientId { get; set; }
    }
    public class GetCartCountQueryValidator : AbstractValidator<GetCartCountQuery>
    {
        public GetCartCountQueryValidator()
        { 
            RuleFor(get => get.ClientId).NotEmpty();
        }
    }
    public class GetCartCountQueryHandler : IRequestHandler<GetCartCountQuery, int>
    {
        private readonly IContext context;
        private readonly ICartRepository cartRepository;

        public GetCartCountQueryHandler(IContext context, ICartRepository cartRepository)
        {
            this.context = context;
            this.cartRepository = cartRepository;
        }

        public async Task<int> Handle(GetCartCountQuery request, CancellationToken cancellationToken)
        {
            var countOfProduct = await cartRepository.GetCartCountAsync(context, request, cancellationToken);

            return countOfProduct;
        }
    }
}
