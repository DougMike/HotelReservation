﻿using bookingAPI.Data.Context;
using bookingAPI.Data.IRepository;
using Microsoft.EntityFrameworkCore;

namespace bookingAPI.Data.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelContext _hotelContext;

        public RoomRepository(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;

        }

        public async Task<IEnumerable<Room>> GetAll()
        {
            return await _hotelContext.Rooms
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Room> GetById(Guid id)
        {
            return await _hotelContext.Rooms.FirstAsync(r => r.Id == id);
        }

        public void Dispose()
        {
            _hotelContext.Dispose();
        }

        public void Add(Room entity)
        {
            _hotelContext.Rooms.AddAsync(entity);
        }
    }
}
