using Microsoft.AspNetCore.Mvc;
using OLO.API.Models;
using OLO.Data;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OLO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CircuitBreakerManager circuitBreaker;
        HttpDelegateHandler httpDelegateHandler;
        HttpClient client;

        public CartController()
        {
            circuitBreaker = new CircuitBreakerManager(5000);
            httpDelegateHandler = new HttpDelegateHandler();
            client = HttpClientFactory.Create(httpDelegateHandler);
            client.BaseAddress = new Uri("https://127.0.0.1/api");
        }

        [HttpGet("{id}")]
        public async Task<Cart> GetCart(string id)
        {
            Cart cart = null;

            var cts = new CancellationTokenSource();
            var token = cts.Token;
            token.ThrowIfCancellationRequested();

            var test = circuitBreaker.Invoke(
                async () =>
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, "");
                    var response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        cart = await response.Content.ReadAsAsync<Cart>();
                        //TODO : Store into the cache read when it go offline
                    }
                },
                async () =>
                {
                    //TODO : Fail function
                });

            return cart;
        }

        [HttpGet("status")]
        public async Task<ServiceStatus> GetStatus()
        {
            try
            {
               
                ServiceStatus status = null;

                var cts = new CancellationTokenSource();
                cts.Token.ThrowIfCancellationRequested();


                //await circuitBreaker.Invoke(
                //    async () =>
                //    {
                //        var request = new HttpRequestMessage(HttpMethod.Get, "cart/status");
                //        var response = await client.SendAsync(request);

                //        if (response.IsSuccessStatusCode)
                //        {
                //            status = await response.Content.ReadAsAsync<ServiceStatus>();
                //            //TODO : Store into the cache read when it go offline
                //        }
                //    },
                //    async () =>
                //    {
                //        //TODO : Fail function
                //    });

                var request = new HttpRequestMessage(HttpMethod.Get, "cart/status");

                ServicePointManager.SecurityProtocol = 
                    SecurityProtocolType.Tls12 | 
                    SecurityProtocolType.Tls11 | 
                    SecurityProtocolType.SystemDefault |
                    SecurityProtocolType.Tls;

                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyError) => true;


                var response = await client.SendAsync(request, cts.Token);

                if (response.IsSuccessStatusCode)
                {
                    status = await response.Content.ReadAsAsync<ServiceStatus>();
                    //TODO : Store into the cache read when it go offline
                }

                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}