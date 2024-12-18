using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;
using OnlineStore.Storage.MS_SQL;

namespace OnlineStrore.Logic.Commands.Sale.Create
{
    public class CreateSaleCommand : IRequest<Guid>
    {
        public Guid ClientId { get; set; }

        public double? TotalSum { get; set; }

        public ICollection<Product> Products { get; set; }
    }
    public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleCommandValidator()
        {
            RuleFor(CreateSaleCommand => CreateSaleCommand.ClientId).NotEqual(Guid.Empty).WithMessage("ClientId field is required");
            RuleFor(CreateSaleCommand => CreateSaleCommand.TotalSum).NotEmpty().WithMessage("Total sum field is required");
            RuleFor(create => create.Products).NotEmpty(); 
        }
    }
}
