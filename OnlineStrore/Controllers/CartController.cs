using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Logic.Commands.Cart;
using OnlineStore.Logic.Queries.Cart;
using OnlineStrore.Logic.Queries.Product.GetProduct;

namespace OnlineStrore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : Controller
    {
        private readonly IMediator mediator;

        public CartController(IMediator mediator) => this.mediator = mediator;

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] Guid productId, CancellationToken cancellationToken)
        {
            bool res = Guid.TryParse(HttpContext.User.FindFirst("clientId")?.Value, out Guid clientId);
            if (!res)
                return BadRequest();

            AddToCartCommand command = new AddToCartCommand()
            {
                ClientId = clientId,
                ProductId = productId
            };
            await mediator.Send(command, cancellationToken);

            return Ok();
        }

        [HttpGet(nameof(GetCartCount), Name = nameof(GetCartCount))]
        public async Task<ActionResult<int>> GetCartCount(CancellationToken cancellationToken)
        {
            bool res = Guid.TryParse(HttpContext.User.FindFirst("clientId")?.Value, out Guid clientId);
            if (!res)
                return BadRequest();

            var query = new GetCartCountQuery() { ClientId = clientId };
            var count = await mediator.Send(query, cancellationToken);

            return Ok(count);
        }

        [HttpGet(nameof(GetCartItems), Name = nameof(GetCartItems))]
        public async Task<ActionResult<CartItemsVm>> GetCartItems(CancellationToken cancellationToken)
        {
            bool res = Guid.TryParse(HttpContext.User.FindFirst("clientId")?.Value, out Guid clientId);
            if (!res)
                return BadRequest();

            var query = new GetCartItemsQuery() { ClientId = clientId };
            var cartItems = await mediator.Send(query, cancellationToken);

            return Ok(cartItems);
        }

        [HttpPost(nameof(DeleteProduct), Name = nameof(DeleteProduct))]
        public async Task<ActionResult<int>> DeleteProduct([FromBody] Guid productId, CancellationToken cancellationToken)
        {
            bool res = Guid.TryParse(HttpContext.User.FindFirst("clientId")?.Value, out Guid clientId);
            if (!res)
                return BadRequest();

            var command = new DeleteFromCartCommand() { ClientId= clientId, ProductId = productId};
            await mediator.Send(command, cancellationToken);
            return Ok();
        }
    }
}
