namespace CoolEvents.Models
{
    public class Package
    {
        public int PackageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<Trip> Trips { get; set; }
    }

}
