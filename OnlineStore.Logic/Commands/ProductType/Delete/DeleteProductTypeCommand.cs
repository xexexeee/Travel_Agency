using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.ProductType.Delete
{
    public class DeleteProductTypeCommand : IRequest 
    {
        [Required]
        public Guid Id { get; set; }
    }
    public class DeleteProductTypeCommandValidator : AbstractValidator<DeleteProductTypeCommand>
    {
        public DeleteProductTypeCommandValidator() 
        {
            RuleFor(DeleteProductTypeCommand => DeleteProductTypeCommand.Id).NotEqual(Guid.Empty).WithMessage("ProductTypeId field is required");
        }
    }
}
