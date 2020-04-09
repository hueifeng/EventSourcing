using Domain.Commands;
using Domain.Context;
using Domain.Events;
using Domain.Queries;
using Domain.Repository.EventSourcing;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            // services.AddStackExchangeRedisCache(options =>
            // {
            //     options.Configuration = "localhost";
            //     options.InstanceName = "SampleInstance";
            // });
            services.AddScoped<IEventBus,EventBus>();
            services.AddScoped<IEventStore,SqlEventStore>();
            services.AddScoped<IEventStoreRepository,EventStoreSqlRepository>();
            services.AddDbContext<EventStoreSQLContext>(options =>
                options.UseMySql("server=39.108.58.66;database=ctrlframework;uid=ctrlframework;pwd=zzcfyE6YpGa3JLhZ;charset='utf8';SslMode = none;"));
            services.AddScoped<IMediator, Mediator>();
            services.AddTransient<ServiceFactory>(sp => t => sp.GetService(t));
                //  services.AddMediatR(Assembly.GetExecutingAssembly());
          //  services.AddScoped(typeof(IEventStore),typeof(EventStore));
            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped<IQueryBus, QueryBus>();
            services.AddScoped<IEventBus, EventBus>();
            services.AddScoped<INotificationHandler<OrderCreated>, OrderEventHandler>();
            services.AddScoped<IRequestHandler<CreateOrderRequestModel, Unit>, CreateOrderCommandHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}