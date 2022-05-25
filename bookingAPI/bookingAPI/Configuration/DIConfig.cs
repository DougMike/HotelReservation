using bookingAPI.Data.Context;
using bookingAPI.Infra.IRepository;
using bookingAPI.Infra.Repository;
using bookingAPI.Services;
using bookingAPI.Services.IServices;

namespace bookingAPI.Configuration
{
    public static class DIConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IGuestService, GuestService>();
            services.AddScoped<IRoomService, RoomService>();


            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IGuestRepository, GuestRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IBookingRequestRepository, BookingRequestRepository>();

            services.AddScoped<HotelContext>();
        }
    }
}
