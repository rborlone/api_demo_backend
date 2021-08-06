using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace ApiDemo.WebApi
{
    /// <summary>
    /// Clase inicial y punto de entrada a la api, genera la configuracion inicial de donde obtener las configuraciones.
    /// </summary>
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
             .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
             .Build();

        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();

            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Se produjo un error en la aplicacion a nivel general.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        /// <summary>
        /// Generamos el Web Hostbuilder y especificamos en el host la configuracion del application insight la cual quedara registrada en Azure como logs.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {

            return WebHost.CreateDefaultBuilder(args)
                               .UseStartup<Startup>()
                               .ConfigureLogging(
                                    logging =>
                                        logging.AddFilter<Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider>
                                        ("", LogLevel.Warning)
                                        .AddFilter<Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider>
                                        ("Microsoft", LogLevel.Error)
                                )
                               .UseConfiguration(Configuration)
                               .UseSerilog();
        }
    }
}
