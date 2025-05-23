using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BloodBank.Infra
{
    public static class InfraModule
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddData(configuration);

            return services;
        }
        private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("BloodBankCs");
            services.AddDbContext<BloodBankDbContext>(o => o.UseSqlServer(connectionString));

            return services;
        }
    }
}
