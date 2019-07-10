﻿using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OLO.Data
{
    public class HttpDelegateHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
