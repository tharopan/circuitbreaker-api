using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OLO.API
{
    public class HttpDelegateHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                Trace.WriteLine(request.RequestUri.ToString());

                //request.Headers.Add("Content-Type", "application/json");
                var response = await base.SendAsync(request, cancellationToken);
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
