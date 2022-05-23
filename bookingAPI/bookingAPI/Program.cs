using bookingAPI.Data.Context;
using bookingAPI.Infra.IRepository;
using bookingAPI.Infra.Repository;
using bookingAPI.Services;
using bookingAPI.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = @"Server=DESKTOP-3M5HJ5O\SQLEXPRESS;Database=Booking;Trusted_Connection=True;";
builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IGuestService, GuestService>();
builder.Services.AddScoped<IRoomService, RoomService>();


builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IGuestRepository, GuestRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IBookingRequestRepository, BookingRequestRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
