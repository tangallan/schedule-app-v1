using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ScheduleApp.Data.EfCore;
using Microsoft.EntityFrameworkCore;
using ScheduleApp.Core.Interfaces.Repositories;
using ScheduleApp.Domain.Repositories;
using AutoMapper;
using ScheduleApp.Core.Mapping;
using ScheduleApp.WebApi.Middlewares;

namespace ScheduleApp.WebApi
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
            services.AddDbContext<ScheduleAppContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ScheduleAppDatabase")));

            services.AddTransient<IVendorRepository, VendorRepository>();

            Mapper.Initialize(config =>
            {
                config.AddProfile(new EntityAndDtoMappingProfile());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
