using TodoList.Services;

namespace TodoList.Infrastructure
{
    public static class DependencyInjention
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IToDoService, ToDoService>();

            return services;
        }
    }
}
