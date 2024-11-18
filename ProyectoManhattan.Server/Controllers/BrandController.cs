using Microsoft.AspNetCore.Mvc;
using ProyectoManhattan.Application;
using Domain.Entities;
using Domain.Dto;
using Domain.ValueTypes;


namespace EciApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : ControllerBase 
    {
        private IApplicationRepo _applicationRepo { get; set; }
        private IJwtGetter _cookieGetter { get; set; }
        private EciService _eciService { get; set; }

        public BrandController(IApplicationRepo applicationRepo, IJwtGetter cookieGetter, EciService eciService)
        {
            _applicationRepo = applicationRepo;
            _cookieGetter = cookieGetter;
            _eciService = eciService;
        }

        [HttpGet()]
        [Route("GetBrands")]
        public IEnumerable<Brand> GetBrands()
        {
            return _applicationRepo.GetAllWithoutIncludes();
        }  
        [HttpGet()]
        [Route("GetBrandsWithIncludes")]
        public IEnumerable<Brand> GetGrandsWithIncludes()
        {
            return _applicationRepo.GetAll();
        } 

		[HttpGet()]
		[Route("GetBrand")]
		public async Task<Brand> GetBrand(string brand)
		{
            return await _applicationRepo.Get(brand);
		}

        [HttpDelete()]
        public IActionResult DeleteBrand(int id)
        {
            _applicationRepo.Delete(id);
            return Ok();
        }  

        [HttpPut()]
        public async Task<IActionResult> UpdateBrand(Brand brand)
        {
            await _applicationRepo.Update(brand);
            return Ok();
        }  

        
        [HttpPost()]
        [Route("GroupIntoBrands")]

        public async Task<IActionResult> GroupIntoBrands([FromBody] List<EanAndUnecoDto> eanAndUnecoDtos)
        {
            var handler = new HttpClientHandler { CookieContainer = _cookieGetter.cookieContainer };
            HttpClient httpClient = new HttpClient(handler);

            List<Shoe> shoes = new List<Shoe>();
            Shoe shoe = new Shoe();

            List<Task<ShoeOrErrorDto>> tasks = new List<Task<ShoeOrErrorDto>>();
            foreach (var eanAndUnecoDto in eanAndUnecoDtos)
            {
                tasks.Add(_eciService.GetShoeByEan(eanAndUnecoDto.Ean, httpClient, eanAndUnecoDto.Uneco));
            }
            var results = await Task.WhenAll(tasks.ToArray());
            shoes.AddRange(results.Where(sOE => sOE.Shoe is not null).Select(sOE => sOE.Shoe));

            List<ShoeModel> scannedShoeModels = await _eciService.GroupShoesInToShoeModels(shoes, httpClient);

            var groups = scannedShoeModels.GroupBy(x => x.BrandSapName);

            List<Brand> brands = new List<Brand>();

            foreach(var group in groups)
            {
                brands.Add(new Brand
                {
                    SapName = group.Key,
                    ShoeModels = scannedShoeModels.Where(s => s.BrandSapName == group.Key).ToList(),
                });
            }

            return Ok(brands);
        }

        // TODO: throw error when trying to add a shoe which brand doesnt exist in db
        [HttpPost()]
        [Route("StockChange")]
        
        public async Task<IActionResult> StockChange([FromBody] StockChangeDto stockChangeDto)
        {
            var handler = new HttpClientHandler { CookieContainer = _cookieGetter.cookieContainer };
            HttpClient httpClient = new HttpClient(handler);

            List<Shoe> shoes = new List<Shoe>();
            Shoe shoe = new Shoe();

            List<Task<ShoeOrErrorDto>> tasks = new List<Task<ShoeOrErrorDto>>();
            foreach (var eanAndUnecoDto in stockChangeDto.EanAndUnecoDtos)
            {
                tasks.Add(_eciService.GetShoeByEan(eanAndUnecoDto.Ean, httpClient, eanAndUnecoDto.Uneco));
            }
            var results = await Task.WhenAll(tasks.ToArray());
            shoes.AddRange(results.Where(sOE => sOE.Shoe is not null).Select(sOE => sOE.Shoe));

            List<ShoeModel> scannedShoeModels = await _eciService.GroupShoesInToShoeModels(shoes, httpClient);

            var groups = scannedShoeModels.GroupBy(x => x.BrandSapName);

            List<Brand> brands = new List<Brand>();

            foreach(var group in groups)
            {
                brands.Add(new Brand
                {
                    SapName = group.Key,
                    ShoeModels = scannedShoeModels.Where(s => s.BrandSapName == group.Key).ToList(),
                });
            }
            
            foreach(var brand in brands)
            {
                await _applicationRepo.Operate(brand, stockChangeDto.Operation);
            }  

            return Ok();
        }

        [HttpPost()]
        [Route("Stocktake")]

        public async Task<IActionResult> Stocktake([FromBody] StocktakeDto stocktakeDto)
        {
            var handler = new HttpClientHandler { CookieContainer = _cookieGetter.cookieContainer };
            HttpClient httpClient = new HttpClient(handler);

            List<Shoe> shoes = new List<Shoe>();
            Shoe shoe = new Shoe();

            List<Task<ShoeOrErrorDto>> tasks = new List<Task<ShoeOrErrorDto>>();
            foreach (var eanAndUnecoDto in stocktakeDto.eanAndUnecoDtos)
            {
                tasks.Add(_eciService.GetShoeByEan(eanAndUnecoDto.Ean, httpClient, eanAndUnecoDto.Uneco));
            }
            var results = await Task.WhenAll(tasks.ToArray());
            StocktakeResultDto result = new StocktakeResultDto()
            {
                Errors = results.Where(sOE => sOE.Error is not null).Select(sOE => sOE.Error).ToList()
            };
            shoes.AddRange(results.Where(sOE => sOE.Shoe is not null).Select(sOE => sOE.Shoe));

            List<ShoeModel> scannedShoeModels = await _eciService.GroupShoesInToShoeModels(shoes, httpClient);

            var groups = scannedShoeModels.GroupBy(x => x.BrandSapName);

            List<Brand> brands = new List<Brand>();

            foreach (var group in groups)
            {
                brands.Add(new Brand
                {
                    SapName = group.Key,
                    ShoeModels = scannedShoeModels.Where(s => s.BrandSapName == group.Key).ToList(),
                });
            }

            if(brands.Count > 1) return StatusCode(500);

            brands.First().DisplayName = stocktakeDto.Name;
            brands.First().Uneco = stocktakeDto.Uneco;
            _applicationRepo.Create(brands.First());
            result.Brand = brands.First();

            return Ok(result);
        }

        [HttpGet]
        [Route("SetCookies")]
        public async Task<IActionResult> SetCookies()
        {
            await _cookieGetter.SetCookies();
            return Ok();
        }
    }
}