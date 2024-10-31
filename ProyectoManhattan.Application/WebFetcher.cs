using Domain.ValueTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Net;
using System.Text.Json.Nodes;
using Microsoft.Playwright;

namespace ProyectoManhattan.Application
{
    public class WebFetcher
    {
        public async Task<List<WebItem>> GetItems(string uneco, string brand, bool collectSameDay)
        {
            // Send Http request
            /*var url = new Uri($"https://www.elcorteingles.es/api/firefly/vuestore/new-search/delivery_time::0007-click_and_car/1/?s={searchString}&deliveryType=collect&sorting=featuredDesc&stype=text_box&isHome=false&isBookSearch=false");
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "C# App");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            var response = await httpClient.GetAsync(url);
            //var response =  httpClient.Send(new HttpRequestMessage(new HttpMethod("get"), $"https://www.elcorteingles.es/api/firefly/vuestore/new-search/delivery_time::0007-click_and_car/1/?s={searchString}&deliveryType=collect&sorting=featuredDesc&stype=text_box&isHome=false&isBookSearch=false"));
            //var response = await httpClient.GetAsync("https://www.google.com");
            var json = await response.Content.ReadAsStringAsync();*/

            //var request = new HttpRequestMessage(HttpMethod.Get, $"https://www.elcorteingles.es/api/firefly/vuestore/products_list/moda-hombre/zapatos/delivery_time::0007/brand::Dustin/?deliveryType=collect");
            //var request = new HttpRequestMessage(HttpMethod.Get, "https://www.elcorteingles.es/api/firefly/vuestore/new-search/delivery_time::0007-click_and_car/1/?s=pielsa&deliveryType=collect&sorting=featuredDesc&stype=text_box&isHome=false&isBookSearch=false");
            CookieContainer cookieContainer = new CookieContainer();
            /*cookieContainer.Add(new Cookie("_abck", "A1B780B1A8AD0D8C2229F8439E309E12~-1~YAAQpUAQAnrTBrySAQAA2DwqxAw/nnA/yrhdUkdRSKT/a0G5U+ojwW9EYPr5IyRfMSiNZ7Y+I9YjrOBm2muT8hB0IJTJEoiN8gjDMDXU640VMaWB2Y3fG1Rab3hG4PgkirTfFSnlBabK2zp50Ux+B5RwEMr/d4AjC3aLG6ELBtIKUfETyLP7hohU5ZGf0OvpYy1vuqBTc7i9jwxq3gphQVALe+6iz3FesP/GlgeGsnv8zUJi/4nPPhU8tWBzoKyl4o5iN4rhsXU6MEx9uwDPIbxh3ZH5JkRgDRpB/sb7bNVulhoUhynyRSzV89snh4bvQhyORdWne3eyRdF3YCIeDqKFeCQgzW399ZW2b3R5u/5YfEjwIJUPOB/sv9RBJO278Zij3gpgUIH1w2l26Me4RFp3sKzdOs0UUvhcr34y32Q=~-1~-1~-1"));
            cookieContainer.Add(new Cookie("ak_bmsc", "477164EF6140C309EF6AD1FDE9788ACD~000000000000000000000000000000~YAAQpUAQAnvTBrySAQAA2DwqxBl30P8/SAoZW0p2wbY36yQ5y8SjzusN5IDnC13tz34z6nS8cPhCoF3lbR3Q2jFySXlEMWSchPLXpUiCa0ChjKTIzck2mVOjw1Z4GeAomr7NqBqbqoay9L/kwte+HS5ReCPSDSrDDbAJPXkgaL1qOtafS3lsCsK51blogvfuwl9KHm1HDh87kFl87vyLUYrgxJhZNsv2N7H7IXTZ3Z9cjuNq0tDPi1nFbJvbPIBICvcqMSKcilI8Iq4Yq2AJBngMWnno5KCZZSJU2KepV0axA0j3rG6owy6C4rew7+s8tvjCzhCrOPUoEoryJV3PWMe8UTgKbpgyhncsmzqsG4Y="));
            cookieContainer.Add(new Cookie("bm_sz", "D929420EA6E0CC1EBDAD14163EB48891~YAAQpUAQAnzTBrySAQAA2DwqxBn7F6nO5cRUhLbigP7CTeQPVg6VrUq2en9aMZLTCMWNp8NXzZQx0+5Q0JtOBhyhZoAr8y3J5MG1UXrMj8yYj1zd5Xa0JSTyavD/ZVVxDJQfufuYcTb13zaiwfVT2mOrNOqQhNdLUBwpbdzz4EG/ZCz3BewnDXGL+95teY9e+8y0/cepUTQn2T1V2fWj+OJj+vnkL4eKtD2mKzQMASKvvXXot4NrKFn55jPF7aP2nqsaszmwxsG3P7wUDXWl+Y8hF40aGQuBscM6yRCOKa+0AlcBaBbxVA3KXvbPBfHO5pxQLi/hJikN+TFpX67yARrBasfo2LTo6JkJ6iaN0Aj8c7Y=~3422515~3683897"));
            cookieContainer.Add(new Cookie("source", "elastic"));
            cookieContainer.Add(new Cookie("2d163b5458feecb26fb2b6287362adb7", "e96c0512ea940057299a0a8cfae8ee90"));
            cookieContainer.Add(new Cookie("_bman", "702b3a8530afc1f8b7bf2e024f709b28"));
            cookieContainer.Add(new Cookie("centre", "NULL"));
            cookieContainer.Add(new Cookie("express", "F"));
            cookieContainer.Add(new Cookie("ff_checkout", "1"));
            cookieContainer.Add(new Cookie("ff_checkout_akamai", "ff_checkout_akamai"));
            cookieContainer.Add(new Cookie("locale", "es_ES"));
            cookieContainer.Add(new Cookie("session_id", "e624d91e4decb72e9ec01dc0a09ac30ae54d5f5257f4009b78c6543ef8709553"));
            cookieContainer.Add(new Cookie("store", "eciStore"));
            cookieContainer.Add(new Cookie("xSell_enable", "true"));*/

            //var httpClient = new HttpClient(new HttpClientHandler() { CookieContainer = cookieContainer});
            var httpClient = new HttpClient(new HttpClientHandler());


            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            //request.Headers.Add("Cookie", "_abck=A1B780B1A8AD0D8C2229F8439E309E12~-1~YAAQpUAQAnrTBrySAQAA2DwqxAw/nnA/yrhdUkdRSKT/a0G5U+ojwW9EYPr5IyRfMSiNZ7Y+I9YjrOBm2muT8hB0IJTJEoiN8gjDMDXU640VMaWB2Y3fG1Rab3hG4PgkirTfFSnlBabK2zp50Ux+B5RwEMr/d4AjC3aLG6ELBtIKUfETyLP7hohU5ZGf0OvpYy1vuqBTc7i9jwxq3gphQVALe+6iz3FesP/GlgeGsnv8zUJi/4nPPhU8tWBzoKyl4o5iN4rhsXU6MEx9uwDPIbxh3ZH5JkRgDRpB/sb7bNVulhoUhynyRSzV89snh4bvQhyORdWne3eyRdF3YCIeDqKFeCQgzW399ZW2b3R5u/5YfEjwIJUPOB/sv9RBJO278Zij3gpgUIH1w2l26Me4RFp3sKzdOs0UUvhcr34y32Q=~-1~-1~-1; ak_bmsc=477164EF6140C309EF6AD1FDE9788ACD~000000000000000000000000000000~YAAQpUAQAnvTBrySAQAA2DwqxBl30P8/SAoZW0p2wbY36yQ5y8SjzusN5IDnC13tz34z6nS8cPhCoF3lbR3Q2jFySXlEMWSchPLXpUiCa0ChjKTIzck2mVOjw1Z4GeAomr7NqBqbqoay9L/kwte+HS5ReCPSDSrDDbAJPXkgaL1qOtafS3lsCsK51blogvfuwl9KHm1HDh87kFl87vyLUYrgxJhZNsv2N7H7IXTZ3Z9cjuNq0tDPi1nFbJvbPIBICvcqMSKcilI8Iq4Yq2AJBngMWnno5KCZZSJU2KepV0axA0j3rG6owy6C4rew7+s8tvjCzhCrOPUoEoryJV3PWMe8UTgKbpgyhncsmzqsG4Y=; bm_sz=D929420EA6E0CC1EBDAD14163EB48891~YAAQpUAQAnzTBrySAQAA2DwqxBn7F6nO5cRUhLbigP7CTeQPVg6VrUq2en9aMZLTCMWNp8NXzZQx0+5Q0JtOBhyhZoAr8y3J5MG1UXrMj8yYj1zd5Xa0JSTyavD/ZVVxDJQfufuYcTb13zaiwfVT2mOrNOqQhNdLUBwpbdzz4EG/ZCz3BewnDXGL+95teY9e+8y0/cepUTQn2T1V2fWj+OJj+vnkL4eKtD2mKzQMASKvvXXot4NrKFn55jPF7aP2nqsaszmwxsG3P7wUDXWl+Y8hF40aGQuBscM6yRCOKa+0AlcBaBbxVA3KXvbPBfHO5pxQLi/hJikN+TFpX67yARrBasfo2LTo6JkJ6iaN0Aj8c7Y=~3422515~3683897; source=elastic; 2d163b5458feecb26fb2b6287362adb7=e96c0512ea940057299a0a8cfae8ee90; _bman=702b3a8530afc1f8b7bf2e024f709b28; centre=NULL; express=F; ff_checkout=1; ff_checkout_akamai=ff_checkout_akamai; locale=es_ES; session_id=e624d91e4decb72e9ec01dc0a09ac30ae54d5f5257f4009b78c6543ef8709553; store=eciStore; xSell_enable=true");
            ///request.Headers.Add("User-Agent", "PostmanRuntime/7.37.3");
            ///request.Headers.Add("Accept", "*/*");
            //request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            ///request.Headers.Add("Connection", "keep-alive");
            //var response = httpClient.SendAsync(request).Result;
            //string json = httpClient.GetStringAsync($"https://www.elcorteingles.es/api/firefly/vuestore/new-search/delivery_time::0007-click_and_car/1/?s={searchString}&deliveryType=collect&sorting=featuredDesc&stype=text_box&isHome=false&isBookSearch=false").Result;
            // var json = await response.Content.ReadAsStringAsync();

            // Deserialize json
            //var parsedObject = JObject.Parse(json);

            //int count =  Convert.ToInt32(parsedObject["data"]["paginatedDatalayer"]["page"]["total_products"]?.ToString());
            //int itemsPerPage = Convert.ToInt32(parsedObject["data"]["paginatedDatalayer"]["page"]["items_per_page"]?.ToString());
            int totalPages = 1;
            var result = new List<WebItem>();

            for (int i = 0; i < totalPages; i++)
            {
                HttpRequestMessage request;
                string url = "";
                if (collectSameDay)
                {
                    request = new HttpRequestMessage(HttpMethod.Get, $"https://www.elcorteingles.es/api/firefly/vuestore/products_list/{GetSearchString(uneco)}/delivery_time::0007/brand::{brand}/{i + 1}?deliveryType=collect");
                    Console.WriteLine($"https://www.elcorteingles.es/api/firefly/vuestore/products_list/{GetSearchString(uneco)}/delivery_time::0007/brand::{brand}/{i + 1}?deliveryType=collect");
                    url = $"https://www.elcorteingles.es/api/firefly/vuestore/products_list/{GetSearchString(uneco)}/delivery_time::0007/brand::{brand}/{i + 1}?deliveryType=collect";
                }
                else
                {
                    request = new HttpRequestMessage(HttpMethod.Get, $"https://www.elcorteingles.es/api/firefly/vuestore/products_list/{GetSearchString(uneco)}/brand::{brand}/{i + 1}");
                    Console.WriteLine($"https://www.elcorteingles.es/api/firefly/vuestore/products_list/{GetSearchString(uneco)}/brand::{brand}/{i + 1}");
                    url = $"https://www.elcorteingles.es/api/firefly/vuestore/products_list/{GetSearchString(uneco)}/brand::{brand}/{i + 1}";
                }
                //var request = new HttpRequestMessage(HttpMethod.Get, $"https://www.elcorteingles.es/api/firefly/vuestore/products_list/{GetSearchString(uneco)}/zapatos/delivery_time::0007/brand::{brand}/{i+1}?deliveryType=collect");
                //var request = new HttpRequestMessage(HttpMethod.Get, $"https://www.elcorteingles.es/api/firefly/vuestore/products_list/{GetSearchString(uneco)}/zapatos/brand::{brand}/{i + 1}");
                //var request = new HttpRequestMessage(HttpMethod.Get, $"https://www.elcorteingles.es/api/firefly/vuestore/products_list/moda-infantil/zapatos/delivery_time::0007/brand::Kids%20El%20Corte%20Inglés/{i + 1}?deliveryType=collect");
                //https://www.elcorteingles.es/api/firefly/vuestore/products_list/delivery_time::0007/brand::Dustin/?deliveryType=collect
                /*
                request.Headers.Add("authority", "www.elcorteingles.es");
                //request.Headers.Add("Accept-Encoding", "gzip, deflate ,br,zstd");
                request.Headers.Add("Accept-Language", "es-ES,es;q=0.9,en;q=0.8");
                request.Headers.Add("Scheme", "https");
                request.Headers.Add("Priority", "u=1, i");
                request.Headers.Add("Referer", "https://www.elcorteingles.es/moda-mujer/zapatos/delivery_time::0007/?deliveryType=collect");
                request.Headers.Add("Sec-Ch-Ua", "Chromium\";v=\"130\", \"Google Chrome\";v=\"130\", \"Not");
                request.Headers.Add("Sec-Ch-Ua-Mobile", "?1");
                request.Headers.Add("Sec-Ch-Ua-Platform", "Android");
                request.Headers.Add("Sec-Fetch-Dest", "empty");
                request.Headers.Add("Sec-Fetch-Mode", "cors");
                request.Headers.Add("Sec-Fetch-Site", "same-origin");
                request.Headers.Add("Access-Control-Allow-Origin", "*");*/


                request.Headers.Add("User-Agent", "PostmanRuntime/7.37.3");
                request.Headers.Add("Accept", "*/*");
                request.Headers.Add("Connection", "keep-alive");
                //var response = await  httpClient.SendAsync(request);

                //var json = await response.Content.ReadAsStringAsync();

                var json = SendRequestByPlaywright(url).Result;
                var parsedObject = JObject.Parse(json);

                totalPages = Convert.ToInt32(parsedObject["data"]["paginatedDatalayer"]["page"]["total_pages"]?.ToString());
                var productsCount = parsedObject["data"]["paginatedDatalayer"]["products"]?.Count();

                for (int j = 0; j < productsCount; j++)
                {
                    string reference = parsedObject["data"]["paginatedDatalayer"]["products"][j]["id"].ToString();
                    var productsJson = parsedObject["data"]["products"];
                    List<string> photos = new List<string>();
                    if (reference.Substring(3, 4) == uneco)
                    {
                        //for (int k = 0; k < productsJson.Count(); i++)
                        //{
                        photos.Add(productsJson[j]["_my_colors"][0]["all_images"][0]["sources"]["medium"].ToString());
                        //}
                        result.Add(new WebItem()
                        {
                            Reference = parsedObject["data"]["paginatedDatalayer"]["products"][j]["id"].ToString(),
                            Photos = photos
                        });
                    }
                }
            }

            result = result.OrderBy(wi => Convert.ToInt64(wi.Reference)).ToList();

            return result;
        }

        private string GetSearchString(string uneco)
        {
            switch (uneco)
            {
                case "0978":
                    return "moda-hombre/zapatos";
                case "0033":
                    return "moda-hombre/zapatos";
                case "0312":
                    return "moda-infantil/zapatos";
                case "0013":
                    return "moda-infantil/zapatos";
                case "0516":
                    return "moda-infantil/zapatos/zapatos-bebe-nino";
                case "0420":
                    return "moda-infantil/zapatos/zapatos-bebe-nino";
                case "0178":
                    return "moda-mujer/zapatos";
                case "0030":
                    return "moda-mujer/zapatos";
                default:
                    throw new Exception("Select a proper uneco");
            }
        }

        private async Task<string> SendRequestByPlaywright(string url)
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new() { Headless = true });
            var page = await browser.NewPageAsync(new()
            {
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36",
                BypassCSP = true
            });
            var response = await page.GotoAsync(url);

            //Thread.Sleep(3000);

            return response.JsonAsync().Result.ToString();

        }
    }
}