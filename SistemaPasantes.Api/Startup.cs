using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Core.Services;
using SistemaPasantes.Infrastructure;
using SistemaPasantes.Infrastructure.Repositories;
using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
>>>>>>> 84a87e32ce2ffbc294b26c108c004669fdc14779

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

<<<<<<< HEAD

            //Inyectar JWT Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options=> 
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //Los primeros dos se pueden comentar
                    //Los Parametros del objeto que queremos validar
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Authentication:Issuer"],
                    ValidAudience = Configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:SecretKey"]))
                };
            });


=======
            //
>>>>>>> 84a87e32ce2ffbc294b26c108c004669fdc14779
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Services
            services.AddTransient<IAuthenticationCService, AuthenticationCService>();
            services.AddTransient<IConvocatoriaService, ConvocatoriaService>();
            services.AddTransient<IFormularioService, FormularioService>();

            // UnitOfWork
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //AddNewToSoft to ignore reference loop   options.SerializerSettings.ReferenceLoopHandling
            services.AddControllers().AddNewtonsoftJson(options=> 
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;   
            });

            // Swagger para debugging/testing
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SistemaPasantes.Api", Version = "v1" });
            });

            // Base de datos
            services.AddDbContext<SistemaPasantesContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ConnectionSqlServer")));

            // ?
            services.AddTransient<ITareaRepository, TareaRepository>(); 

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

            //Agregando la autenticacion
            app.UseAuthentication();

            //Agregando la autorizacion
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
