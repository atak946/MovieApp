using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Application.Abstract;
using MovieApp.Infrastructure.Repository.HangFire;
using System;

namespace MovieApp.Infrastructure.IoC
{
    public static class HangfireApplicationBuilder
    {
        public static IApplicationBuilder UseHangfire(this IApplicationBuilder app)
        {
            app.UseHangfireDashboard();

            return app;
        }

        public static IApplicationBuilder UseMovieOperationSchedule(this IApplicationBuilder app, IConfiguration configuration)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var recService = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();
                var movService = scope.ServiceProvider.GetRequiredService<IMovieService>();
                Int32.TryParse(configuration["MovieDb:DataLimit"], out int dataLimit);

                new MovieOperation
                (
                    recService,
                    movService,
                    dataLimit <= 0 ? 100 : dataLimit
                );
            }

            return app;
        }
    }
}
