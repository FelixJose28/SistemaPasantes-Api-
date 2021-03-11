using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Core.Services;
using SistemaPasantes.Infrastructure;
using SistemaPasantes.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPasantes.Api
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
            //Para mapear las entidades con mapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddTransient<IAuthenticationCService, AuthenticationCService>();
            services.AddTransient<IConvocatoriaService, ConvocatoriaService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //AddNewToSoft to ignore reference loop   options.SerializerSettings.ReferenceLoopHandling
            services.AddControllers().AddNewtonsoftJson(options=> 
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;   
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SistemaPasantes.Api", Version = "v1" });
            });

            services.AddDbContext<SistemaPasantesContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ConnectionSqlServer")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SistemaPasantes.Api v1"));
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
