using Mailjet.Client;
using Mailjet;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mailjet.Client.Resources;

namespace ProyectoManhattan.Application
{
    public class EmailService
    {
        public async Task SendEmail(string base64Pdf)
        { 
            MailjetClient client = new MailjetClient("4350cd64b390837ec1d006a9dc21b615", "0bb18dc3f2ea0fc34ce9c47e6d01cb2d");
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
                .Property(Send.FromEmail, "rafaelsuarezcode@gmail.com")
                .Property(Send.FromName, "Hombre Sospechosamente Sospechoso")
                .Property(Send.Recipients, new JArray {
                 new JObject {
                     {"Email", "rafasuarezgonzalez@gmail.com"},
                     {"Name", "Rafa"}
                 }
                })
                .Property(Send.Subject, "Tu pdf otra vez, makina!")
                .Property(Send.TextPart, "Dear passenger, welcome to Mailjet! May the delivery force be with you!")
                .Property(Send.HtmlPart, "<h3>Dear passenger, welcome to Mailjet!</h3><br />May the delivery force be with you!")
                .Property(
                    Send.Attachments,
                    new JArray {
                      new JObject {
                           {"Content-type", "application/pdf"},
                           {"Filename", "test.pdf"},
                           {"content", base64Pdf}
                      }
                    }
                );
            MailjetResponse response = await client.PostAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
                Console.WriteLine(response.GetData());
            }
            else
            {
                Console.WriteLine(string.Format("StatusCode: {0}\n", response.StatusCode));
                Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
                Console.WriteLine(response.GetData());
                Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
            }
        }
    }
}
