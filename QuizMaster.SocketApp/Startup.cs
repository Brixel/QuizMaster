using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using QuizMaster.Shared.Models;
using QuizMaster.SocketApp.Hubs;
using QuizMaster.SocketApp.Services;
using QuizMaster.SocketApp.Services.Interfaces;

namespace QuizMaster.SocketApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDataService<Game>, MockGameService>()
                .AddSingleton<IDataService<User>, MockUserService>()
                .AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSignalR(routes =>
            {
                routes.MapHub<GameHub>("/game");
            });
        }
    }
}