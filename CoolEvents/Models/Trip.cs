using System.ComponentModel.DataAnnotations.Schema;

namespace CoolEvents.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        public int? DestinationId { get; set; } // Foreign key for Destination
        [ForeignKey("DestinationId")]
        public Destination? Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
