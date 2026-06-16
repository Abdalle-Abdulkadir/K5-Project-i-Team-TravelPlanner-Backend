namespace TravelPlanner.Api.Models
{
    public class TravelRequest
    {
        public decimal Budget { get; set; }
        public int Days { get; set; }
        public string FromLocation { get; set; } = string.Empty;
        public string? Destination { get; set; }
    }
}