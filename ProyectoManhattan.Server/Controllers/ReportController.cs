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
        private IJwtGetter _cookieGetter { get; set; }
        private PdfEditor _pdfEditor { get; set; }
        private PendingReportQueue _pendingReportQeue { get; set; }

        public ReportController(IReportRepo repository, EciService eciService, IJwtGetter cookieGetter, PdfEditor pdfEditor, PendingReportQueue pendingReportQeue)
        {
            _repository = repository;
            _eciService = eciService;
            _cookieGetter = cookieGetter;
            _pdfEditor = pdfEditor;
            _pendingReportQeue = pendingReportQeue;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _repository.Get(id));
        }

        [HttpGet]
        [Route("GetPendingReports")]
        public async Task<IActionResult> GetPendingReports(int id)
        {
            return Ok(_pendingReportQeue.GetPendingReports());  
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody]List<Brand> brands, string reportName)
        {
            /*var httpClientHandler = new HttpClientHandler { CookieContainer = _cookieGetter.cookieContainer };
            var httpClient = new HttpClient(httpClientHandler); 

            var report = _eciService.CalculateReport(brands, httpClient);

            report.Base64Pdf = _pdfEditor.CreatePdf(report);
            
            if(!String.IsNullOrEmpty(reportName))
            {
                report.Name = reportName;
            }

            _repository.Create(report);*/

            await _pendingReportQeue.Add(brands, reportName);
            
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody]Report report)
        {
            await _repository.Update(report);
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