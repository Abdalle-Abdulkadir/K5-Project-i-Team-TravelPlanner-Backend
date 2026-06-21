using TravelPlanner.Api.DTOs.Requests;
using TravelPlanner.Api.DTOs.Responses;

namespace TravelPlanner.Api.Services.GrokAIService
{
    public interface IGrokAIService
    {
        Task<DestinationResponseDto> GetDestinationsAsync(DestinationRequestDto request);

        Task<TravelPlanResponseDto> CreateTravelPlanAsync(TravelPlanRequestDto request);
    }
}



