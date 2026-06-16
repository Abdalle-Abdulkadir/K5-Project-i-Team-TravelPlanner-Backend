using System.Collections.Generic;

namespace TravelPlaner.Api.Models
{
    public class TravelResponse
    {
        public string Summary { get; set; } = string.Empty;
        public List<string> Destinations { get; set; } = new();
        public string? SelectedDestination { get; set; }
        public decimal EstimatedCost { get; set; }
        public List<DailyPlan> TravelPlan { get; set; } = new();
        public string QualityNotes { get; set; } = string.Empty;
        public string TraceId { get; set; } = string.Empty;
    }

    public class DailyPlan
    {
        public int Day { get; set; }
        public List<string> Activities { get; set; } = new();
    }
}