using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Log = Serilog.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Serilog.Events;
using Inventory.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Inventory.API.Extensions.Factories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;

namespace Inventory.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.File(
              path: Path.Combine("Logs", "log.txt"),
              outputTemplate:
              "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
              rollingInterval: RollingInterval.Day,
              restrictedToMinimumLevel: LogEventLevel.Information
              ).CreateLogger();

            var host = CreateWebHostBuilder(args).Build();

            InitializeDb(host);
            host.RunAsync().Wait();
        }

        /// <summary>
        /// initialize the database
        /// </summary>
        /// <param name="host"></param>
        private static void InitializeDb(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dataContext = services.GetRequiredService<InventoryContext>();
                dataContext.Database.Migrate();
                Seed.SeedData(dataContext).Wait();
            }
            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
             .ConfigureLogging((logging) =>
             {
                 logging.ClearProviders();
                 logging.AddConsole();
             })
            .UseStartup<Startup>();


    }
}
