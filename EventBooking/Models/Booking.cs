namespace EventBooking.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int EventId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
    }
}
