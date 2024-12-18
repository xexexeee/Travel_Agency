using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Logic.Queries.Search;

namespace OnlineStrore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : Controller
    {
        private readonly IMediator mediator;

        public SearchController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet(nameof(SearchRoute), Name = nameof(SearchRoute))]
        public IActionResult SearchRoute(string query, CancellationToken cancellationToken)
        {
            var Searchquery = new SearchQuery() { searchText = query };
            var resultOfSearch = mediator.Send(Searchquery, cancellationToken).Result;

            return Json(resultOfSearch);
        }
    }
}
