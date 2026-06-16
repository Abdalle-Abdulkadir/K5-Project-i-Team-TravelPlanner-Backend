using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TravelPlaner.Api.Models;

namespace TravelPlaner.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TravelController : ControllerBase
    {
        // 1. Health Check Endpoint
        [HttpGet("health")]
        public IActionResult HealthCheck()
        {
            return Ok(new { status = "Healthy", timestamp = DateTime.UtcNow });
        }

        // 2. Endpoint for destinations suggestions based on budget
        [HttpPost("destinations")]
        public ActionResult<TravelResponse> GetDestinations([FromBody] TravelRequest request)
        {
            if (request == null || request.Budget <= 0 || request.Days <= 0)
            {
                return BadRequest("Invalid budget or number of days.");
            }

            var response = new TravelResponse
            {
                Summary = $"Here are some destinations that match your budget of {request.Budget} SEK for a {request.Days}-day trip.",
                Destinations = new List<string> { "Barcelona, Spain", "Rome, Italy", "Prague, Czech Republic" },
                EstimatedCost = request.Budget * 0.8m,
                QualityNotes = "Based on current seasonal data. Prices may vary depending on airlines.",
                TraceId = Guid.NewGuid().ToString() // For Observability (VG requirement)
            };

            return Ok(response);
        }

        // 3. Endpoint for generating a detailed travel itinerary
        [HttpPost("generate-plan")]
        public ActionResult<TravelResponse> GenerateTravelPlan([FromBody] TravelRequest request)
        {
            if (string.IsNullOrEmpty(request.Destination))
            {
                return BadRequest("Destination must be provided to generate a travel plan.");
            }

            var mockTravelPlan = new List<DailyPlan>();
            for (int i = 1; i <= request.Days; i++)
            {
                mockTravelPlan.Add(new DailyPlan
                {
                    Day = i,
                    Activities = new List<string>
                    {
                        $"City walk and sightseeing in {request.Destination}",
                        "Try local cuisine at a traditional restaurant"
                    }
                });
            }

            var response = new TravelResponse
            {
                Summary = $"Your detailed travel itinerary for {request.Destination} is ready.",
                SelectedDestination = request.Destination,
                EstimatedCost = request.Budget,
                TravelPlan = mockTravelPlan,
                QualityNotes = "AI-generated plan. Please verify opening hours for local attractions.",
                TraceId = Guid.NewGuid().ToString()
            };

            return Ok(response);
        }
    }
}