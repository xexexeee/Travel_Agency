using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Queries.Product.GetProduct
{
    public class GetProductQuery : IRequest<ProductVm>
    {
        public Guid Id { get; set; }
    }
    public class GetProductQueryValidator : AbstractValidator<GetProductQuery>
    {
        public GetProductQueryValidator() 
        {
            RuleFor(get => get.Id).NotEqual(Guid.Empty).WithMessage("ProductId field is required");
        }
    }
}
