using Microsoft.Extensions.DependencyInjection;
using MovieApp.Application.Abstract;
using MovieApp.Application.Services;
using MovieApp.Domain.Abstract;
using MovieApp.Infrastructure.Repository;
using Hangfire;
using Hangfire.MemoryStorage;

namespace MovieApp.Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDependencyContainerServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWorkRepository>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IMovieCommentService, MovieCommentService>();

            services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseMemoryStorage()
            );

            services.AddHangfireServer();

            return services;
        }
    }
}
