using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizMaster.API.Services;
using QuizMaster.API.Services.Interfaces;
using QuizMaster.Shared.Models;
using QuizMaster.API.Data;
namespace QuizMaster.API
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
            services.AddMvc();
            bool.TryParse(Configuration["Connections:useSqlite"], out var useSqlite);
            var sqliteFile = Configuration["Connections:sqliteFile"];
            if (!useSqlite)
            {

                services.AddSingleton<IDataService<Quiz>, MockQuizService>()
                    .AddSingleton<IDataService<Answer>, MockAnswerService>()
                    .AddSingleton<IDataService<Question>, MockQuestionService>()
                    .AddSingleton<IDataService<Round>, MockRoundService>();
            }
            else
            {
                services.AddDbContext<QuizContext>(
                    options => options.UseSqlite($"Data source={sqliteFile}"));
                services.AddScoped<IDataService<Quiz>, QuizService>()
                    .AddScoped<IDataService<Answer>, AnswerService>()
                    .AddScoped<IDataService<Question>, QuestionService>()
                    .AddScoped<IDataService<Round>, RoundService>();

            }
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin());
            app.UseMvcWithDefaultRoute();

            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}