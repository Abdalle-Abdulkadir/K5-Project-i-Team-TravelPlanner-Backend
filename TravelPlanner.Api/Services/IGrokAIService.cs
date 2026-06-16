using TravelPlanner.Api.Models;


namespace TravelPlanner.Api.Services
{
    public interface IGrokAIService
    {
        Task<TravelResponse> GenerateTravelPlanAsync(TravelRequest request);
    }
}
               