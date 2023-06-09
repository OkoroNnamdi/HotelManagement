﻿using HotelManagement.Core.Domains;
using HotelManagement.Core.IRepositories;
using HotelManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Infrastructure.Repositories
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        private readonly HotelDbContext _hotelDbContext;

        public HotelRepository(HotelDbContext hotelDbContext) : base(hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }

        public async void AddHotel(string Manager_ID, Hotel hotel)
        {
            hotel.ManagerId = Manager_ID;

            await AddAsync(hotel);
        }

        public async Task DeleteAsync(Hotel entity)
        {
            _dbSet.Remove(entity);
        }

        public async  Task SaveChangesAsync()
        {
            await _hotelDbContext.SaveChangesAsync();   
        }

        public async Task UpdateAsync(Hotel hotel)
        {
            _hotelDbContext.Entry(hotel).State = EntityState.Modified;
            await _hotelDbContext.SaveChangesAsync();
        }

        void IHotelRepository.UpdateAsync(Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }

}
