using System;
using System.Collections.Generic;
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
            services.AddControllers().AddNewtonsoftJson(
                s =>  {
                    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
            
            // Add DbContexts
            services.AddDbContext<CotecContext>(opt => opt.UseSqlServer
                (Configuration.GetConnectionString("CotecConnection")));

            // Customize our CORS policy
            services.AddCors(o => o.AddPolicy(
                "CORS_POLICY", 
                builder => {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                }));
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            
            // TODO: Agregar las Inyecciones de Dependencias
            services.AddScoped<CasesRepo>();
            services.AddScoped<MeasuresRepo>();
            services.AddScoped<UserRepo>();

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
