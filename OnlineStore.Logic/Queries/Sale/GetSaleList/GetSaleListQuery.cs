using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;
namespace OnlineStrore.Logic.Queries.Sale.GetSaleList
{
    public class GetSaleListQuery : IRequest<SaleListVm>
    {
        [Required]
        public Guid UserId { get; set; }
    }
    public class GetSaleListQueryValidator : AbstractValidator<GetSaleListQuery>
    {
        public GetSaleListQueryValidator() 
        {
            RuleFor(get => get.UserId).NotEqual(Guid.Empty);
        }
    }

}
