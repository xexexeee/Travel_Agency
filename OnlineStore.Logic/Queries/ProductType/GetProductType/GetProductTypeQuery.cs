using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;
namespace OnlineStrore.Logic.Queries.ProductType.GetProductType
{
    public class GetProductTypeQuery : IRequest<ProductTypeVm>
    {
        public Guid Id { get; set; }
    }
    public class GetProductTypeQueryValidator : AbstractValidator<GetProductTypeQuery>
    {
        public GetProductTypeQueryValidator() 
        {
            RuleFor(get => get.Id).NotEqual(Guid.Empty).WithMessage("ProductTypeId field is required");
        }
    }
}
