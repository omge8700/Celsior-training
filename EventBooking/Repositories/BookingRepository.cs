using EventBooking.Context;
using EventBooking.Interface;
using EventBooking.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace EventBooking.Repositories
{
    public class BookingRepository
    {
        private readonly CorporateEventContext _context;

        public BookingRepository(CorporateEventContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Booking entity)
        {
            await _context.Bookings.AddAsync(entity);
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            return await _context.Bookings.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
