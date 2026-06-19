using System.ComponentModel.DataAnnotations;

namespace TravelPlanner.Api.DTOs.Requests;

// Sent from the frontend when the user selects a destination
public class TravelPlanRequestDto
{
    [Required]
    public string Destination { get; set; } = string.Empty;

    [Required]
    public int TravelRequestId { get; set; }
}

