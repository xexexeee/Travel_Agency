using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.ProductType.Create
{
    public class CreateProductTypeCommand : IRequest <Guid>
    {
        public string Name { get; set; }
    }
    public class CreateProductTypeCommandValidator : AbstractValidator<CreateProductTypeCommand>
    {
        public CreateProductTypeCommandValidator()
        {
            RuleFor(CreateProductTypeCommand => CreateProductTypeCommand.Name).NotEmpty().WithMessage("Name field is required")
                .MaximumLength(255).WithMessage("Name field has maxLength 255");
        }
    }
}
