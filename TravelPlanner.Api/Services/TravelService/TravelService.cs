using TravelPlanner.Api.Data;
using TravelPlanner.Api.DTOs.Requests;
using TravelPlanner.Api.DTOs.Responses;
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

        // This method currently returns mock destination suggestions based on the user's budget and trip length.
        public async Task<DestinationResponseDto> GetDestinationsAsync(DestinationRequestDto request)
        {
            var response = new DestinationResponseDto
            {
                Summary = $"Based on your budget of {request.Budget} SEK for {request.Days} day(s), here are some destination suggestions.",
                Destinations = new List<string> { "Prague", "Lisbon", "Oslo" },
                QualityNotes = "These are AI-style mock suggestions. Real AI integration will replace this later.",
                TraceId = Guid.NewGuid().ToString()
            };

            return await Task.FromResult(response);
        }


        // This method currently returns a mock travel plan for the selected destination. It simulates what an AI-generated travel plan might look like.
        public async Task<TravelPlanResponseDto> CreateTravelPlanAsync(TravelPlanRequestDto request)
        {
            var response = new TravelPlanResponseDto
            {
                SelectedDestination = request.Destination,
                Summary = $"Your travel plan for {request.Destination} is ready.",
                EstimatedCost = 0,
                TravelPlanText = $"Day 1: Explore the city center in {request.Destination}. Day 2: Visit local attractions and try local food.",
                QualityNotes = "This is a mock travel plan. Real AI integration will replace this later.",
                TraceId = Guid.NewGuid().ToString()
            };

            return await Task.FromResult(response);

        }
    }
}



