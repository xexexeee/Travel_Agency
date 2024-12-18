using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStrore.Dto;
using OnlineStrore.Logic.Commands.ProductNamespace.Create;
using OnlineStrore.Logic.Commands.ProductNamespace.Delete;
using OnlineStrore.Logic.Commands.ProductNamespace.Update;
using OnlineStrore.Logic.Queries.Product.GetProduct;
using OnlineStrore.Logic.Queries.Product.GetProductList;

namespace OnlineStrore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Guid>> CreateProduct(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await mediator.Send(request, cancellationToken); 
            return Ok(product);
        }

        [HttpGet("allProducts")]
        public async Task<ActionResult<ProductListVm>> GetAllProducts(CancellationToken cancellationToken)
        {
            var products = await mediator.Send(new GetProductListQuery(),cancellationToken);
            return Ok(products);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Guid>> UpdateProduct(Guid id, UpdateProductDto productDto, CancellationToken cancellationToken)
        {
            var request = new UpdateProductCommand()
            {
                Id = id,
                Name = productDto.Name,
                Cost = productDto.Cost,
                CountOfProduct = productDto.CountOfProduct,
            };
            var productId = await mediator.Send(request, cancellationToken);
            return Ok(productId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await mediator.Send(request, cancellationToken);
            return Ok("Product has been deleted!");
        }

        [HttpGet("Catalog")]
        [ResponseCache(Duration = 60)]
        public async Task<ActionResult> Catalog(string TypeName, CancellationToken cancellationToken)
        {
            var query = new GetProductListQuery() { ProductTypeName = TypeName };
            var catalog = await mediator.Send(query, cancellationToken);

            var name = HttpContext.User.FindFirst("clientName")?.Value;
            ViewData["clientName"] = name;
            return View(catalog);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Details(Guid id, CancellationToken cancellationToken)
        {
            var request = new GetProductQuery() { Id = id };
            var product = await mediator.Send(request, cancellationToken);

            var name = HttpContext.User.FindFirst("clientName")?.Value;
            ViewData["clientName"] = name;
            return View(product);
        }
    }
}
