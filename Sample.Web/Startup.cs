using Domain.Commands;
using Domain.Events;
using Domain.Queries;
using EventStore.EF.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Web.Commands;
using Web.Events;

namespace Web
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
            services.AddControllers();
          //  services.AddDistributedMemoryCache();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost";
                options.InstanceName = "SampleInstance";
            }); 
            services.AddDbContext<DbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("server=127.0.0.1;database=eventsourcing;uid=root;pwd=root;charset='utf8';SslMode = none;")));
            services.AddScoped<IMediator, Mediator>();
            services.AddTransient<ServiceFactory>(sp => t => sp.GetService(t));
                //  services.AddMediatR(Assembly.GetExecutingAssembly());
          //  services.AddScoped(typeof(IEventStore),typeof(EventStore));
            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped<IQueryBus, QueryBus>();
            services.AddScoped<IEventBus, EventBus>();
            services.AddScoped<INotificationHandler<OrderCreated>, OrderEventHandler>();
            services.AddScoped<IRequestHandler<CreateOrderRequestModel, Unit>, CreateOrderCommandHandler>();
            services.AddEFStore();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.EventDomainDbCreated();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}