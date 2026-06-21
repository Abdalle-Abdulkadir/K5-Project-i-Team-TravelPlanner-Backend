namespace TravelPlanner.Api.DTOs.Responses
{
    // Returned to the frontend with AI-generated destination suggestions
    public class DestinationResponseDto
    {
        public string Summary { get; set; } = string.Empty;

        public List<string> Destinations { get; set; } = new();
        public string QualityNotes { get; set;} = string.Empty;
        public string TraceId { get; set; } = string.Empty;
    }

}
