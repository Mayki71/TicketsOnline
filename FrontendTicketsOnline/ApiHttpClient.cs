namespace FrontendTicketsOnline
{
    public class ApiHttpClient
    {
        private readonly HttpClient _http;
        private const string BaseUrl = "https://localhost:7042";

        public ApiHttpClient(HttpClient http)
        {
            _http = http;
            _http.BaseAddress = new Uri(BaseUrl);
        }

        public HttpClient Client => _http;
    }

}
