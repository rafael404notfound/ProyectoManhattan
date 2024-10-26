using Domain.ValueTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Net;
using System.Text.Json.Nodes;

namespace ProyectoManhattan.Application
{
    public class WebFetcher
    {
        public async Task<List<WebItem>> GetItems(string searchString)
        {
            // Send Http request
            /*var url = new Uri($"https://www.elcorteingles.es/api/firefly/vuestore/new-search/delivery_time::0007-click_and_car/1/?s={searchString}&deliveryType=collect&sorting=featuredDesc&stype=text_box&isHome=false&isBookSearch=false");
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "C# App");
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            var response = await httpClient.GetAsync(url);
            //var response =  httpClient.Send(new HttpRequestMessage(new HttpMethod("get"), $"https://www.elcorteingles.es/api/firefly/vuestore/new-search/delivery_time::0007-click_and_car/1/?s={searchString}&deliveryType=collect&sorting=featuredDesc&stype=text_box&isHome=false&isBookSearch=false"));
            //var response = await httpClient.GetAsync("https://www.google.com");
            var json = await response.Content.ReadAsStringAsync();*/

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://www.elcorteingles.es/api/firefly/vuestore/new-search/delivery_time::0007-click_and_car/1/?s={searchString}&deliveryType=collect&sorting=featuredDesc&stype=text_box&isHome=false&isBookSearch=false");
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

            var httpClient = new HttpClient(new HttpClientHandler() { CookieContainer = cookieContainer});
            //request.Headers.Add("Cookie", "_abck=A1B780B1A8AD0D8C2229F8439E309E12~-1~YAAQpUAQAnrTBrySAQAA2DwqxAw/nnA/yrhdUkdRSKT/a0G5U+ojwW9EYPr5IyRfMSiNZ7Y+I9YjrOBm2muT8hB0IJTJEoiN8gjDMDXU640VMaWB2Y3fG1Rab3hG4PgkirTfFSnlBabK2zp50Ux+B5RwEMr/d4AjC3aLG6ELBtIKUfETyLP7hohU5ZGf0OvpYy1vuqBTc7i9jwxq3gphQVALe+6iz3FesP/GlgeGsnv8zUJi/4nPPhU8tWBzoKyl4o5iN4rhsXU6MEx9uwDPIbxh3ZH5JkRgDRpB/sb7bNVulhoUhynyRSzV89snh4bvQhyORdWne3eyRdF3YCIeDqKFeCQgzW399ZW2b3R5u/5YfEjwIJUPOB/sv9RBJO278Zij3gpgUIH1w2l26Me4RFp3sKzdOs0UUvhcr34y32Q=~-1~-1~-1; ak_bmsc=477164EF6140C309EF6AD1FDE9788ACD~000000000000000000000000000000~YAAQpUAQAnvTBrySAQAA2DwqxBl30P8/SAoZW0p2wbY36yQ5y8SjzusN5IDnC13tz34z6nS8cPhCoF3lbR3Q2jFySXlEMWSchPLXpUiCa0ChjKTIzck2mVOjw1Z4GeAomr7NqBqbqoay9L/kwte+HS5ReCPSDSrDDbAJPXkgaL1qOtafS3lsCsK51blogvfuwl9KHm1HDh87kFl87vyLUYrgxJhZNsv2N7H7IXTZ3Z9cjuNq0tDPi1nFbJvbPIBICvcqMSKcilI8Iq4Yq2AJBngMWnno5KCZZSJU2KepV0axA0j3rG6owy6C4rew7+s8tvjCzhCrOPUoEoryJV3PWMe8UTgKbpgyhncsmzqsG4Y=; bm_sz=D929420EA6E0CC1EBDAD14163EB48891~YAAQpUAQAnzTBrySAQAA2DwqxBn7F6nO5cRUhLbigP7CTeQPVg6VrUq2en9aMZLTCMWNp8NXzZQx0+5Q0JtOBhyhZoAr8y3J5MG1UXrMj8yYj1zd5Xa0JSTyavD/ZVVxDJQfufuYcTb13zaiwfVT2mOrNOqQhNdLUBwpbdzz4EG/ZCz3BewnDXGL+95teY9e+8y0/cepUTQn2T1V2fWj+OJj+vnkL4eKtD2mKzQMASKvvXXot4NrKFn55jPF7aP2nqsaszmwxsG3P7wUDXWl+Y8hF40aGQuBscM6yRCOKa+0AlcBaBbxVA3KXvbPBfHO5pxQLi/hJikN+TFpX67yARrBasfo2LTo6JkJ6iaN0Aj8c7Y=~3422515~3683897; source=elastic; 2d163b5458feecb26fb2b6287362adb7=e96c0512ea940057299a0a8cfae8ee90; _bman=702b3a8530afc1f8b7bf2e024f709b28; centre=NULL; express=F; ff_checkout=1; ff_checkout_akamai=ff_checkout_akamai; locale=es_ES; session_id=e624d91e4decb72e9ec01dc0a09ac30ae54d5f5257f4009b78c6543ef8709553; store=eciStore; xSell_enable=true");
            request.Headers.Add("User-Agent", "PostmanRuntime/7.37.3");
            request.Headers.Add("Accept", "*/*");
            //request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Headers.Add("Connection", "keep-alive");
            var response = httpClient.SendAsync(request).Result;
            //string json = httpClient.GetStringAsync($"https://www.elcorteingles.es/api/firefly/vuestore/new-search/delivery_time::0007-click_and_car/1/?s={searchString}&deliveryType=collect&sorting=featuredDesc&stype=text_box&isHome=false&isBookSearch=false").Result;
            var json = await response.Content.ReadAsStringAsync();

            // Deserialize json
            var parsedObject = JObject.Parse(json);

            int count =  Convert.ToInt32(parsedObject["data"]["paginatedDatalayer"]["page"]["total_products"]?.ToString());
            string plp = parsedObject["data"]["paginatedDatalayer"]["page"]["plp_standard_4"]?.ToString();
            string ean = parsedObject["data"]["paginatedDatalayer"]["products"][0]["id"].ToString();
            var productsCount = parsedObject["data"]["paginatedDatalayer"]["products"].Count();
            var result = new List<WebItem>();
            
            for(int i = 0; i < productsCount; i++)
            {
                string reference = parsedObject["data"]["paginatedDatalayer"]["products"][i]["id"].ToString();
                if(reference.Substring(3, 4) == "0033")
                result.Add(new WebItem()
                {
                    Reference = parsedObject["data"]["paginatedDatalayer"]["products"][i]["id"].ToString()
                });
            }

            result.OrderBy(wi => wi.Reference);

            return new List<WebItem>();
        }
    }
}