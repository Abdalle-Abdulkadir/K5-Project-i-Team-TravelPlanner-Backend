using System.ComponentModel.DataAnnotations;

namespace TravelPlanner.Api.DTOs.Requests;

public class DestinationRequestDto
{
    [Required]
    [Range(1000, double.MaxValue, ErrorMessage = "Budget must be at least 1000 SEK.")]
    public decimal? Budget { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Trip must be at least 1 day.")]
    public int? Days { get; set; }

    [Required]
    public DateTime? DepartureDate { get; set; }
}

