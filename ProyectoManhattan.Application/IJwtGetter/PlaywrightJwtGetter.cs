using Microsoft.Extensions.Hosting;
using System.Net;
using Microsoft.Playwright;
namespace ProyectoManhattan.Application
{
    public class PlaywrightJwtGetter : BackgroundService, IJwtGetter
    {
        private static readonly TimeSpan Period = TimeSpan.FromMinutes(25);
        public CookieContainer cookieContainer { get; set; }
        public async Task SetCookies()
        {
            
            cookieContainer = new CookieContainer();
            int tries = 0;
            while(CookiesAreInvalid() && tries < 10)
            {
                Console.WriteLine("///// SETTING COOKIES");   
                // Navigate to sap
                using var playwright = await Playwright.CreateAsync();
                await using var browser = await playwright.Chromium.LaunchAsync();
                var page = await browser.NewPageAsync();
                await page.GotoAsync("https://sapfiori.elcorteingles.es/sap/bc/ui2/flp");
                
                // Fill form elemtents
                //Task task = page.WaitForSelectorAsync("#username");
                //await task.ContinueWith(async (r) => 
                //{
                    Thread.Sleep(3000);
                    await page.Locator("#username").FillAsync("73607079"); 
                    Thread.Sleep(500);
                    await page.Locator("#password").FillAsync("ab123123");
                    Thread.Sleep(300);
                //} );
                

                // Send form
                await page.Locator("#password").PressAsync("Enter");

                Thread.Sleep(3000);

                // Get cookies
                IReadOnlyList<BrowserContextCookiesResult> cookies = await browser.Contexts.First().CookiesAsync();
                foreach (var cookie in await browser.Contexts.First().CookiesAsync())
                {
                    cookieContainer.Add(new System.Net.Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));
                    Console.WriteLine($"Writing cookie: {cookie.Name}, {cookie.Path}, {cookie.Domain} -> {cookie.Value} ");                
                }
                await browser.CloseAsync();
            }
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        { 
            await SetCookies();
            using var timer = new PeriodicTimer(Period);

            while(!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
            {                               
                await SetCookies();
            }
        }

        public bool CookiesAreInvalid()
        {
            if (cookieContainer is not null)
            {
                foreach(var cookie in cookieContainer.GetAllCookies().ToList())
                {
                    if(cookie.Name == "sap-contextid")
                    {
                        Console.WriteLine("------------> Cookies are valid");
                        return false;
                    }
                }    
            }
            Console.WriteLine("------------> Cookies are invalid");                    
            return true;
        }
    }
}