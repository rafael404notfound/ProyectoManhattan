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
        private IWebHostEnvironment _environment;

        public WebItemController(WebFetcher webFetcher, IWebHostEnvironment environment)
        {
            _webFetcher = webFetcher;
            _environment = environment;
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
            var path = Path.Combine(_environment.WebRootPath , "content/video.mp4");
            Console.WriteLine(path);

            using (var file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await file.CopyToAsync(memory);
            }

            memory.Position = 0;
            var ext = Path.GetExtension(path).ToLowerInvariant();
            

            return File(memory, "video/mp4", $"PalRamiro");
        }
    }
}