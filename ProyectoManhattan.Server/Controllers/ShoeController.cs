﻿using Microsoft.AspNetCore.Mvc;
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
        //private CookieGetter _cookieGetter { get; set; }
        private IJwtGetter _jwtGetter { get; set; }
        public EciService _eciService { get; set; }
        public EmailService _emailService { get; set; }
        public PdfEditor _pdfEditor { get; set; }
        public IApplicationRepo _applicationRepo { get; set; }

        public ShoeController(IJwtGetter jwtGetter,EciService eciService, EmailService emailService, PdfEditor pdfEditor, IApplicationRepo applicationRepo)
        {
            _jwtGetter = jwtGetter;
            _eciService = eciService;
            _emailService = emailService;
            _pdfEditor = pdfEditor;
            _applicationRepo = applicationRepo;
        }        

		/*[HttpGet()]
        [Route("GetModels")]
        public IEnumerable<ShoeModel> GetShoeModels()
        {
            return _applicationRepo.GetAll();
        }

        [HttpPost()]
        [Route("PostModel")]
        public IActionResult PostShoeModels([FromBody] ShoeModel shoeModel)
        {
            _applicationRepo.Create(shoeModel);
            return Ok(shoeModel);
        }*/

		[HttpGet()]
        [Route("Ean")]
        public async Task<ShoeModel> FetchShoeModelByEan(string shoeEan)
        {
            var handler = new HttpClientHandler { CookieContainer = _jwtGetter.cookieContainer };
            HttpClient httpClient = new HttpClient(handler);
            var response = await httpClient.GetAsync("https://www.google.com");
            List<Shoe> shoes = new List<Shoe>();
            Shoe shoe = new Shoe();

            _eciService.SetShoeInfoByEan(shoeEan, ref shoe, httpClient);
            shoes = _eciService.FetchByMatnr(shoe.Matnr, httpClient).Result;
            ShoeModel result = _eciService.GetShoeModelTemplateByMatnr(shoe.Matnr, httpClient).Result;
            result.Sizes = shoes;
            result.BrandSapName = shoe.BrandSapName;

            return result;
        }

        [HttpGet()]
        [Route("matnr")]
        public async Task<ShoeModel> FetchShoeModelByMatnr(string shoeMatnr)
        {
            var handler = new HttpClientHandler { CookieContainer = _jwtGetter.cookieContainer };
            HttpClient httpClient = new HttpClient(handler);
            List<Shoe> shoes = new List<Shoe>();
            Shoe shoe = new Shoe();

            shoes = _eciService.FetchByMatnr(shoeMatnr, httpClient).Result;
            ShoeModel result = _eciService.GetShoeModelTemplateByMatnr(shoeMatnr, httpClient).Result;
            result.Sizes = shoes;

            return result;
        }


        [HttpGet()]
        [Route("reference")]
        public async Task<ShoeModel> FetchShoeModeByReference(string shoeReference)
        {
            var handler = new HttpClientHandler { CookieContainer = _jwtGetter.cookieContainer };
            HttpClient httpClient = new HttpClient(handler);
            List<Shoe> shoes = new List<Shoe>();
            Shoe shoe = new Shoe();

            shoe.Matnr = _eciService.GetShoeMatnrByReference(shoeReference, httpClient).Result;
            shoes = _eciService.FetchByMatnr(shoe.Matnr, httpClient).Result;
            ShoeModel result = _eciService.GetShoeModelTemplateByMatnr(shoe.Matnr, httpClient).Result;
            result.Sizes = shoes;

            return result;
        }

        [HttpGet()]
        [Route("Uneco")]
        public async Task<ShoeModel> FetchShoeModelByUneco([FromQuery]string shoeEan, [FromQuery]string shoeUneco)
        {
            var handler = new HttpClientHandler { CookieContainer = _jwtGetter.cookieContainer };
            HttpClient httpClient = new HttpClient(handler);
            List<Shoe> shoes = new List<Shoe>();
            Shoe shoe = new Shoe();

            _eciService.SetShoeInfoByEan(shoeEan, ref shoe, httpClient, shoeUneco);
            shoes = _eciService.FetchByMatnr(shoe.Matnr, httpClient).Result;
            ShoeModel result = _eciService.GetShoeModelTemplateByMatnr(shoe.Matnr, httpClient).Result;
            result.Sizes = shoes;

            return result;
        }

        [HttpPost("GetMissingShoes")]
        public async Task<CalculateMissingShoesDto> GetMissingShoes(List<EanAndUnecoDto> shoeEans)
        {

            var handler = new HttpClientHandler { CookieContainer = _jwtGetter.cookieContainer };
            HttpClient httpClient = new HttpClient(handler);

            List<Shoe> shoes = new List<Shoe>();
            Shoe shoe = new Shoe();


            /*foreach (var shoeEan in shoeEans)
            {
                shoe = await _eciService.GetShoeByEan(shoeEan.Ean, httpClient, shoeEan.Uneco);
                shoe.Count = 1;
                shoes.Add(shoe);
            }*/

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

            
            List<Task<ShoeOrErrorDto>> tasks = new List<Task<ShoeOrErrorDto>>();
            foreach (var shoeEan in shoeEans)
            {
                tasks.Add(_eciService.GetShoeByEan(shoeEan.Ean, httpClient, shoeEan.Uneco));
            }
            var results = await Task.WhenAll(tasks.ToArray());
            shoes.AddRange(results.Where(sOE => sOE.Shoe is not null).Select(sOE => sOE.Shoe));


            List<ShoeModel> scannedShoeModels = await _eciService.GroupShoesInToShoeModels(shoes, httpClient);
            //GroupShoesIntoShoeModelsDto groupShoesIntoShoeModelsDto = await _eciService.GroupShoesInToShoeModels(shoes, httpClient);

            var result = _eciService.CalculateMissingShoes(scannedShoeModels, true, httpClient);

            //string pdf = _pdfEditor.CreatePdf(result);
            //await _emailService.SendEmail(pdf);

            return result;
        }

    }
}