
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure
{
    public static class ConfigurationServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            //services.AddMediatR(option =>
            //{
            //    option.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            //}).AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>))
            //.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

            //services.AddScoped<IToDoRepository, ToDoRepository>();
            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
