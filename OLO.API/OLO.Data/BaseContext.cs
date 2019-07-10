using System.Net.Http;

namespace OLO.Data
{
    public class BaseContext
    {
        protected HttpClient client;

        public BaseContext(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient("sitecore");
        }
    }
}
