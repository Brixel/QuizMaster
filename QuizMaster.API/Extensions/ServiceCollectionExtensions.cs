using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace QuizMaster.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAllAuthentication(this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddAuthentication()
                .AddFacebook(facebookOptions =>
                {
                    facebookOptions.AppId = configuration["Authentication:Facebook:AppId"];
                    facebookOptions.AppSecret = configuration["Authentication:Facebook:AppSecret"];
                })
                .AddTwitter(twitterOptions =>
                {
                    twitterOptions.ConsumerKey = configuration["Authentication:Twitter:ConsumerKey"];
                    twitterOptions.ConsumerSecret = configuration["Authentication:Twitter:ConsumerSecret"];
                })
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
                    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
                })
                .AddMicrosoftAccount(microsoftOptions =>
                {
                    microsoftOptions.ClientId = configuration["Authentication:Microsoft:ClientId"];
                    microsoftOptions.ClientSecret = configuration["Authentication:Microsoft:ClientSecret"];
                })
                .AddGitHub(gitHubOptions =>
                {
                    gitHubOptions.ClientId = configuration["Authentication:GitHub:ClientId"];
                    gitHubOptions.ClientSecret = configuration["Authentication:GitHub:ClientSecret"];
                });

            return services;
        }
    }
}