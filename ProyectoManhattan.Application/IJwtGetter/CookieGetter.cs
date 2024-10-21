using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Net;

namespace ProyectoManhattan.Application
{
    public class CookieGetter : BackgroundService, IJwtGetter
    {
        private static readonly TimeSpan Period = TimeSpan.FromMinutes(25);
        private readonly ILogger<CookieGetter> _logger;
        public CookieContainer cookieContainer { get; set; }
      
        public IWebDriver driver { get; set; }

        /*public CookieGetter(ILogger<CookieGetter> logger)
        { 
            _logger = logger;
            await SetCookies();
        }*/

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(Period);

            await SetCookies();

            while(!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
            {
                await SetCookies();
            }
        }
        /*
        public void SetCookies()
        {
            // Navigate to sap            
            var options = new ChromeOptions();            
            options.AddArgument("--headless"); 
            options.AddArgument("--no-sandbox"); 
            //options.AddArgument("--disable-dev-shm-usage"); 
            driver = new ChromeDriver(options);
            //driver = new ChromeDriver("C:/Published/ProyectoManhattan/chromedriver/win64/chromedriver.exe", options, TimeSpan.FromSeconds(130));

            driver.Navigate().GoToUrl("https://sapfiori.elcorteingles.es/sap/bc/ui2/flp");

            // Get form elements
            
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //IWebElement usernameElement = wait.Until(drv => drv.FindElement(By.Id("username")));
            IWebElement usernameElement = driver.FindElement(By.Id("username"));
            //IWebElement passwordElement = wait.Until(drv => drv.FindElement(By.Id("password")));
            IWebElement passwordElement = driver.FindElement(By.Id("password"));

            // Activate form
            usernameElement.SendKeys("73607079");
            passwordElement.SendKeys("ab123456");
            passwordElement.SendKeys(Keys.Enter);

            // Get cookies
            _logger.LogInformation("Getting cookies...");
            cookieContainer = new CookieContainer();
            foreach (var cookie in driver.Manage().Cookies.AllCookies)
            {
                cookieContainer.Add(new System.Net.Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));
                _logger.LogInformation($"{cookie.Name}: {cookie.Value}");
            }


            // Delete cookies
            driver.Manage().Cookies.DeleteAllCookies();

            // Log out
            //driver.Navigate().GoToUrl("https://login.microsoftonline.com/common/oauth2/logout?client%5Fid=00000003%2D0000%2D0ff1%2Dce00%2D000000000000&response%5Fmode=form%5Fpost&post%5Flogout%5Fredirect%5Furi=https%3A%2F%2Felcorteingles%2Esharepoint%2Ecom%3A443%2Fsites%2FNEXO%2Fes%2Des%2F%5Flayouts%2F15%2FSignOut%2Easpx%3Fsignoutoidc%3D1&client%2Drequest%2Did=fa2748a1%2D10b7%2D9000%2Dae7e%2Da02f5a253ab1");

            // Close
            driver.Quit();
        }*/

        public async Task SetCookies()
        {
            // Navigate to sap            
            var options = new ChromeOptions();            
            options.AddArgument("--headless"); 
            options.AddArgument("--no-sandbox"); 
            //options.AddArgument("--disable-dev-shm-usage"); 
            driver = new ChromeDriver(options);
            //driver = new ChromeDriver("C:/Published/ProyectoManhattan/chromedriver/win64/chromedriver.exe", options, TimeSpan.FromSeconds(130));

            driver.Navigate().GoToUrl("https://sapfiori.elcorteingles.es/sap/bc/ui2/flp");

            // Get form elements
            
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //IWebElement usernameElement = wait.Until(drv => drv.FindElement(By.Id("username")));
            IWebElement usernameElement = driver.FindElement(By.Id("username"));
            //IWebElement passwordElement = wait.Until(drv => drv.FindElement(By.Id("password")));
            IWebElement passwordElement = driver.FindElement(By.Id("password"));

            // Activate form
            usernameElement.SendKeys("73607079");
            passwordElement.SendKeys("ab123456");
            passwordElement.SendKeys(Keys.Enter);

            // Get cookies
            //_logger.LogInformation("Getting cookies...");
            cookieContainer = new CookieContainer();
            foreach (var cookie in driver.Manage().Cookies.AllCookies)
            {
                cookieContainer.Add(new System.Net.Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));
                //_logger.LogInformation($"{cookie.Name}: {cookie.Value}");
                Console.WriteLine($"Writing cookier: {cookie.Name} -> {cookie.Value}");    
            }


            // Delete cookies
            driver.Manage().Cookies.DeleteAllCookies();

            // Log out
            //driver.Navigate().GoToUrl("https://login.microsoftonline.com/common/oauth2/logout?client%5Fid=00000003%2D0000%2D0ff1%2Dce00%2D000000000000&response%5Fmode=form%5Fpost&post%5Flogout%5Fredirect%5Furi=https%3A%2F%2Felcorteingles%2Esharepoint%2Ecom%3A443%2Fsites%2FNEXO%2Fes%2Des%2F%5Flayouts%2F15%2FSignOut%2Easpx%3Fsignoutoidc%3D1&client%2Drequest%2Did=fa2748a1%2D10b7%2D9000%2Dae7e%2Da02f5a253ab1");

            // Close
            driver.Quit();
        }
    }
}