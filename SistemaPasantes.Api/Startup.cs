using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

using System.Text;


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
            services.AddCors();
            //Para mapear las entidades con mapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            //Inyectar JWT Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options=> 
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
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

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Services
            services.AddTransient<IAuthenticationCRepository, AuthenticationCRepository>();
            services.AddTransient<IConvocatoriaService, ConvocatoriaService>();

            //services.AddTransient<IFormularioService, FormularioService>();
            services.AddTransient<ITareaRepository, TareaRepository>();
            services.AddTransient<IPerfilRepository, PerfilRepository>();


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


            // configuracion para los cors
            services.AddCors(options =>
            {
                options.AddPolicy("CorsApi",
                    builder => builder.WithOrigins("http://localhost:4200", "http://mywebsite.com")
                .AllowAnyHeader()
                .AllowAnyMethod());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
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

            app.UseCors("CorsApi");

            //Agregando la autorizacion
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
