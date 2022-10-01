using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;

namespace TodoList.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PreparedDatabase(
            this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var service = serviceScope.ServiceProvider;

            MigrateDatabase(service);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider service)
        {
            var data = service.GetRequiredService<ToDoListDbContext>();

            data.Database.Migrate();
        }
    }
}