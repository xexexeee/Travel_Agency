using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.ProductNamespace.Delete
{
    public class DeleteProductCommand : IRequest
    {
        public Guid Id { get; set; }
    }
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator() 
        {
            RuleFor(DeleteProductCommand => DeleteProductCommand.Id).NotEqual(Guid.Empty).WithMessage("ProductId field is required");
        }
    }
}
