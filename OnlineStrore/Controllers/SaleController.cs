using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStrore.Dto;
using OnlineStrore.Logic.Commands.Sale.Create;
using OnlineStrore.Logic.Commands.Sale.Delete;
using OnlineStrore.Logic.Queries.Sale.GetSaleList;
using OnlineStrore.Logic.Queries.Sale.GetUserSale;

namespace OnlineStrore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly IMediator mediator;

        public SaleController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize]
        [HttpPost("createSale")]
        public async Task<ActionResult<Guid>> CreateSale(CreateSaleDto saleDto, CancellationToken cancellationToken)
        {
            bool res = Guid.TryParse(HttpContext.User.FindFirst("clientId")?.Value, out Guid id);
            if (!res)
                return BadRequest();
            var request = new CreateSaleCommand() { ClientId = id, TotalSum = saleDto.TotalSum, Products = saleDto.Products };
            var saleId = await mediator.Send(request, cancellationToken); 
            return Ok(saleId);
        }

        [Authorize]
        [HttpGet("allSales")]
        public async Task<ActionResult<SaleListVm>> GetAllUserSales(CancellationToken cancellationToken)
        {
            bool res = Guid.TryParse(HttpContext.User.FindFirst("clientId")?.Value, out Guid id);
            if (!res)
                return BadRequest();

            var query = new GetSaleListQuery() { UserId = id };
            var sales = await mediator.Send(query, cancellationToken);
            return Ok(sales);
        }

        [HttpDelete("deleteSale")]
        public async Task<IActionResult> DeleteSale(Guid id, CancellationToken cancellationToken)
        {
            var request = new DeleteSaleCommand() { Id  = id };
            await mediator.Send(request, cancellationToken);
            return Ok("Sale has been deleted!"); 
        }
    }
}
