using Domain.ValueTypes;
using Microsoft.AspNetCore.Mvc;
using ProyectoManhattan.Application;

namespace ProyectoManhattan.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebItemController : ControllerBase
    {
        private WebFetcher _webFetcher { get; set; }

        public WebItemController(WebFetcher webFetcher)
        {
            _webFetcher = webFetcher;
        }

        [HttpGet]
        [Route("GetItems")]
        public async Task<List<WebItem>> GetItems(string uneco, string brand, bool collectSameDay)
        {
            return await _webFetcher.GetItems(uneco, brand, collectSameDay);
        }
    }
}