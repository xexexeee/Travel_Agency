using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.ProductNamespace.Update
{
    public class UpdateProductCommand : IRequest<Guid>
    {
        public Guid Id { get; set; } //По которому буду искать

        [MaxLength(255)]
        public string Name { get; set; }

        public double? Cost {  get; set; }
        public string Characteristics { get; set; }


        public uint? CountOfProduct {  get; set; }
    }
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator() 
        {
            RuleFor(UpdateProductCommand => UpdateProductCommand.Id).NotEqual(Guid.Empty).WithMessage("ProductId field is required");

            // Проверка, что хотя бы одно из полей заполнено
            RuleFor(command => command)
                .Must(command => !string.IsNullOrWhiteSpace(command.Name) ||
                                 !command.Cost.HasValue ||
                                 !command.CountOfProduct.HasValue ||
                                 !string.IsNullOrEmpty(command.Characteristics))
                .WithMessage("At least one of the fields (Name, Cost, CountOfProduct, Characteristics) must be provided.");
        }
    }
}
