using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.ProductType.Update
{
    public class UpdateProductTypeCommand : IRequest <Guid>
    {
        public Guid Id { get; set; } // По которому искать

        public string Name { get; set; }
    }
    public class UpdateProductTypeCommandValidator : AbstractValidator<UpdateProductTypeCommand>
    {
        public UpdateProductTypeCommandValidator()
        {
            RuleFor(UpdateProductTypeCommand => UpdateProductTypeCommand.Id).NotEqual(Guid.Empty).WithMessage("ProductTypeId field is required");
            RuleFor(UpdateProductTypeCommand => UpdateProductTypeCommand.Name).NotEmpty().WithMessage("Name field is required").MaximumLength(255)
                .WithMessage("Name field has maxLength 255");
        }
    }
}
