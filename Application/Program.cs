using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Application
{
    // ReSharper disable once ClassNeverInstantiated.Global
    // Instantiated implicitly through the web api
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        }
    }
}