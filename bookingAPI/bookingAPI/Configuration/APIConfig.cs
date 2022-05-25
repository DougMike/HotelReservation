using bookingAPI.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace bookingAPI.Configuration
{
    public static class APIConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HotelContext>(option => 
            option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging());

        }
    }
}
