namespace CoolEvents.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int TravelerId { get; set; }
        public int TripId { get; set; }
        public DateTime TripDate { get; set; }
        public string Status { get; set; }
    }
}
