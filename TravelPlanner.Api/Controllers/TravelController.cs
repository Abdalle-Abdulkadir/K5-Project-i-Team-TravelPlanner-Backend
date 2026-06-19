using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TravelPlanner.Api.DTOs.Requests;
using TravelPlanner.Api.DTOs.Responses;
using TravelPlanner.Api.Models; 
using TravelPlanner.Api.Services.TravelService;
using Microsoft.AspNetCore.RateLimiting;

namespace TravelPlanner.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableRateLimiting("TravelPolicy")]
    public class TravelController : ControllerBase
    {
        private readonly ITravelService _travelService;

        public TravelController(ITravelService travelService)
        {
            _travelService = travelService;
        }


        //Checks if the API is running and healthy
        [HttpGet("health")]
        public async Task<IActionResult> HealthCheck()
        {
            return Ok(new
            {
                status = "Healthy",
                timestamp = DateTime.UtcNow
            });
        }

        // Returns AI-generated destination suggestions based on user budget and trip length
        [HttpPost("destinations")]
        public async Task<IActionResult> GetDestinations([FromBody] DestinationRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (request.DepartureDate <DateTime.Today)
            {
                return BadRequest("Departure date cannot be in the past.");
            }


            var response = await _travelService.GetDestinationsAsync(request);

            return Ok(response);
        }


        // Generates a detailed travel plan for the destination selected by the user
        [HttpPost("plan")]
        public async Task<IActionResult> GenerateTravelPlan([FromBody] TravelPlanRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var response = await _travelService.CreateTravelPlanAsync(request);

            return Ok(response);
        }


        // Returns all previously saved travel requests from the database
        [HttpGet("saved")]
        public IActionResult GetSavedTrips()
        {

            return Ok();
        }


    }
}
