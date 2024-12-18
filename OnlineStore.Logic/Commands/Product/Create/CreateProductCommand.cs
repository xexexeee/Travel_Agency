using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.ProductNamespace.Create
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        public uint Cost { get; set; }

        public string Characteristics { get; set; }


        public uint CountOfProduct {  get; set; }

        public Guid ProductTypeId { get; set; }

    }
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator() 
        {
            RuleFor(CreateProductCommand => CreateProductCommand.Name).NotEmpty().WithMessage("Name field is required")
                .MaximumLength(255).WithMessage("Name field has maxLength 255");
            RuleFor(CreateProductCommand => CreateProductCommand.Cost).NotEmpty().WithMessage("Cost field is required");
            RuleFor(CreateProductCommand => CreateProductCommand.CountOfProduct).NotEmpty().WithMessage("Count of product field is required");

            RuleFor(CreateProductCommand => CreateProductCommand.ProductTypeId).NotEmpty().WithMessage("ProductTypeId field is required");
            RuleFor(create => create.Characteristics).NotEmpty().MaximumLength(400); 
        }
    }
}
