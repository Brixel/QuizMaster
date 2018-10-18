using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace QuizMaster.SocketApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("0.0.0.0:3000")
                .UseStartup<Startup>();
    }
}