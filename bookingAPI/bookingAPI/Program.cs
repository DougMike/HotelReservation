using bookingAPI.Data.Context;
using bookingAPI.Data.Repository;
using bookingAPI.Infra.Repository;
using bookingAPI.Models;
using bookingAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = @"Server=DESKTOP-3M5HJ5O\SQLEXPRESS;Database=Booking;Trusted_Connection=True;";
builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IBaseService<Booking>, BookingService>();
builder.Services.AddScoped<IRepository<Booking>, BookingRepository>();



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
