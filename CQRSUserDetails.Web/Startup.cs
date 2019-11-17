using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSUserDetails.Web.Application.UserDetails.Commands;
using CQRSUserDetails.Web.Application.UserDetails.Commands.CommandsHandlers;
using CQRSUserDetails.Web.Application.UserDetails.Dtos;
using CQRSUserDetails.Web.Application.UserDetails.Queries;
using CQRSUserDetails.Web.Application.UserDetails.Queries.Handlers;
using CQRSUserDetails.Web.Core;
using CQRSUserDetails.Web.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace CQRSUserDetails.Web
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

            services
                .AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<UserDetailsContext>();

            services.AddSingleton<IDispatcher, Dispatcher>();

            services.AddTransient<ICommandHandler<AddUserDetails>, AddUserDetailsHandler>();
            services.AddTransient<IQueryHandler<GetUserDetails, UserDetailsDto>, GetUserDetailsHandler>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
