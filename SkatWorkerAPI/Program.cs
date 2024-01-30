using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SkatWorkerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            string applicationDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string skatWorkerFullPath = Path.Combine(applicationDataPath, "SkatWorker");

            if (!Directory.Exists(skatWorkerFullPath))
                Directory.CreateDirectory(skatWorkerFullPath);

            var host = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseContentRoot(skatWorkerFullPath);
                });

            return host;
        }
    }
}
