using System.Net.Http;

namespace OLO.Data
{
    public class CartContext : BaseContext, ICartContext
    {
        public CartContext(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }

        public string Get(string id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "");
                var response = client.SendAsync(request);
            }
            catch (System.Exception ex)
            {

                throw;
            }

            return "This is my text";
        }
    }
}
