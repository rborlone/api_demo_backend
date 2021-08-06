using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using Microsoft.Extensions.Logging;
using GlobalErrorHandling.Extensions;

using WebApi.Middleware;
using ApiDemo.Infra;
using Microsoft.EntityFrameworkCore;
using APIDemo.Domain.Model.UsuarioAggregate;
using ApiDemo.Infra.Repository;
using APIDemo.Domain.Model.TareaAggregate;

namespace ApiDemo.WebApi
{
    public class Startup
    {
        readonly string OrigenCors = "OrigenCors";

        public Startup(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // Este método es llamado por el tiempo de ejecución. Utilice este método para agregar servicios al contenedor.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors(options =>
            {
                options.AddPolicy(name: OrigenCors,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });

            //Agregamos esto para que al retornar la informacion en el controlador las entidades serializadas puedan manejar el loop de referencias.
            services.AddControllers().AddNewtonsoftJson(
                options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //Swagger para el front de la api por alguna razon el candadito queda al verez.
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIDemo.WebApi", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    In = ParameterLocation.Header,
                    Description = "Bearer Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
            });

            ///Inyeccion de dependencias (Por favor dejar ordenado alfabeticamente.)
            services.AddScoped<DatabaseContext, DatabaseContext>();

            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IUsuarioService, UsuarioService>();

            services.AddTransient<ITareaRepository, TareaRepository>();
            services.AddTransient<ITareaService, TareaService>();
        }

        // Este método es llamado por el tiempo de ejecución. Utilice este método para configurar la canalización de solicitudes HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory factory, ILogger<Startup> logger, DatabaseContext data)
        {
            data.Database.EnsureCreated();
            data.Database.Migrate();
            
            // el swagger solo se mostrara en ambiente desarrollo.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIDemo.WebApi v1"));
            }

            ///Agregamos el Serilog.
            factory.AddSerilog();

            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == (int)System.Net.HttpStatusCode.Unauthorized)
                {
                    logger.LogCritical("Unauthorized request");
                }
            });

            app.UseRouting();

            //CORS
            app.UseCors(OrigenCors);

            //Manejo global de errores.
            app.UseMiddleware<ErrorHandlerMiddleware>();

            //Middleware para utilizar validacion JWT antes de ingresar al controller.
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.ConfigureExceptionHandler(Log.Logger);
        }
    }
}
