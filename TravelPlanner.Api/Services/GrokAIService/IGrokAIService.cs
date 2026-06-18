using TravelPlanner.Api.Models;


namespace TravelPlanner.Api.Services.GrokAIService
{
    public interface IGrokAIService
    {
        Task<TravelResponse> GenerateTravelPlanAsync(TravelRequest request);
    }
}
               