using FluentValidation;
using MediatR;
using OnlineStore.Logic.Repositories.Interfaces;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Logic.Commands.Cart
{
    public class DeleteFromCartCommand : IRequest
    {
        public Guid ClientId { get; set; }
        public Guid ProductId { get; set; }
    }
    public class DeleteFromCartCommandValidator : AbstractValidator<DeleteFromCartCommand>
    {
        public DeleteFromCartCommandValidator() 
        {
            RuleFor(del => del.ProductId).NotEmpty();
            RuleFor(del => del.ClientId).NotEmpty();
        }
    }
    public class DeleteFromCartCommandHandler : IRequestHandler<DeleteFromCartCommand>
    {
        private readonly IContext context;
        private readonly ICartRepository cartRepository;

        public DeleteFromCartCommandHandler(IContext context, ICartRepository cartRepository)
        {
            this.context = context;
            this.cartRepository = cartRepository;
        }

        public async Task Handle(DeleteFromCartCommand command, CancellationToken cancellationToken)
        {
            await cartRepository.DeleteFromCartAsync(context, command, cancellationToken); 
        }
    }
}
