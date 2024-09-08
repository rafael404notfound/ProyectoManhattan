using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Net;
using System.Xml;
using Domain.Entities;
using Domain.Dto;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Layout;
using iText.Kernel.Pdf;
using ProyectoManhattan.Application;
using System.Net.Http;
using Domain.Dto;
using iText.Commons.Bouncycastle.Cert.Ocsp;
using MudBlazor;

namespace EciApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoeController : ControllerBase
    {
        private CookieGetter _cookieGetter { get; set; }
        public EciService _eciService { get; set; }
        public EmailService _emailService { get; set; }
        public PdfEditor _pdfEditor { get; set; }

        public ShoeController(CookieGetter cookieGetter,EciService eciService, EmailService emailService, PdfEditor pdfEditor)
        {
            _cookieGetter = cookieGetter;
            _eciService = eciService;
            _emailService = emailService;
            _pdfEditor = pdfEditor;
        }

        [HttpGet(Name = "FetchShoeModel")]
        [Route("Ean")]
        public async Task<ShoeModel> FetchShoeModelByEan(string shoeEan)
        {
            var handler = new HttpClientHandler { CookieContainer = _cookieGetter.cookieContainer };
            HttpClient httpClient = new HttpClient(handler);
            List<Shoe> shoes = new List<Shoe>();
            Shoe shoe = new Shoe();

            _eciService.SetShoeInfoByEan(shoeEan, ref shoe, httpClient);
            shoes = _eciService.FetchByMatnr(shoe.Matnr, httpClient).Result;
            ShoeModel result = _eciService.GetShoeModelTemplateByMatnr(shoe.Matnr, httpClient).Result;
            result.Sizes = shoes;
            result.Brand = shoe.Brand;

            return result;
        }

        [HttpGet(Name = "FetchShoeModel")]
        [Route("matnr")]
        public async Task<ShoeModel> FetchShoeModelByMatnr(string shoeMatnr)
        {
            var handler = new HttpClientHandler { CookieContainer = _cookieGetter.cookieContainer };
            HttpClient httpClient = new HttpClient(handler);
            List<Shoe> shoes = new List<Shoe>();
            Shoe shoe = new Shoe();

            shoes = _eciService.FetchByMatnr(shoeMatnr, httpClient).Result;
            ShoeModel result = _eciService.GetShoeModelTemplateByMatnr(shoeMatnr, httpClient).Result;
            result.Sizes = shoes;

            return result;
        }


        [HttpGet(Name = "FetchShoeModel")]
        [Route("reference")]
        public async Task<ShoeModel> FetchShoeModeByReference(string shoeReference)
        {
            var handler = new HttpClientHandler { CookieContainer = _cookieGetter.cookieContainer };
            HttpClient httpClient = new HttpClient(handler);
            List<Shoe> shoes = new List<Shoe>();
            Shoe shoe = new Shoe();

            shoe.Matnr = _eciService.GetShoeMatnrByReference(shoeReference, httpClient).Result;
            shoes = _eciService.FetchByMatnr(shoe.Matnr, httpClient).Result;
            ShoeModel result = _eciService.GetShoeModelTemplateByMatnr(shoe.Matnr, httpClient).Result;
            result.Sizes = shoes;

            return result;
        }

        [HttpGet(Name = "FetchShoeModelWithUneco")]
        [Route("Uneco")]
        public async Task<ShoeModel> FetchShoeModelByUneco([FromQuery]string shoeEan, [FromQuery]string shoeUneco)
        {
            var handler = new HttpClientHandler { CookieContainer = _cookieGetter.cookieContainer };
            HttpClient httpClient = new HttpClient(handler);
            List<Shoe> shoes = new List<Shoe>();
            Shoe shoe = new Shoe();

            _eciService.SetShoeInfoByEan(shoeEan, ref shoe, httpClient, shoeUneco);
            shoes = _eciService.FetchByMatnr(shoe.Matnr, httpClient).Result;
            ShoeModel result = _eciService.GetShoeModelTemplateByMatnr(shoe.Matnr, httpClient).Result;
            result.Sizes = shoes;

            return result;
        }

        [HttpPost(Name = "GetMissingShoes")]
        public async Task<CalculateMissingShoesDto> GetMissingShoes(List<EanAndUnecoDto> shoeEans)
        {

            var handler = new HttpClientHandler { CookieContainer = _cookieGetter.cookieContainer };
            HttpClient httpClient = new HttpClient(handler);

            List<Shoe> shoes = new List<Shoe>();
            Shoe shoe = new Shoe();


            foreach (var shoeEan in shoeEans)
            {
                shoe = await _eciService.GetShoeByEan(shoeEan.Ean, httpClient, shoeEan.Uneco);
                shoe.Count = 1;
                shoes.Add(shoe);
            }

            /*List<Task<Shoe>> tasks = new List<Task<Shoe>>();
            foreach (var shoeEan in shoeEans)
            {
                tasks.Add(_eciService.GetShoeByEan(shoeEan.Ean, httpClient, shoeEan.Uneco));
            }
            foreach (var task in tasks)
            {
                task.Wait();
                var shoe = task.Result;
                shoe.Count = 1;
                shoes.Add(shoe);
            }*/

            
           /* List<Task<Shoe>> tasks = new List<Task<Shoe>>();
            foreach (var shoeEan in shoeEans)
            {
                tasks.Add(_eciService.GetShoeByEan(shoeEan.Ean, httpClient, shoeEan.Uneco));
            }
            var results = await Task.WhenAll(tasks.ToArray());
            shoes.AddRange(results);     */

            List<ShoeModel> scannedShoeModels = await _eciService.GroupShoesInToShoeModels(shoes, httpClient);

            var result = _eciService.CalculateMissingShoes(scannedShoeModels, true, httpClient);

            string pdf = _pdfEditor.CreatePdf(result);
            await _emailService.SendEmail(pdf);

            return result;
        }

    }
}