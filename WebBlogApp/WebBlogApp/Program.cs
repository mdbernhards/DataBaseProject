using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebBlogApp
{
    /// <summary>
    /// Starts the program
    /// <summary>
    public class Program
    {
        /// <summary>
        /// Calls the createHostBuilder method that starts and builds the API
        /// <summary>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Starts and creates  the builder for the API
        /// <summary>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}