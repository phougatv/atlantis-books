namespace Atlantis.WebApi
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
            var configuration = GetConfiguration(environment);
            var loggerFactory = GetLoggerFactory();
            var logger = loggerFactory.CreateLogger<Program>();
            try
            {
                logger.LogInformation("Initializing the Atlantis host...");
                CreateHostBuilder(args, configuration, loggerFactory)
                    .Build()
                    .Run();
            }
            catch (Exception ex)
            {
                logger.LogCritical("Atlantis host terminated unexpectedly!");
#if DEBUG
                logger.LogError($"Error message: {ex.Message}");
#endif
            }
            finally
            {
                logger.LogInformation("Disposing LoggerFactory...");
                loggerFactory.Dispose();
            }
        }

        /// <summary>
        /// Creates an instance of the host builder.
        /// </summary>
        /// <param name="args">The args <see cref="string[]"/>.</param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(
            string[] args,
            IConfiguration configuration,
            ILoggerFactory loggerFactory)
        {
            return Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup(context =>
                    {
                        return new Startup(configuration, context.HostingEnvironment, loggerFactory.CreateLogger<Startup>());
                    });
                });
        }

        #region Private Static Methods
        /// <summary>
        /// Gets the logger factory <see cref="ILoggerFactory"/>.
        /// </summary>
        /// <returns></returns>
        private static ILoggerFactory GetLoggerFactory() => LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
            builder.AddDebug();
        });

        /// <summary>
        /// Gets the configuration <see cref="IConfiguration"/>.
        /// </summary>
        /// <param name="environment"></param>
        /// <returns></returns>
        private static IConfiguration GetConfiguration(string environment) => new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environment}.json", true, true)
                .Build();
        #endregion Private Static Methods
    }
}
