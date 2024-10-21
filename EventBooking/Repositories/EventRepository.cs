using EventBooking.Context;
using EventBooking.Interface;
using EventBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using static EventBooking.Controllers.EventController;


namespace EventBooking.Repositories
{
    public class EventRepository : IEventRepository, IRepository<Event>
    {
        private readonly CorporateEventContext _context;

        public EventRepository(CorporateEventContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Event entity)
        {
           return await _context.Events
                .Include(e => e.Event)

        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            var evee = await _context.Events.ToListAsync();
            return evee;
        }

        public async Task<Event> GetByIdAsync(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
