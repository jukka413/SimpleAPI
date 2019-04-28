using SimpleAPI.BusinessLogic;
using SimpleAPI.Consumers;
using SimpleAPI.Commands;
using SimpleAPI.Services;
using SimpleAPI.Services.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace SimpleAPI

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
            services.AddScoped<GetUsersInfoRequestHandler>();
            services.AddScoped<PutUserInfoRequestHandler>();
            services.AddScoped<IUserInfoService, UserInfoService>();

            services.AddScoped<PutUserInfoRequestHandler>();
            services.AddScoped<IUserPutService, UserPutService>();
            services.AddScoped<IPutUser, PutUser>();

            // Register your consumers if the need dependencies
            services.AddScoped<PutUserConsumer>();

            services.AddHealthChecks();

            services.AddMassTransit(c =>
            {
                c.AddConsumer<PutUserConsumer>();
            });

            services.AddSingleton(provider => MassTransit.Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host("localhost", "/", h => { });

                cfg.ReceiveEndpoint(host, "yo", e =>
                {
                    e.PrefetchCount = 16;
                    e.LoadFrom(provider);
                });
            }));

            services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<IHostedService, BusService>();

        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
            }
            else
            {
               
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
