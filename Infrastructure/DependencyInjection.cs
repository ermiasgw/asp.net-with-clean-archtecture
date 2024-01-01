
using Application;
using Domain.Repositories;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();

            services.AddScoped(typeof(ITaskRepository), typeof(TaskRepository));
            services.AddScoped(typeof(IUnitofWork), typeof(UnitofWork));
            return services;
        }
    }
}
