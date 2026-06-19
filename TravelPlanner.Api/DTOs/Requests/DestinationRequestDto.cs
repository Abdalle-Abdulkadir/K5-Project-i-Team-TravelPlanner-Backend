using System;
using System.ComponentModel.DataAnnotations;

namespace TravelPlanner.Api.DTOs.Requests
{
    public class DestinationRequestDto
    {
        [Required(ErrorMessage = "Budget is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "Budget must be a positive number greater than 0.")]
        public decimal Budget { get; set; }

        [Required(ErrorMessage = "Number of days is required.")]
        [Range(1, 365, ErrorMessage = "Number of days must be between 1 and 365.")]
        public int Days { get; set; } 

        [Required(ErrorMessage = "Departure date is required.")]
        public DateTime DepartureDate { get; set; }
    }
}