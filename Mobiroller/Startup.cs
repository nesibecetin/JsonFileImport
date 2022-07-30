using Business.Abstract;
using Business.Authentication;
using Business.Concrete;
using Business.Logger;
using BusinessLayer.Abstract;
using BusinessLayer.Caching;
using BusinessLayer.Caching.InMemory;
using BusinessLayer.Concrete;
using BusinessLayer.ExceptionHandler;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobiroller
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
            services.AddMemoryCache();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mobiroller", Version = "v1" });
            });
            // services.AddScoped<IJsonTrSercive, JsonTrManager>();
            // services.AddScoped<IJsonTrDal, JsonTrRepository>();
            services.AddScoped<IJsonFileService, JsonFileManager>();
            services.AddScoped<IJsonFileDal, JsonFileRepository>();
            // services.AddScoped<IJsonItService, JsonItManager>();
            //  services.AddScoped<IJsonItDal, JsonItRepository>();
            services.AddScoped<IAuthenticationService, AuthenticationManager>();
            services.AddScoped<IUserDal, UserRepository>();
            services.AddScoped<IUserService, UserManager>();
            services.AddSingleton<ILoggerService, ConsoleLog>();
            services.AddScoped<IStringResourcesDal, StringRecourcesRepository>();
            services.AddScoped<IStringResourcesService, StringResourcesManager>();
            services.AddScoped<ILanguageDal, LanguageRepository>();
            services.AddScoped<ILanguageService, LanguageManager>();
            services.AddScoped<ILocalizationService, LocalizationManager>();
            services.AddScoped<ICacheManager, MemoryCacheManager>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Token:Issuer"],
                    ValidAudience = Configuration["Token:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mobiroller v1"));
            }
            app.UseExceptionMiddleware();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
