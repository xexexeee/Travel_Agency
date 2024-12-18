using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStrore.Dto;
using OnlineStrore.Logic.Commands.ProductNamespace.Update;
using OnlineStrore.Logic.Commands.ProductType.Create;
using OnlineStrore.Logic.Commands.ProductType.Delete;
using OnlineStrore.Logic.Commands.ProductType.Update;
using OnlineStrore.Logic.Queries.ProductType.GetProductType;
using OnlineStrore.Logic.Queries.ProductType.GetProductTypeList;

namespace OnlineStrore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductTypeController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductTypeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Guid>> CreateProductType(CreateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var typeId = await mediator.Send(request, cancellationToken);
            return Ok(typeId);
        }

        [HttpGet("allTypes")]
        public async Task<ActionResult<ProductTypeListVm>> GetAllProductTypes(CancellationToken cancellationToken)
        {
            var types = await mediator.Send(new GetProductTypeListQuery(), cancellationToken);

            return Ok(types);             
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTypeVm>> GetProductType(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetProductTypeQuery() { Id = id };
            var type = await mediator.Send(query, cancellationToken);

            return Ok(type);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Guid>> UpdateProductType(Guid id, UpdateProductTypeDto typeDto, CancellationToken cancellationToken)
        {
            var query = new UpdateProductTypeCommand()
            {
                Id = id,
                Name = typeDto.Name
            };
            var typeId = await mediator.Send(query, cancellationToken);
            return Ok(typeId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductType(Guid id, CancellationToken cancellationToken)
        {
            var request = new DeleteProductTypeCommand() { Id = id };
            await mediator.Send(request, cancellationToken);
            return Ok("Product type has been deleted!");
        }
    }
}
