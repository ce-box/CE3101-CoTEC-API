using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CotecAPI.DataAccess.Database;
using CotecAPI.DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace CotecAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {   
            // Patch Serialization
            services.AddControllers().AddNewtonsoftJson(
                s =>  {
                    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    s.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            // Customize our CORS policy
            services.AddCors(o => o.AddPolicy(
                "CORS_POLICY", 
                builder => {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                }));

            // DbContext Dependency Injection (CotecContext implements DbContext Interface)
            services.AddDbContext<CotecContext>(opt => opt.UseSqlServer
                (Configuration.GetConnectionString("CotecConnection")));
            
            // Mapper Dependency Injection (Every class that implements Profile Interface)
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            
            // Repository Dependency injection
            services.AddScoped<UserRepo>();

            services.AddScoped<CasesRepo>();
            services.AddScoped<MeasuresRepo>();
            services.AddScoped<RegionRepo>();
            
            services.AddScoped<StatusRepo>();
            services.AddScoped<HospitalRepo>();
            services.AddScoped<PatientRepo>();
            services.AddScoped<ContactRepo>();

            services.AddScoped<MedicationRepo>();
            services.AddScoped<PathologyRepo>();
            
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Apply CORS Policy to every request
            app.UseCors("CORS_POLICY");

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
