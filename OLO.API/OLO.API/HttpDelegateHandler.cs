//using Polly;
//using Polly.CircuitBreaker;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading;
//using System.Threading.Tasks;

//namespace OLO.API
//{
//    public class HttpDelegateHandler : DelegatingHandler
//    {
//        //protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
//        //{
//        //    try
//        //    {
//        //        Trace.WriteLine(request.RequestUri.ToString());

//        //        //request.Headers.Add("Content-Type", "application/json");
//        //        var response = await base.SendAsync(request, cancellationToken);
//        //        return response;
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        throw;
//        //    }
//        //}

//        protected readonly AsyncCircuitBreakerPolicy breakerPolicy;

//        public HttpDelegateHandler()
//        {
//            Action<Exception, TimeSpan, Context> onBreak = (exception, timespan, context) =>
//            {
//                OnBreak(exception, timespan, context);
//            };

//            Action<Context> onReset = context =>
//            {
//                OnReset(context);
//            };

//            Action onHalfOpen = () =>
//            {
//                OnHalfOpen();
//            };

//            breakerPolicy = Policy
//                .Handle<Exception>()
//                .AdvancedCircuitBreakerAsync(
//                    failureThreshold: 0.5, // Break on >=50% actions result in handled exceptions...
//                    samplingDuration: TimeSpan.FromSeconds(10), // ... over any 10 second period
//                    minimumThroughput: 8, // ... provided at least 8 actions in the 10 second period.
//                    durationOfBreak: TimeSpan.FromSeconds(30), // Break for 30 seconds.
//                    onBreak: onBreak,
//                    onReset: onReset,
//                    onHalfOpen: onHalfOpen
//                );
//        }

//        protected virtual void OnBreak(Exception exception, TimeSpan time, Context context)
//        {
//            //TODO : Add the onbreak function;
//        }

//        protected virtual void OnReset(Context context)
//        {
//            //TODO : Add on reset function;
//        }

//        protected virtual void OnHalfOpen()
//        {
//            //TODO : Add on reset function;
//        }

//        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
//        {
//            try
//            {
//                //request.Headers.Add("Content-Type", "application/json");
//                var response = await breakerPolicy.ExecuteAsync<HttpResponseMessage>(() => base.SendAsync(request, cancellationToken));
//                return response;
//            }
//            catch (Exception ex)
//            {
//                throw;
//            }
//        }
//    }
//}
