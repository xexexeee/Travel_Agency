using FluentValidation;
using MediatR;
using OnlineStore.Logic.Repositories.Interfaces;
using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Logic.Commands.Cart
{
    public class AddToCartCommand : IRequest
    {
        public Guid ClientId { get; set; }
        public Guid ProductId { get; set; }
    }
    public class AddToCartCommandValidator : AbstractValidator<AddToCartCommand>
    {
        public AddToCartCommandValidator() 
        {
            RuleFor(add => add.ClientId).NotEmpty();
            RuleFor(add => add.ProductId).NotEmpty();
        }
    }
    
    public class AddCartCommandHandler : IRequestHandler<AddToCartCommand>
    {
        private readonly IContext context;
        private readonly ICartRepository cartRepository;

        public AddCartCommandHandler(IContext context, ICartRepository cartRepository)
        {
            this.context = context;
            this.cartRepository = cartRepository;
        }

        public async Task Handle(AddToCartCommand command, CancellationToken cancellationToken)
        {
            await cartRepository.AddToCartAsync(context, command, cancellationToken);            
        }
    }
}
