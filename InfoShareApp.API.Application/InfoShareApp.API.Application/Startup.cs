﻿
using AutoMapper;
using InfoShareApp.API.Application.Services;
using InfoShareApp.API.Common.Repository;
using InfoShareApp.API.Common.Services.Storage;
using InfoShareApp.API.Data.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Threading.Tasks;

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


            // Allow sign in via an OpenId Connect provider like OneLogin
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                // Azure Ad IDP
                //options.Authority = "https://login.microsoftonline.com/147a2b71-5ce9-4933-94c4-2054328de565";
                //options.Audience = "c8b7fa4c-afe3-473f-9247-b4ebd27dcf6a";
                //options.TokenValidationParameters = new TokenValidationParameters
                //{
                //    ValidIssuer = "https://login.microsoftonline.com/147a2b71-5ce9-4933-94c4-2054328de565/v2.0"
                //};

                // Auth0 IDP
                options.Authority = "https://dev-y02mpd7s.auth0.com/";
                options.Audience = "https://localhost:44366/api/";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "https://dev-y02mpd7s.auth0.com/",
                    NameClaimType = ClaimTypes.NameIdentifier
                };
            });

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IContactUsService, ContactUsService>();
            services.AddScoped<IContactUsRepository, ContactUsRepository>();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(config =>
            {
                config.RootPath = "./../../client-app/dist";
            });

            services.AddAutoMapper();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("_myAllowSpecificOrigins",
            //    builder =>
            //    {
            //        builder.WithOrigins("http://localhost:4200",
            //                            "http://localhost:44366").AllowAnyHeader().AllowAnyMethod();
            //    });
            //});


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("_myAllowSpecificOrigins");
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseAuthentication();

            app.UseMvc();

            app.UseSpa(spa =>
            {
                //spa.Options.SourcePath = "./../../client-app";

                if (env.IsDevelopment())
                {
                    //spa.UseAngularCliServer(npmScript: "start");
                    //spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }
    }
}
