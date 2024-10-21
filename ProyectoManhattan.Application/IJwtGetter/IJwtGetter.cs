using Microsoft.Extensions.Hosting;
using System.Net;

namespace ProyectoManhattan.Application
{
    public interface IJwtGetter : IHostedService
    {
        public CookieContainer cookieContainer { get; set; }
        public Task SetCookies();
    }
}