﻿using Polly;
using System;
using System.Threading.Tasks;

namespace OLO.API
{
    public class CircuitBreakerManager
    {
        private readonly int resetTimeOut;

        public CircuitBreakerManager(int resetTimeoutInMilliseconds)
        {
            this.resetTimeOut = resetTimeoutInMilliseconds;
        }

        public async Task Invoke(Func<Task> func, Func<Task> failAction)
        {
            var circuitBreaker = Policy
                .Handle<Exception>()
                .CircuitBreakerAsync(
                    exceptionsAllowedBeforeBreaking: 1,
                    durationOfBreak: TimeSpan.FromMilliseconds(resetTimeOut)
                );

            var policy = Policy
                .Handle<Exception>()
                .FallbackAsync((a) => failAction())
                .WrapAsync(circuitBreaker);

            policy.ExecuteAsync(() => func());
        }
    }
}
