using EventBooking.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using EventBooking.Interface;

namespace EventBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {

        private readonly IEventRepository _eventRepository;

        public class Event
        {

        }

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        // GET: api/event
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            var Eve= await _eventRepository.GetAllAsync();
            return Ok(Eve);
        }



    }
}
