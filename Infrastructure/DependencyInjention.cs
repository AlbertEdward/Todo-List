using Newtonsoft.Json.Serialization;
using TodoList.Services;

namespace TodoList.Infrastructure
{
    public static class DependencyInjention
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IToDoService, ToDoService>();

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });

            return services;
        }
    }
}
