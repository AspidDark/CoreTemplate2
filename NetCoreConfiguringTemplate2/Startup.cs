using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCoreConfiguringTemplate2.Extensions;
using NetCoreConfiguringTemplate2.Mapping;
using NetCoreConfiguringTemplate2.PipelineBehaviors;
using NetCoreConfiguringTemplate2.Repositories;
using NetCoreConfiguringTemplate2.Repositories.Cached;

namespace NetCoreConfiguringTemplate2
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

            #region Scrutor
            services.AddSingleton<ICustomersRepository, CustomersRepository>();
            services.Decorate<ICustomersRepository, CachedCustomersRepository>();
            #endregion

            services.AddSingleton<ICustomersRepository, CustomersRepository>();
            services.AddSingleton<IOrdersRepository, OrdersRepository>();
            services.AddSingleton<IMapper, Mapper>(); //custom bad mapper
            services.AddMediatR(typeof(Startup)); //scan for handlers and register them
            #region //validation from here
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(typeof(Startup).Assembly);
            #endregion
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

            app.UseFluentValidationExceptionHandler();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
