
using AutoMapper;
using InfoShareApp.API.Common.Repository;
using InfoShareApp.API.Common.Services;
using InfoShareApp.API.Common.Services.Storage;
using InfoShareApp.API.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace InfoShareApp.API.Application
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

            services.Configure<InfoShareDatabaseSettings>(Configuration.GetSection(nameof(InfoShareDatabaseSettings)));
            services.AddSingleton<IInfoShareDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<InfoShareDatabaseSettings>>().Value);
            services.AddSingleton<IMongoDbService, MongoDbService>();


            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddAutoMapper();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
