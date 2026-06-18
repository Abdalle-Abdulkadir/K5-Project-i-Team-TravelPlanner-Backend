namespace TravelPlanner.Api.DTOs.Responses;

// Returned to the frontend with a complete travel plan
public class TravelPlanResponseDto
{
    public string SelectedDestination { get; set; } = string.Empty;

    public decimal EstimatedCost { get; set; }

    public string TravelPlanText { get; set; } = string.Empty;

    public string QualityNotes { get; set; } = string.Empty;
    public string TraceId { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
}

