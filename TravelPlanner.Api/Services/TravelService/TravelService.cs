using TravelPlanner.Api.Data;
using TravelPlanner.Api.DTOs.Requests;
using TravelPlanner.Api.DTOs.Responses;
using TravelPlanner.Api.Models;
using TravelPlanner.Api.Services.GrokAIService;

namespace TravelPlanner.Api.Services.TravelService
{
    public class TravelService : ITravelService
    {
        private readonly AppDbContext _context;
        private readonly IGrokAIService _grokAIService;

        public TravelService(AppDbContext context, IGrokAIService grokAIService)
        {
            _context = context;
            _grokAIService = grokAIService;
        }

        public async Task<DestinationResponseDto> GetDestinationsAsync(DestinationRequestDto request)
        {
            // Save the user's original search request
            var travelRequest = new TravelRequest
            {
                Budget = request.Budget!.Value,
                Days = request.Days!.Value,
                DepartureDate = request.DepartureDate!.Value,
                FromLocation = "Stockholm"
            };

            //_context.TravelRequests.Add(travelRequest);
            //await _context.SaveChangesAsync();

            // Ask Grok AI for destination suggestions
            var response = await _grokAIService.GetDestinationsAsync(request);

            // Send back the saved request id inside TraceId for now
            response.TraceId = travelRequest.Id.ToString();

            return response;
        }

        public async Task<TravelPlanResponseDto> CreateTravelPlanAsync(TravelPlanRequestDto request)
        {
            // Ask Grok AI to create the full travel plan
            var response = await _grokAIService.CreateTravelPlanAsync(request);

            // Save selected destination and generated travel plan
            var travelResponse = new TravelResponse
            {
                TravelRequestId = request.TravelRequestId,
                SelectedDestination = response.SelectedDestination,
                EstimatedCost = response.EstimatedCost,
                TravelPlanText = string.Join("\n", response.TravelPlanText),
                QualityNotes = string.Join("\n", response.QualityNotes),
                Summary = response.Summary,
                TraceId = response.TraceId
            };

            //_context.TravelResponses.Add(travelResponse);
            //await _context.SaveChangesAsync();

            return response;
        }
    }
}



