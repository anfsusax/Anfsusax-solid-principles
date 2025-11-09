 
using BiblicalArchitecture.Domain.Interfaces;
using BiblicalArchitecture.Domain.Servicos;
using BiblicalArchitecture.Infrastructure.Data;
using BiblicalArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BiblicalArchitecture.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuração do DbContext com SQLite
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(
                    configuration.GetConnectionString("DefaultConnection") ?? "Data Source=BiblicalArchitecture.db",
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // Registro dos repositórios
            services.AddScoped<IModuloRepository, ModuloRepository>();

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Registro dos serviços de domínio
            services.AddScoped<IModuloService, ModuloService>();
            services.AddScoped<ISolidService, SolidService>();

            return services;
        }
    }
}
