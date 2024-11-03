using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBooking.Models
{
    public class BookingEvent
    {
        [Key]
        public int EventId { get; set; }

        [Column("EventName")]
        public string Name { get; set; }
        [Column("EventDescription")]
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public int AvailableSeats { get; set; }

    }
}
