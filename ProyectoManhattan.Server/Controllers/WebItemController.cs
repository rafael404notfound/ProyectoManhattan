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

        [HttpGet]
        [Route("GetVideo")]
        public async Task<ActionResult> GetVideo()
        {
            var memory = new MemoryStream();

            using (var file = new FileStream("content/video.mp4", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await file.CopyToAsync(memory);
            }

            memory.Position = 0;
            var ext = Path.GetExtension("content/video.mp4").ToLowerInvariant();

            return File(memory, "video/mp4", $"PalRamiro");
        }
    }
}