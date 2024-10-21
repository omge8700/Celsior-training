using EventBooking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace EventBooking.Context
{
    public class CorporateEventContext : DbContext
    {
        public CorporateEventContext(DbContextOptions<CorporateEventContext> options) : base(options)
        {

        }

        public DbSet<BookingEvent> Events { get; set; }
        public DbSet<Booking> Bookings { get; set; }

    }

}
