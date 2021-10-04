using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservation_Persistence.Repositories;

namespace Reservation_Persistence
{
    public static class PersistenceContainer
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services,IConfiguration configration)
        {
            services.AddDbContext<ReservationDbContext>(options =>
            options.UseSqlServer(configration.GetConnectionString("ReservationConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IReservationRepository), typeof(ReservationRepository));
            return services;
        }
    }
}
