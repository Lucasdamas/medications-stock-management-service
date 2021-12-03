using MedicinesStoreAPI.Database.Context;
using MedicinesStoreAPI.Database.Repositories.Implementations;
using MedicinesStoreAPI.Database.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedicinesStoreAPI.StartupConfiguration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.SetupDatabase(configuration);
            serviceCollection.AddHttpContextAccessor();
            serviceCollection.AddControllers();
            serviceCollection.AddApiVersioning();
            

            return serviceCollection;
        }

        private static void SetupDatabase(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddTransient<IMedicationRepository, MedicationRepository>();
            serviceCollection.AddDbContext<EventDbContext>(ctx =>
                ctx.UseNpgsql(
                    configuration.GetConnectionString("EventsDbConnectionString"),
                    options => options.EnableRetryOnFailure(1)
                ));
        }
    }
}