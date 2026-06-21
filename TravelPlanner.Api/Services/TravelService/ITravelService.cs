using TravelPlanner.Api.DTOs.Requests;
using TravelPlanner.Api.DTOs.Responses;

namespace TravelPlanner.Api.Services.TravelService
{
    public interface ITravelService
    {
        Task<DestinationResponseDto> GetDestinationsAsync(DestinationRequestDto request);

        Task<TravelPlanResponseDto> CreateTravelPlanAsync(TravelPlanRequestDto request);
    }
}



