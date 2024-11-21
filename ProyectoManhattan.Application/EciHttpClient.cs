using ProyectoManhattan.Application;

namespace ProyectoManahttan.Application
{
    public class EciHttpService 
    {
        private IJwtGetter _jwtGetter;
        private HttpClient _client;

        public EciHttpService(IJwtGetter jwtGetter)
        {
            _jwtGetter = jwtGetter;
        } 

        /*public async Task<T> GetAsync<T>(string url)
        {
            // 
            if(_jwtGetter.CookiesAreInvalid())
            {
                await _jwtGetter.SetCookies();
            }
        }*/
        
    }
}