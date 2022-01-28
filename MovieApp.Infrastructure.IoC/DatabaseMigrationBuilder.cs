using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Infrastructure.Context;

namespace MovieApp.Infrastructure.IoC
{
    public static class DatabaseMigrationBuilder
    {
        public static IApplicationBuilder ApplySQLMigration(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                context.Database.Migrate();
            }

            return app;
        }
    }
}
