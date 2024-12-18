using FluentValidation;
using MediatR;

namespace OnlineStrore.Logic.Queries.Product.GetProductList
{
    public class GetProductListQuery : IRequest<ProductListVm>
    {
        public string ProductTypeName {  get; set; }
    }
    public class GetProductListQueryValidator: AbstractValidator<GetProductListQuery>
    {
        public GetProductListQueryValidator()
        {
            RuleFor(get => get.ProductTypeName).NotEmpty();
        }
    }
}
