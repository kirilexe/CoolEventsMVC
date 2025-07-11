using System.ComponentModel.DataAnnotations.Schema;

namespace CoolEvents.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int? TravelerId { get; set; }
        public int? TripId { get; set; }
        public DateTime TripDate { get; set; }
        public string Status { get; set; }

        // Navigation properties
        [ForeignKey("TravelerId")]
        public virtual Traveler? Traveler { get; set; }
        [ForeignKey("TripId")]  
        public virtual Trip? Trip { get; set; }

        // Computed property for Traveler's full name
        public string TravelerFullName => Traveler != null ? $"{Traveler.FirstName} {Traveler.LastName}" : string.Empty;

        // Computed property for Trip display name (Destination City, Country)
        public string TripDisplayName => Trip != null && Trip.Destination != null ? $"{Trip.Destination.City}, {Trip.Destination.Country}" : "";
    }
}
