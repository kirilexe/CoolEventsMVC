namespace CoolEvents.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
