using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium.Interactions;
using ProyectoManhattan.Application;

namespace Eci.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private IReportRepo _repository { get; set; }
        private EciService _eciService { get; set; }
        private CookieGetter _cookieGetter { get; set; }
        private PdfEditor _pdfEditor { get; set; }

        public ReportController(IReportRepo repository, EciService eciService, CookieGetter cookieGetter, PdfEditor pdfEditor)
        {
            _repository = repository;
            _eciService = eciService;
            _cookieGetter = cookieGetter;
            _pdfEditor = pdfEditor;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _repository.Get(id));
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody]List<Brand> brands, string? reportName)
        {
            var httpClientHandler = new HttpClientHandler { CookieContainer = _cookieGetter.cookieContainer };
            var httpClient = new HttpClient(httpClientHandler); 

            var report = _eciService.CalculateReport(brands, httpClient);

            report.Base64Pdf = _pdfEditor.CreatePdf(report);
            
            if(!String.IsNullOrEmpty(reportName))
            {
                report.Name = reportName;
            }

            _repository.Create(report);
            
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody]Report report)
        {
            _repository.Update(report);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok();
        }
    }
}