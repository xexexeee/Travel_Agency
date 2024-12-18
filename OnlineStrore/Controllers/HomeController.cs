
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Logic.Queries.Search;
using OnlineStore.Storage.MS_SQL.Entities;
using OnlineStrore.Logic.Queries.Client.GetClient;
using OnlineStrore.Logic.Queries.Product.GetProduct;
using OnlineStrore.Logic.Queries.Product.GetProductList;
using OnlineStrore.ViewModels;


namespace OnlineStrore.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : Controller
    {
        private readonly IMediator mediator;

        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            //var name = HttpContext.User.FindFirst("clientName")?.Value;
            //return View(new ClientView() { Name = name});
            var name = HttpContext.User.FindFirst("clientName")?.Value;
            ViewData["clientName"] = name;
            return View();
        }

        [HttpGet("Sale")]
        public async Task<ActionResult> Sale()
        {
            //var name = HttpContext.User.FindFirst("clientName")?.Value;
            //return View(new ClientView() { Name = name });
            var name = HttpContext.User.FindFirst("clientName")?.Value;
            ViewData["clientName"] = name;
            return View();
        }

        [HttpGet("News")]
        public async Task<ActionResult> News()
        {
            //var name = HttpContext.User.FindFirst("clientName")?.Value;
            //return View(new ClientView() { Name = name });
            var name = HttpContext.User.FindFirst("clientName")?.Value;
            ViewData["clientName"] = name;
            return View();
        }

        [HttpGet("Contact")]
        public async Task<ActionResult> Contact()
        {
            //var name = HttpContext.User.FindFirst("clientName")?.Value;
            //return View(new ClientView() { Name = name });
            var name = HttpContext.User.FindFirst("clientName")?.Value;
            ViewData["clientName"] = name;
            return View();
        }

      
        

    }
}
