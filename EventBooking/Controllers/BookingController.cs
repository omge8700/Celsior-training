using Microsoft.AspNetCore.Mvc;
using EventBooking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EventBooking.Interface;

namespace EventBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IEventRepository _eventRepository;

        public BookingController(IBookingRepository bookingRepository, IEventRepository eventRepository)
        {
            _bookingRepository = bookingRepository;
            _eventRepository = eventRepository;
        }

        // POST: api/booking
        [HttpPost]
        public async Task<ActionResult<Booking>> BookEvent(Booking booking)
        {
            var eventToBook = await _eventRepository.GetByIdAsync(booking.EventId);

            if (eventToBook == null)
            {
                return NotFound("Event not found.");
            }

            if (eventToBook.AvailableSeats > 0)
            {
                await _bookingRepository.AddAsync(booking);
                eventToBook.AvailableSeats--;
                await _eventRepository.SaveChangesAsync();
                await _bookingRepository.SaveChangesAsync();

                return CreatedAtAction(nameof(BookEvent), new { id = booking.BookingId }, booking);
            }

            return BadRequest("No available seats for this event.");
        }
    }
}

