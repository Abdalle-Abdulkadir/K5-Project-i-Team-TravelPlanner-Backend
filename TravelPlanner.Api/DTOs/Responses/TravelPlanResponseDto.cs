namespace TravelPlanner.Api.DTOs.Responses;

// Returned to the frontend with a complete travel plan
public class TravelPlanResponseDto
{
    public string SelectedDestination { get; set; } = string.Empty;

    public decimal EstimatedCost { get; set; } 
    public string Currency { get; set; } = "SEK";

    public List<string> TravelPlanText { get; set; } = [];

    public List<string> QualityNotes { get; set; } = [];
    public string TraceId { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    
}

