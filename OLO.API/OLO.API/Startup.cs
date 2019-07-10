using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OLO.Data;
using Polly;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Net.Http;

namespace OLO.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Circuit Breaker API", Version = "v1" });
            });

            //var services = new ServiceCollection();
            services.AddTransient<HttpDelegateHandler>();
            services.AddTransient<ICartContext, CartContext>();

            services
                .AddHttpClient("sitecore", c =>
                {
                    c.BaseAddress = new Uri("http://localhost:5000");
                })
                .AddHttpMessageHandler<HttpDelegateHandler>()
                .AddTransientHttpErrorPolicy(p =>
                    p.AdvancedCircuitBreakerAsync(
                        failureThreshold: 0.5, // Break on >=50% actions result in handled exceptions...
                        samplingDuration: TimeSpan.FromSeconds(10), // ... over any 10 second period
                        minimumThroughput: 8, // ... provided at least 8 actions in the 10 second period.
                        durationOfBreak: TimeSpan.FromSeconds(30), // Break for 30 seconds.
                        onBreak: (result, timespan, context) =>
                        {
                            OnBreak(result, timespan, context);
                        },
                        onReset: (context) =>
                        {
                            OnReset(context);
                        },
                        onHalfOpen: () =>
                        {
                            OnHalfOpen();
                        }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Circuit Breaker API V1");
            });

            app.UseMvc();
        }

        protected virtual void OnBreak(DelegateResult<HttpResponseMessage> exception, TimeSpan time, Context context)
        {
            //TODO : Add the onbreak function;
        }

        protected virtual void OnReset(Context context)
        {
            //TODO : Add on reset function;
        }

        protected virtual void OnHalfOpen()
        {
            //TODO : Add on reset function;
        }
    }
}
